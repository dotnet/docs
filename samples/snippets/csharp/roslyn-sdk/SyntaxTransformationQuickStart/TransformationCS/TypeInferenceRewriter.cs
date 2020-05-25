// <SnippetAddUsings>
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
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
            VariableDeclaratorSyntax declarator = node.Declaration.Variables.First();
            TypeSyntax variableTypeName = node.Declaration.Type;

            ITypeSymbol variableType = (ITypeSymbol)SemanticModel
                .GetSymbolInfo(variableTypeName)
                .Symbol;
            // </SnippetExtractTypeSymbol>

            // <SnippetBindInitializer>
            TypeInfo initializerInfo = SemanticModel.GetTypeInfo(declarator.Initializer.Value);
            // </SnippetBindInitializer>

            // <SnippetReplaceNode>
            if (variableType == initializerInfo.Type)
            {
                TypeSyntax varTypeName = IdentifierName("var")
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
