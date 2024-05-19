using static System.Console;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace HelloSyntaxTree
{
    class Program
    {

        // <Snippet1>
        const string programText =
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
        // </Snippet1>

        static void Main(string[] args)
        {
            // <Snippet2>
            SyntaxTree tree = CSharpSyntaxTree.ParseText(programText);
            CompilationUnitSyntax root = tree.GetCompilationUnitRoot();
            // </Snippet2>

            // <Snippet3>
            WriteLine($"The tree is a {root.Kind()} node.");
            WriteLine($"The tree has {root.Members.Count} elements in it.");
            WriteLine($"The tree has {root.Usings.Count} using statements. They are:");
            foreach (UsingDirectiveSyntax element in root.Usings)
                WriteLine($"\t{element.Name}");
            // </Snippet3>

            // <Snippet4>
            MemberDeclarationSyntax firstMember = root.Members[0];
            WriteLine($"The first member is a {firstMember.Kind()}.");
            var helloWorldDeclaration = (NamespaceDeclarationSyntax)firstMember;
            // </Snippet4>

            // <Snippet5>
            WriteLine($"There are {helloWorldDeclaration.Members.Count} members declared in this namespace.");
            WriteLine($"The first member is a {helloWorldDeclaration.Members[0].Kind()}.");
            // </Snippet5>

            // <Snippet6>
            var programDeclaration = (ClassDeclarationSyntax)helloWorldDeclaration.Members[0];
            WriteLine($"There are {programDeclaration.Members.Count} members declared in the {programDeclaration.Identifier} class.");
            WriteLine($"The first member is a {programDeclaration.Members[0].Kind()}.");
            var mainDeclaration = (MethodDeclarationSyntax)programDeclaration.Members[0];
            // </Snippet6>

            // <Snippet7>
            WriteLine($"The return type of the {mainDeclaration.Identifier} method is {mainDeclaration.ReturnType}.");
            WriteLine($"The method has {mainDeclaration.ParameterList.Parameters.Count} parameters.");
            foreach (ParameterSyntax item in mainDeclaration.ParameterList.Parameters)
                WriteLine($"The type of the {item.Identifier} parameter is {item.Type}.");
            WriteLine($"The body text of the {mainDeclaration.Identifier} method follows:");
            WriteLine(mainDeclaration.Body?.ToFullString());

            var argsParameter = mainDeclaration.ParameterList.Parameters[0];
            // </Snippet7>

            // <Snippet8>
            var firstParameters = from methodDeclaration in root.DescendantNodes()
                                                    .OfType<MethodDeclarationSyntax>()
                                  where methodDeclaration.Identifier.ValueText == "Main"
                                  select methodDeclaration.ParameterList.Parameters.First();

            var argsParameter2 = firstParameters.Single();

            WriteLine(argsParameter == argsParameter2);
            // </Snippet8>
        }
    }
}
