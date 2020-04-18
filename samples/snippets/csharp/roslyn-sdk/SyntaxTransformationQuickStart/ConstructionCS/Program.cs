using System;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

// <SnippetStaticUsings>
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using static System.Console;
// </SnippetStaticUsings>

namespace ConstructionCS
{
    class Program
    {
        // <SnippetDeclareSampleCode>
        private const string sampleCode =
@"using System;
using System.Collections;
using System.Linq;
using System.Text;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(""Hello, World!"");
        }
    }
}";
        // </SnippetDeclareSampleCode>

        static void Main(string[] args)
        {
            // <SnippetCreateIdentifierName>
            NameSyntax name = IdentifierName("System");
            WriteLine($"\tCreated the identifier {name.ToString()}");
            // </SnippetCreateIdentifierName>

            // <SnippetCreateQualifiedIdentifierName>
            name = QualifiedName(name, IdentifierName("Collections"));
            WriteLine(name.ToString());
            // </SnippetCreateQualifiedIdentifierName>

            // <SnippetCreateFullNamespace>
            name = QualifiedName(name, IdentifierName("Generic"));
            WriteLine(name.ToString());
            // </SnippetCreateFullNamespace>

            // <SnippetCreateParseTree>
            SyntaxTree tree = CSharpSyntaxTree.ParseText(sampleCode);
            var root = (CompilationUnitSyntax)tree.GetRoot();
            // </SnippetCreateParseTree>

            // <SnippetBuildNewUsing>
            var oldUsing = root.Usings[1];
            var newUsing = oldUsing.WithName(name);
            WriteLine(root.ToString());
            // </SnippetBuildNewUsing>

            Console.WriteLine();
            Console.WriteLine();

            // <SnippetTransformTree>
            root = root.ReplaceNode(oldUsing, newUsing);
            WriteLine(root.ToString());
            // </SnippetTransformTree>
        }
    }
}
