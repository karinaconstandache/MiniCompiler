using Antlr4.Runtime.Misc;
using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;

namespace MiniCompiler
{
    public class LanguageVisitor : MiniLangBaseVisitor<ProgramData>
    {
        private readonly ProgramData _result;
        private readonly HashSet<string> _functionSignatures = new HashSet<string>();

        public LanguageVisitor()
        {
            _result = new ProgramData
            {
                GlobalVariables = new List<ProgramData.Variable>(),
                Functions = new List<ProgramData.Function>()
            };
        }

        public override ProgramData VisitProgram([NotNull] MiniLangParser.ProgramContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context), "Program context cannot be null.");

            base.VisitChildren(context);
            ValidateGlobalVariableUniqueness();
            return _result;
        }

        public override ProgramData VisitGlobalVariable([NotNull] MiniLangParser.GlobalVariableContext context)
        {
            var type = context.type()?.GetText();
            var name = context.VARIABLE_NAME()?.GetText();
            var value = context.expression() != null ? VisitExpression(context.expression()) : null;

            if (string.IsNullOrEmpty(type) || string.IsNullOrEmpty(name))
                throw new Exception("Invalid global variable declaration.");


            if (_result.GlobalVariables.Any(v => v.Name == name))
            {
                string errorMsg = $"Error: Global variable '{name}' is already declared.";
                Console.WriteLine(errorMsg);
                File.AppendAllText("errors.txt", errorMsg + "\n");
                throw new Exception(errorMsg);
            }

            var variable = new ProgramData.Variable
            {
                VariableType = ParseVariableType(type),
                Name = name,
                Value = value
            };

            _result.GlobalVariables.Add(variable);
            File.AppendAllText("global_variables.txt", $"{variable.VariableType}, {variable.Name}, {variable.Value ?? "null"}\n");

            return _result;
        }


        private bool HasReturnStatement(MiniLangParser.BlockContext block)
        {
            if (block == null) return false;

            bool hasReturn = false;

            foreach (var stmt in block.statement())
            {
                if (stmt.returnStatement() != null)
                    return true;

                if (stmt.ifStatement() != null)
                {
                    var ifStmt = stmt.ifStatement();
                    bool hasReturnInIf = HasReturnStatement(ifStmt.block(0));
                    bool hasReturnInElse = ifStmt.block(1) != null && HasReturnStatement(ifStmt.block(1));

                    if (!hasReturnInIf || (ifStmt.block(1) != null && !hasReturnInElse))
                        return false;

                    hasReturn = true;
                }
            }

            return hasReturn;
        }

        public override ProgramData VisitFunction([NotNull] MiniLangParser.FunctionContext context)
        {
            var functionName = context.VARIABLE_NAME()?.GetText();
            var returnType = ParseVariableType(context.type()?.GetText());

            if (string.IsNullOrEmpty(functionName))
                throw new Exception("Function name cannot be null or empty.");

            string functionSignature = functionName + "(";
            List<string> paramTypes = new List<string>();

            if (context.parameterList() != null)
            {
                foreach (var parameterContext in context.parameterList().parameter())
                {
                    var parameterType = ParseVariableType(parameterContext.type()?.GetText());
                    paramTypes.Add(parameterType.ToString());
                }
            }

            functionSignature += string.Join(", ", paramTypes) + ")";

            if (_functionSignatures.Contains(functionSignature))
            {
                string errorMsg = $"Error: Duplicate function declaration: {functionSignature}";
                Console.WriteLine(errorMsg);
                File.AppendAllText("errors.txt", errorMsg + "\n");
                throw new Exception(errorMsg);
            }

            _functionSignatures.Add(functionSignature);

            bool isRecursive = false;
            bool hasInfiniteLoop = false;

            if (context.block() != null)
            {
                foreach (var stmt in context.block().statement())
                {
                    if (stmt.ifStatement() != null)
                    {
                        File.AppendAllText("functions.txt", $"Control structure: <if, {stmt.Start.Line}>\n");
                    }
                    else if (stmt.forLoop() != null)
                    {
                        hasInfiniteLoop = IsPotentialInfiniteLoop(stmt.forLoop());
                        File.AppendAllText("functions.txt", $"Control structure: <for, {stmt.Start.Line}>");
                        if(hasInfiniteLoop)
                        {
                            File.AppendAllText("functions.txt", "Infinite loop\n");
                        }
                        else File.AppendAllText("functions.txt", "\n");
                    }
                    else if (stmt.whileStatement() != null)
                    {
                        hasInfiniteLoop = IsPotentialInfiniteLoop(stmt.whileStatement());
                        File.AppendAllText("functions.txt", $"Control structure: <while, {stmt.Start.Line}>");
                        if (hasInfiniteLoop)
                        {
                            File.AppendAllText("functions.txt", "Infinite loop\n");
                        }
                        else File.AppendAllText("functions.txt", "\n");
                    }
                    else if (stmt.declaration() != null)
                    {
                        var type = stmt.declaration().type()?.GetText();
                        var name = stmt.declaration().VARIABLE_NAME()?.GetText();
                        var value = stmt.declaration().expression() != null
                    ? VisitExpression(stmt.declaration().expression())?.ToString()
                    : "null";
                        File.AppendAllText("functions.txt", $"Local Variable: <{type}, {name}, {value}>, Line: {stmt.Start.Line}\n");
                    }
                    else if (stmt.functionCall() != null)
                    {
                        var calledFunctionName = stmt.functionCall().VARIABLE_NAME()?.GetText();
                        if (calledFunctionName == functionName)
                        {
                            isRecursive = true;
                            File.AppendAllText("functions.txt", $"Recursive Call: {functionName} calls itself, Line: {stmt.Start.Line}\n");
                        }
                    }
                    else if (stmt.returnStatement() != null)
                    {
                        var returnExpr = stmt.returnStatement().expression();
                        if (returnExpr != null && ContainsRecursiveCall(returnExpr, functionName))
                        {
                            isRecursive = true;
                            File.AppendAllText("functions.txt", $"Recursive Call: {functionName} calls itself in return statement, Line: {stmt.Start.Line}\n");
                        }
                    }
                }
            }

            if (hasInfiniteLoop)
            {
                Console.WriteLine($"Warning: Function '{functionName}' contains an infinite loop.");
            }

            var functionDetails = $"Function: {functionName}, Return Type: {returnType}, Parameters: ({string.Join(", ", paramTypes)}), " + 
                                  $"{(isRecursive ? "Recursive" : "Iterative")}, " +
                                  $"{(hasInfiniteLoop ? "Contains Possible Infinite Loop" : "")}\n";
            File.AppendAllText("functions.txt", functionDetails);

            _result.Functions.Add(new ProgramData.Function
            {
                Name = functionName,
                ReturnType = returnType
            });

            if (context.block() != null)
            {
                VisitBlock(context.block());
            }

            return _result;
        }

        private bool ContainsRecursiveCall(MiniLangParser.ExpressionContext expr, string functionName)
        {
            if (expr == null)
                return false;

            if (expr.functionCall() != null)
            {
                return expr.functionCall().VARIABLE_NAME().GetText() == functionName;
            }

            foreach (var child in expr.children)
            {
                if (child is MiniLangParser.ExpressionContext subExpr)
                {
                    if (ContainsRecursiveCall(subExpr, functionName))
                        return true;
                }
            }

            return false;
        }

        private bool IsPotentialInfiniteLoop(MiniLangParser.WhileStatementContext context)
        {
            if (context.condition() == null)
                return false;

            string conditionText = context.condition().GetText();

            if (conditionText == "true" || conditionText == "1")
            {
                return !ContainsBreakOrReturn(context.block());
            }

            return false;
        }

        private bool IsPotentialInfiniteLoop(MiniLangParser.ForLoopContext context)
        {
            if (context.condition() == null)
                return !ContainsBreakOrReturn(context.block());

            string conditionText = context.condition().GetText();

            if (conditionText == "true" || conditionText == "1")
            {
                return !ContainsBreakOrReturn(context.block());
            }

            return false;
        }

        private bool ContainsBreakOrReturn(MiniLangParser.BlockContext block)
        {
            if (block == null)
                return false;

            foreach (var stmt in block.statement())
            {
                if (stmt.returnStatement() != null) return true;
                if (stmt.GetText().Contains("break;")) return true;
            }

            return false;
        }

        public override ProgramData VisitMainFunction([NotNull] MiniLangParser.MainFunctionContext context)
        {

            var functionName = "main";
            var returnType = ProgramData.Variable.Type.Int;

            var function = new ProgramData.Function
            {
                Name = functionName,
                ReturnType = returnType
            };

            if (context.block() != null)
            {
                foreach (var stmt in context.block().statement())
                {
                    if (stmt.ifStatement() != null)
                    {
                        File.AppendAllText("functions.txt", $"Control structure: <if, {stmt.Start.Line}>\n");
                    }
                    else if (stmt.forLoop() != null)
                    {
                        File.AppendAllText("functions.txt", $"Control structure: <for, {stmt.Start.Line}>\n");
                    }
                    else if (stmt.whileStatement() != null)
                    {
                        File.AppendAllText("functions.txt", $"Control structure: <while, {stmt.Start.Line}>\n");
                    }
                    else if (stmt.declaration() != null)
                    {
                        var type = stmt.declaration().type()?.GetText();
                        var name = stmt.declaration().VARIABLE_NAME()?.GetText();
                        var value = stmt.declaration().expression() != null
                    ? VisitExpression(stmt.declaration().expression())?.ToString()
                    : "null";

                        File.AppendAllText("functions.txt", $"Local Variable: <{type}, {name}, {value}>, Line: {stmt.Start.Line}\n");
                    }
                }

                VisitBlock(context.block());
            }

            if (!HasReturnStatement(context.block()))
            {
                Console.WriteLine($"Warning: Function '{function.Name}' may not return a value in all cases.");
                File.AppendAllText("errors.txt", $"Warning: Function '{function.Name}' may not return a value in all cases.\n");
            }

            var functionDetails = $"Function: {function.Name}, Return Type: {function.ReturnType}\n";
            File.AppendAllText("functions.txt", functionDetails);

            _result.Functions.Add(function);
            return _result;
        }

        public override ProgramData VisitBlock([NotNull] MiniLangParser.BlockContext context)
        {
            foreach (var stmt in context.statement())
            {
                VisitStatement(stmt);
            }

            return base.VisitBlock(context);
        }


        public override ProgramData VisitFunctionCall([NotNull] MiniLangParser.FunctionCallContext context)
        {
            var functionName = context.VARIABLE_NAME().GetText();

            if (!_result.Functions.Any(f => f.Name == functionName))
            {
                Console.WriteLine($"Error: Function '{functionName}' is not defined.");
                File.AppendAllText("errors.txt", $"Error: Function '{functionName}' is not defined.\n");
                throw new Exception($"Function '{functionName}' is not defined.");
            }

            return base.VisitFunctionCall(context);
        }
        
        private void ValidateGlobalVariableUniqueness()
        {
            var duplicates = _result.GlobalVariables
                .GroupBy(v => v.Name)
                .Where(g => g.Count() > 1)
                .Select(g => g.Key);

            foreach (var duplicate in duplicates)
            {
                string errorMsg = $"Error: Duplicate global variable '{duplicate}'";
                Console.WriteLine(errorMsg);
                File.AppendAllText("errors.txt", errorMsg + "\n");
                throw new Exception(errorMsg);
            }
        }


        private ProgramData.Variable.Type ParseVariableType(string type)
        {
            switch (type)
            {
                case "int":
                    return ProgramData.Variable.Type.Int;
                case "float":
                    return ProgramData.Variable.Type.Float;
                case "string":
                    return ProgramData.Variable.Type.String;
                case "double":
                    return ProgramData.Variable.Type.Double;
                case "void":
                    return ProgramData.Variable.Type.Void;
                default:
                    throw new Exception($"Unknown type: {type}");
            }
        }

        public override ProgramData VisitStatement([NotNull] MiniLangParser.StatementContext context)
        {
            return base.VisitStatement(context);
        }

        private dynamic VisitExpression(MiniLangParser.ExpressionContext context)
        {
            if (context == null || string.IsNullOrWhiteSpace(context.GetText()))
            {
                Console.WriteLine("Error: Incomplete expression detected.\n");
                File.AppendAllText("errors.txt", "Error: Incomplete expression detected.\n");
                throw new Exception("Incomplete expression detected.");
            }

            if (context.value() != null)
            {
                var valueContext = context.value();
                if (valueContext.INTEGER_VALUE() != null)
                    return int.Parse(valueContext.INTEGER_VALUE().GetText());
                if (valueContext.FLOAT_VALUE() != null)
                    return float.Parse(valueContext.FLOAT_VALUE().GetText());
                if (valueContext.DOUBLE_VALUE() != null)
                    return double.Parse(valueContext.DOUBLE_VALUE().GetText());
                if (valueContext.STRING_VALUE() != null)
                    return valueContext.STRING_VALUE().GetText().Trim('"');
                if (valueContext.VARIABLE_NAME() != null)
                    return valueContext.VARIABLE_NAME().GetText();
            }

            if (context.functionCall() != null)
            {
                var functionName = context.functionCall().VARIABLE_NAME().GetText();
                var arguments = context.functionCall().argumentList()?.expression()
                    .Select(VisitExpression)
                    .ToList();

                return $"{functionName}({string.Join(", ", arguments ?? new List<object>())})";
            }

            if (context.children.Count == 3 && context.ARITHMETIC_OPERATOR() != null)
            {
                var left = VisitExpression(context.GetChild(0) as MiniLangParser.ExpressionContext);
                var right = VisitExpression(context.GetChild(2) as MiniLangParser.ExpressionContext);
                var op = context.ARITHMETIC_OPERATOR().GetText();

                switch (op)
                {
                    case "+":
                        return Convert.ToDouble(left) + Convert.ToDouble(right);
                    case "-":
                        return Convert.ToDouble(left) - Convert.ToDouble(right);
                    case "*":
                        return Convert.ToDouble(left) * Convert.ToDouble(right);
                    case "/":
                        return Convert.ToDouble(left) / Convert.ToDouble(right);
                    case "%":
                        return Convert.ToDouble(left) % Convert.ToDouble(right);
                    default:
                        throw new Exception($"Unsupported operator: {op}");
                }
            }

            return context.GetText();

            throw new Exception($"Unsupported expression: {context.GetText()}");


        }
    }
}