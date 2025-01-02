using Antlr4.Runtime;
using MiniCompiler;
using System;
using System.Linq;

public class Program
{
    public static void Main()
    {
        string code = @"
            int addIntegers(int first, int second)
            {
                return first + second;
            }
            float divideIntegers(int first, int second)
            {
                if (second == 0)
                {
                    return 0; //We don’t want to handle exceptions, so we’ll return 0 for simplicity
                }
                return first / second;
            }
            double globalVariable = 15.67; //Using global variables is bad practice
            int main()
            {
                int myFirstVariable = 17;
                int mySecondVariable = 45;
                int myThirdVariable = 3;
                for (int i = 0; i < myThirdVariable; ++i)
                {
                    myFirstVariable += i;
                }
                string myString = """";
                if (myFirstVariable >= mySecondVariable && globalVariable != 16.54)
                {
                    myString = ""Both conditions are true"";
                }
                else
                {
                    myString = ""At least one of the conditions is false"";
                    int temp = myFirstVariable + 5;
                }
                myThirdVariable = addIntegers(myFirstVariable, mySecondVariable);
                float myFloat = divideIntegers(myThirdVariable, myFirstVariable);
                return 0;
            }
        ";

        try
        {
            // Step 1: Create the input stream
            AntlrInputStream inputStream = new AntlrInputStream(code);

            // Step 2: Create the lexer
            MiniLangLexer lexer = new MiniLangLexer(inputStream);

            // Step 3: Create the token stream
            CommonTokenStream tokenStream = new CommonTokenStream(lexer);

            // Step 4: Create the parser
            MiniLangParser parser = new MiniLangParser(tokenStream);

            // Step 5: Parse the input using the root rule (program)
            var tree = parser.program();

            // Step 6: Visit the parsed tree
            LanguageVisitor visitor = new LanguageVisitor();
            var programData = visitor.Visit(tree);


            // Output success message
            Console.WriteLine("Parsing completed successfully!");


            // Display parsed global variables and functions
            Console.WriteLine("Global Variables:");

            if (programData == null)
            {
                Console.WriteLine("Error: `programData` is null.");
                return;
            }

            if (programData.GlobalVariables == null)
            {
                Console.WriteLine("Error: `GlobalVariables` is null.");
                return;
            }

            if (!programData.GlobalVariables.Any())
            {
                Console.WriteLine("No global variables found.");
            }
            else
            {
                foreach (var variable in programData.GlobalVariables)
                {
                    if (variable == null)
                    {
                        Console.WriteLine("Error: A variable in `GlobalVariables` is null.");
                        continue;
                    }

                    Console.WriteLine($"- Name: {variable.Name}, Type: {variable.VariableType}, Value: {variable.Value ?? "null"}");
                }
            }


            Console.WriteLine("Functions:");
            foreach (var function in programData.Functions)
            {
                Console.WriteLine($"- Name: {function.Name}, Return Type: {function.ReturnType}");
                Console.WriteLine("  Parameters:");
                foreach (var parameter in function.Parameters)
                {
                    Console.WriteLine($"    - Name: {parameter.Name}, Type: {parameter.VariableType}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
