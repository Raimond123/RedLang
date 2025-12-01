using Antlr4.Runtime;
using antrl4CS.Node;
using antrl4CS;   
using System;
using System.IO;

namespace antrl4CS
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // 1. Leer input
            string inputText;
            if (args.Length > 0 && File.Exists(args[0]))
                inputText = File.ReadAllText(args[0]);
            else
            {
                Console.WriteLine("Enter source (end with Ctrl+Z):");
                inputText = Console.In.ReadToEnd();
            }

            // 2. Crear lexer y parser
            var inputStream = new AntlrInputStream(inputText);
            var lexer = new construccion_semana2Lexer(inputStream);
            var tokens = new CommonTokenStream(lexer);
            var parser = new construccion_semana2Parser(tokens);

            var tree = parser.program();

            // 3. Construir AST
            var visitor = new AstBuilderVisitor();
            var ast = visitor.VisitProgram(tree) as ProgramNode;

            Console.WriteLine("AST construido correctamente.");

            // 4. Ejecutar análisis semántico
            try
            {
                var analyzer = new SemanticAnalyzer();
                analyzer.Analyze(ast!);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n Análisis semántico completado sin errores.");
                Console.ResetColor();
            }
            catch (CompilerException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\n SEMANTIC ERROR: {ex.Message}");
                Console.ResetColor();
                return;
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"\n❌ INTERNAL ERROR: {ex}");
                Console.ResetColor();
                return;
            }

            // 5. Resumen
            Console.WriteLine("\n=== AST SUMMARY ===");
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

            Console.WriteLine("\nProgram finished.");
        }
    }
}
