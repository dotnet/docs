using System;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace SemanticQuickStart
{
    class Program
    {
        // <Snippet1>
        const string programText =
@"using System;
using System.Collections.Generic;
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
        // </Snippet1>

        static void Main(string[] args)
        {
            // <Snippet2>
            SyntaxTree tree = CSharpSyntaxTree.ParseText(programText);

            CompilationUnitSyntax root = tree.GetCompilationUnitRoot();
            // </Snippet2>

            // <Snippet3>
            var compilation = CSharpCompilation.Create("HelloWorld")
                .AddReferences(MetadataReference.CreateFromFile(
                    typeof(string).Assembly.Location))
                .AddSyntaxTrees(tree);
            // </Snippet3>

            // <Snippet4>
            SemanticModel model = compilation.GetSemanticModel(tree);
            // </Snippet4>

            // <Snippet5>
            // Use the syntax tree to find "using System;"
            UsingDirectiveSyntax usingSystem = root.Usings[0];
            NameSyntax systemName = usingSystem.Name;

            // Use the semantic model for symbol information:
            SymbolInfo nameInfo = model.GetSymbolInfo(systemName);
            // </Snippet5>

            // <Snippet6>
            var systemSymbol = (INamespaceSymbol)nameInfo.Symbol;
            foreach (INamespaceSymbol ns in systemSymbol.GetNamespaceMembers())
            {
                Console.WriteLine(ns);
            }
            // </Snippet6>

            // <Snippet7>
            // Use the syntax model to find the literal string:
            LiteralExpressionSyntax helloWorldString = root.DescendantNodes()
                .OfType<LiteralExpressionSyntax>()
                .Single();

            // Use the semantic model for type information:
            TypeInfo literalInfo = model.GetTypeInfo(helloWorldString);
            // </Snippet7>

            // <Snippet8>
            var stringTypeSymbol = (INamedTypeSymbol)literalInfo.Type;
            // </Snippet8>

            Console.Clear();

            // build the linq query in steps:
            // Exploratory code. You can look at the variables
            // from each step in the query to gain more understanding
            // of the logic to find the correct method names.

            // <Snippet9>
            var allMembers = stringTypeSymbol.GetMembers();
            // </Snippet9>
            // <Snippet10>
            var methods = allMembers.OfType<IMethodSymbol>();
            // </Snippet10>
            // <Snippet11>
            var publicStringReturningMethods = methods
                .Where(m => m.ReturnType.Equals(stringTypeSymbol) &&
                m.DeclaredAccessibility == Accessibility.Public);
            // </Snippet11>
            // <Snippet12>
            var distinctMethods = publicStringReturningMethods.Select(m => m.Name).Distinct();
            // </Snippet12>

            // <Snippet13>
            foreach (string name in (from method in stringTypeSymbol
                                     .GetMembers().OfType<IMethodSymbol>()
                                     where method.ReturnType.Equals(stringTypeSymbol) &&
                                     method.DeclaredAccessibility == Accessibility.Public
                                     select method.Name).Distinct())
            {
                Console.WriteLine(name);
            }
            // </Snippet13>
        }
    }
}
