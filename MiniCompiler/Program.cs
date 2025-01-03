using Antlr4.Runtime;
using MiniCompiler;
using System;
using System.IO;
using System.Linq;

public class Program
{
    public static void Main()
    {
        File.WriteAllText("tokens.txt", string.Empty);
        File.WriteAllText("functions.txt", string.Empty);
        File.WriteAllText("errors.txt", string.Empty);
        File.WriteAllText("global_variables.txt", string.Empty);

        string filePath = "input.txt";

        if (!File.Exists(filePath))
        {
            Console.WriteLine($"Error: The file '{filePath}' does not exist.");
            return;
        }

        try
        {
            string code = File.ReadAllText(filePath);

            AntlrInputStream inputStream = new AntlrInputStream(code);
            MiniLangLexer lexer = new MiniLangLexer(inputStream);
            CommonTokenStream tokenStream = new CommonTokenStream(lexer);
            MiniLangParser parser = new MiniLangParser(tokenStream);
            var tree = parser.program();

            LanguageVisitor visitor = new LanguageVisitor();
            var programData = visitor.Visit(tree);

            foreach (var token in tokenStream.GetTokens())
            {
                var line = token.Line;
                var text = token.Text;
                var type = lexer.Vocabulary.GetSymbolicName(token.Type) ?? "UNKNOWN";
                File.AppendAllText("tokens.txt", $"<{type}, {text}, {line}>\n");
            }

            if (new FileInfo("errors.txt").Length == 0)
            {
                File.WriteAllText("errors.txt", "No errors found.\n");
            }

            Console.WriteLine("Parsing completed successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
