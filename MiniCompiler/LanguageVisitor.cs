using Antlr4.Runtime.Misc;
using System;
using System.Linq;
using System.Collections.Generic;

namespace MiniCompiler
{
    public class LanguageVisitor : MiniLangBaseVisitor<ProgramData>
    {
        private readonly ProgramData _result = new ProgramData();

        public override ProgramData VisitGlobalVariable([NotNull] MiniLangParser.GlobalVariableContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context), "Context cannot be null");

            var type = context.type().GetText();
            var name = context.VARIABLE_NAME().GetText();
            var value = context.expression() != null ? VisitExpression(context.expression()) : null;

            if (_result.GlobalVariables == null)
                _result.GlobalVariables = new List<ProgramData.Variable>();

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

            var functionName = context.VARIABLE_NAME().GetText();
            var returnType = ParseVariableType(context.type().GetText());

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
                    var parameterType = ParseVariableType(parameterContext.type().GetText());
                    var parameterName = parameterContext.VARIABLE_NAME().GetText();

                    if (function.Parameters == null)
                        function.Parameters = new List<ProgramData.Variable>();

                    function.Parameters.Add(new ProgramData.Variable
                    {
                        VariableType = parameterType,
                        Name = parameterName
                    });
                }
            }

            // Procesăm corpul funcției
            VisitChildren(context.block());

            if (_result.Functions == null)
                _result.Functions = new List<ProgramData.Function>();

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
            if (context == null) return null;

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

                return $"Function Call: {functionName}({string.Join(", ", arguments?.Select(arg => arg.ToString()) ?? new List<string>())})";
            }

            throw new Exception("Unsupported expression type.");
        }
    }
}
