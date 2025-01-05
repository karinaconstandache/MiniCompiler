using System.Collections.Generic;

namespace MiniCompiler
{
    public class ProgramData
    {
        public class Variable
        {
            public enum Type
            {
                Int,
                Float,
                String,
                Double,
                Void
            }

            public Type VariableType { get; set; }
            public string Name { get; set; }
            public dynamic Value { get; set; }
        }

        public class Function
        {
            public string Name { get; set; }
            public Variable.Type ReturnType { get; set; }
            public List<Variable> Parameters { get; set; } = new List<Variable>();
            public List<Variable> LocalVariables { get; set; } = new List<Variable>();
        }

        public List<Variable> GlobalVariables { get; set; } = new List<Variable>();
        public List<Function> Functions { get; set; } = new List<Function>();
    }
}
