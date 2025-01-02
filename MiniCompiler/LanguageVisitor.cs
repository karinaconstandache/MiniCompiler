using Antlr4.Runtime.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniCompiler
{
    public class LanguageVisitor : MiniLangBaseVisitor<ProgramData>
    {
        private ProgramData _result = new ProgramData();

        public override ProgramData VisitDeclaration([NotNull] MiniLangParser.DeclarationContext context)
        {
            VisitChildren(context);
            return _result;
        }

        public override ProgramData VisitType([NotNull] MiniLangParser.TypeContext context)
        {
            if (context.INTEGER_TYPE() != null)
            {
                _result.Variables.Add(new ProgramData.Variable { VariableType = ProgramData.Variable.Type.Int });
            }
            else if (context.FLOAT_TYPE() != null)
            {
                _result.Variables.Add(new ProgramData.Variable { VariableType = ProgramData.Variable.Type.Float });
            }
            else if (context.STRING_TYPE() != null)
            {
                _result.Variables.Add(new ProgramData.Variable { VariableType = ProgramData.Variable.Type.String });
            }
            else
            {
                throw new Exception("Unknown variable type");
            }

            return _result;
        }

        public override ProgramData VisitValue([NotNull] MiniLangParser.ValueContext context)
        {
            var lastVariable = _result.Variables.Last();
            var value = context.INTEGER_VALUE()
                 ?? context.FLOAT_VALUE()
                 ?? context.STRING_VALUE();

            if (lastVariable.VariableType == ProgramData.Variable.Type.Int && context.INTEGER_VALUE() != null)
            {
                lastVariable.Value = context.INTEGER_VALUE().GetText();
            }
            else if (lastVariable.VariableType == ProgramData.Variable.Type.Float && context.FLOAT_VALUE() != null)
            {
                lastVariable.Value = context.FLOAT_VALUE().GetText();
            }
            else if (lastVariable.VariableType == ProgramData.Variable.Type.String && context.STRING_VALUE() != null)
            {
                lastVariable.Value = context.STRING_VALUE().GetText();
            }
            else
            {
                throw new Exception($"The type of the variable ({lastVariable.VariableType}) does not correspond with the " +
                    $"value {value}");
            }

            return _result;
        }

    }
}
