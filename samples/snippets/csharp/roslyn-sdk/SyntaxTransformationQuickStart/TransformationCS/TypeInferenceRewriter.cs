// <SnippetAddUsings>
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
// </SnippetAddUsings>

namespace TransformationCS
{
    // <SnippetBaseClass>
    public class TypeInferenceRewriter : CSharpSyntaxRewriter
    // </SnippetBaseClass>
    {
        // <SnippetConstruction>
        private readonly SemanticModel SemanticModel;

        public TypeInferenceRewriter(SemanticModel semanticModel) => SemanticModel = semanticModel;
        // </SnippetConstruction>

        // five
        public override SyntaxNode VisitLocalDeclarationStatement(LocalDeclarationStatementSyntax node)
        {
            // <SnippetExclusions>
            if (node.Declaration.Variables.Count > 1)
            {
                return node;
            }
            if (node.Declaration.Variables[0].Initializer == null)
            {
                return node;
            }
            // </SnippetExclusions>

            // <SnippetExtractTypeSymbol>
            var declarator = node.Declaration.Variables.First();
            var variableTypeName = node.Declaration.Type;

            var variableType = (ITypeSymbol)SemanticModel
                .GetSymbolInfo(variableTypeName)
                .Symbol;
            // </SnippetExtractTypeSymbol>

            // <SnippetBindInitializer>
            var initializerInfo = SemanticModel.GetTypeInfo(declarator.Initializer.Value);
            // </SnippetBindInitializer>

            // <SnippetReplaceNode>
            if (SymbolEqualityComparer.Default.Equals(variableType, initializerInfo.Type))
            {
                TypeSyntax varTypeName = SyntaxFactory.IdentifierName("var")
                    .WithLeadingTrivia(variableTypeName.GetLeadingTrivia())
                    .WithTrailingTrivia(variableTypeName.GetTrailingTrivia());

                return node.ReplaceNode(variableTypeName, varTypeName);
            }
            else
            {
                return node;
            }
            // </SnippetReplaceNode>
        }
    }
}
