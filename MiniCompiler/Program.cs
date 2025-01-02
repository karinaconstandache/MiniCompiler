using Antlr4.Runtime;
using MiniCompiler;
using System;

public class Program
{
    public static void Main()
    {
        try
        {
            //string code = "int nameThisIntWhateverYouWant = 18;";
            string code = "int nameThisStringWhateverYouWant = 45;";
            //string code = "float nameThisFloatWhateverYouWant = 3.14;";
            AntlrInputStream inputStream = new AntlrInputStream(code);
            MiniLangLexer ifConditionLexer = new MiniLangLexer(inputStream);
            CommonTokenStream commonTokenStream = new CommonTokenStream(ifConditionLexer);
            MiniLangParser parser = new MiniLangParser(commonTokenStream);

            MiniLangParser.DeclarationContext context = parser.declaration();
            LanguageVisitor languageVisitor = new LanguageVisitor();
            var result = languageVisitor.Visit(context);

            Console.WriteLine($"The type of the variable is {result.Variables[0].VariableType.ToString()} and its value is {result.Variables[0].Value}");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

    }
}
