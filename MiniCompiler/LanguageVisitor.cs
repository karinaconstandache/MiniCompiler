using Antlr4.Runtime.Misc;
using System;
using System.Linq;
using System.Collections.Generic;

namespace MiniCompiler
{
    public class LanguageVisitor : MiniLangBaseVisitor<ProgramData>
    {
        private readonly ProgramData _result;

        public LanguageVisitor()
        {
            // Inițializăm rezultatul cu liste goale
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

            base.VisitChildren(context); // Vizitează toți copiii nodului program
            return _result; // Returnează obiectul rezultat
        }

        public override ProgramData VisitGlobalVariable([NotNull] MiniLangParser.GlobalVariableContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context), "Context cannot be null");

            var type = context.type()?.GetText();
            var name = context.VARIABLE_NAME()?.GetText();
            var value = context.expression() != null ? VisitExpression(context.expression()) : null;

            if (string.IsNullOrEmpty(type) || string.IsNullOrEmpty(name))
                throw new Exception("Invalid global variable declaration.");

            _result.GlobalVariables.Add(new ProgramData.Variable
            {
                VariableType = ParseVariableType(type),
                Name = name,
                Value = value
            });

            return _result;
        }

        public override ProgramData VisitFunction([NotNull] MiniLangParser.FunctionContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context), "Context cannot be null");

            var functionName = context.VARIABLE_NAME()?.GetText();
            var returnType = ParseVariableType(context.type()?.GetText());

            if (string.IsNullOrEmpty(functionName))
                throw new Exception("Function name cannot be null or empty.");

            var function = new ProgramData.Function
            {
                Name = functionName,
                ReturnType = returnType
            };

            // Procesăm parametrii funcției
            if (context.parameterList() != null)
            {
                foreach (var parameterContext in context.parameterList().parameter())
                {
                    var parameterType = ParseVariableType(parameterContext.type()?.GetText());
                    var parameterName = parameterContext.VARIABLE_NAME()?.GetText();

                    if (string.IsNullOrEmpty(parameterName))
                        throw new Exception("Parameter name cannot be null or empty.");

                    function.Parameters.Add(new ProgramData.Variable
                    {
                        VariableType = parameterType,
                        Name = parameterName
                    });
                }
            }

            // Procesăm corpul funcției
            VisitChildren(context.block());

            _result.Functions.Add(function);
            return _result;
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
                default:
                    throw new Exception($"Unknown type: {type}");
            }
        }

        private dynamic VisitExpression(MiniLangParser.ExpressionContext context)
        {
            if (context == null)
                return null;

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
                    .Select(arg => VisitExpression(arg))
                    .ToList();

                return $"Function Call: {functionName}({string.Join(", ", arguments)})";
            }

            throw new Exception($"Unsupported expression: {context.GetText()}");
        }

        public override ProgramData VisitMainFunction([NotNull] MiniLangParser.MainFunctionContext context)
        {
            var mainFunction = new ProgramData.Function
            {
                Name = "main",
                ReturnType = ProgramData.Variable.Type.Int
            };

            VisitChildren(context.block()); // Vizitează blocul funcției main

            _result.Functions.Add(mainFunction);
            return _result;
        }
    }
}
