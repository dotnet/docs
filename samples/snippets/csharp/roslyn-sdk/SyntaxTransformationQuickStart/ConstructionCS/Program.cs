using System;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

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
            NameSyntax name = SyntaxFactory.IdentifierName("System");
            Console.WriteLine($"\tCreated the identifier {name.ToString()}");
            // </SnippetCreateIdentifierName>

            // <SnippetCreateQualifiedIdentifierName>
            name = SyntaxFactory.QualifiedName(name, SyntaxFactory.IdentifierName("Collections"));
            Console.WriteLine(name.ToString());
            // </SnippetCreateQualifiedIdentifierName>

            // <SnippetCreateFullNamespace>
            name = SyntaxFactory.QualifiedName(name, SyntaxFactory.IdentifierName("Generic"));
            Console.WriteLine(name.ToString());
            // </SnippetCreateFullNamespace>

            // <SnippetCreateParseTree>
            SyntaxTree tree = CSharpSyntaxTree.ParseText(sampleCode);
            var root = (CompilationUnitSyntax)tree.GetRoot();
            // </SnippetCreateParseTree>

            // <SnippetBuildNewUsing>
            var oldUsing = root.Usings[1];
            var newUsing = oldUsing.WithName(name);
            Console.WriteLine(root.ToString());
            // </SnippetBuildNewUsing>

            Console.WriteLine();
            Console.WriteLine();

            // <SnippetTransformTree>
            root = root.ReplaceNode(oldUsing, newUsing);
            Console.WriteLine(root.ToString());
            // </SnippetTransformTree>
        }
    }
}
