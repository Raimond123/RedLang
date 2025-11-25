using antrl4CS.Nodes;
using antrl4CS;
using Antlr4.Runtime;
using antrl4CS.Nodes;
using antrl4CS;

namespace RedLangCompiler
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string code = @"
                use Math;
                use IO;
                use Strings;

                object Program {
                    entry func Main():i {
            
                        gives 1 + 2 * 3 - (4 / 2) and not 0 or 10 < 20;
                    }
                }

                object Test {

                    func DoSomething(a:i, b:i):i {
            
                        gives (a + b) * 2 >= 10 or false;
                    }
                }
            ";


            AntlrInputStream input = new(code);
            construccion_semana2Lexer lexer = new(input);
            CommonTokenStream tokens = new(lexer);

            construccion_semana2Parser parser = new(tokens);
            var tree = parser.program();

            var visitor = new AstBuilderVisitor();
            var ast = visitor.Visit(tree);

            Console.WriteLine("AST construido correctamente");
        }
    }
}
