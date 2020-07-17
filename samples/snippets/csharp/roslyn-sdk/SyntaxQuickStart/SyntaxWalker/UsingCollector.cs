using static System.Console;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Generic;

namespace SyntaxWalker
{
    // <Snippet3>
    class UsingCollector : CSharpSyntaxWalker
    // </Snippet3>
    {
        // <Snippet4>
        public ICollection<UsingDirectiveSyntax> Usings { get; } = new List<UsingDirectiveSyntax>();
        // </Snippet4>

        // <SNippet5>
        public override void VisitUsingDirective(UsingDirectiveSyntax node)
        {
            WriteLine($"\tVisitUsingDirective called with {node.Name}.");
            if (node.Name.ToString() != "System" &&
                !node.Name.ToString().StartsWith("System."))
            {
                WriteLine($"\t\tSuccess. Adding {node.Name}.");
                this.Usings.Add(node);
            }
        }
        // </Snippet5>
    }
}
