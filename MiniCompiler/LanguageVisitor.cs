using Antlr4.Runtime.Misc;
using System;
using System.Linq;
using MiniCompiler; // Import explicit pentru a folosi ProgramData definit în ProgramData.cs

namespace MiniCompiler
{
    public class LanguageVisitor : MiniLangBaseVisitor<ProgramData>
    {
        private ProgramData _result = new ProgramData();

        public override ProgramData VisitGlobalVariable([NotNull] MiniLangParser.GlobalVariableContext context)
        {
            var type = context.type().GetText(); // Obține tipul variabilei
            var name = context.VARIABLE_NAME().GetText(); // Obține numele variabilei
            var value = context.expression()?.GetText(); // Obține valoarea (ca expresie)

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
            var functionName = context.VARIABLE_NAME().GetText();
            var returnType = ParseVariableType(context.type().GetText());

            var function = new ProgramData.Function
            {
                Name = functionName,
                ReturnType = returnType
            };

            // Procesează parametrii
            if (context.parameterList() != null)
            {
                foreach (var parameterContext in context.parameterList().parameter())
                {
                    var parameterType = ParseVariableType(parameterContext.type().GetText());
                    var parameterName = parameterContext.VARIABLE_NAME().GetText();
                    function.Parameters.Add(new ProgramData.Variable
                    {
                        VariableType = parameterType,
                        Name = parameterName
                    });
                }
            }

            // Procesează corpul funcției
            VisitChildren(context.block());

            _result.Functions.Add(function);
            return _result;
        }

        private ProgramData.Variable.Type ParseVariableType(string type)
        {
            if (type == "int") return ProgramData.Variable.Type.Int;
            if (type == "float") return ProgramData.Variable.Type.Float;
            if (type == "string") return ProgramData.Variable.Type.String;
            if (type == "double") return ProgramData.Variable.Type.Double;

            throw new Exception($"Unknown type: {type}");
        }
    }
}
