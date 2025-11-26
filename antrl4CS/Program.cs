using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using antrl4CS.Node;
using System;
using System.IO;

namespace antrl4CS
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // Simple runner: reads from file path or stdin
            string inputText;
            if (args.Length > 0 && File.Exists(args[0]))
            {
                inputText = File.ReadAllText(args[0]);
            }
            else
            {
                Console.WriteLine("Enter source (end with Ctrl+Z / Ctrl+D):");
                inputText = Console.In.ReadToEnd();
            }

            var inputStream = new AntlrInputStream(inputText);
            var lexer = new construccion_semana2Lexer(inputStream);
            var tokens = new CommonTokenStream(lexer);
            var parser = new construccion_semana2Parser(tokens);

            parser.RemoveErrorListeners();
            parser.AddErrorListener(new ConsoleErrorListener());

            var tree = parser.program();
            var visitor = new AstBuilderVisitor();
            var ast = visitor.VisitProgram(tree) as ProgramNode;

            // Basic dump of AST summary
            Console.WriteLine($"Uses: {ast?.UseNodes.Count ?? 0}");
            foreach (var u in ast!.UseNodes)
                Console.WriteLine($" - use {u.ClassName}");

            Console.WriteLine($"Classes: {ast.ClassNodes.Count}");
            foreach (var c in ast.ClassNodes)
            {
                Console.WriteLine($" - class {c.Name}");
                foreach (var m in c.Members)
                {
                    switch (m)
                    {
                        case VariableDeclNode vd:
                            Console.WriteLine($"   declare {vd.Name}:{vd.Type?.BaseName ?? "?"}");
                            break;
                        case FunctionNode fn:
                            Console.WriteLine($"   {(fn.IsEntry ? "entry " : "")}func {fn.Name}(...):{fn.ReturnType.BaseName}");
                            break;
                        default:
                            Console.WriteLine($"   member: {m.GetType().Name}");
                            break;
                    }
                }
            }
        }

        private class ConsoleErrorListener : IAntlrErrorListener<IToken>
        {
            public void SyntaxError(TextWriter output, IRecognizer recognizer, IToken offendingSymbol, int line, int charPositionInLine, string msg, RecognitionException e)
            {
                Console.Error.WriteLine($"Syntax error at {line}:{charPositionInLine} - {msg}");
            }
        }
    }
}