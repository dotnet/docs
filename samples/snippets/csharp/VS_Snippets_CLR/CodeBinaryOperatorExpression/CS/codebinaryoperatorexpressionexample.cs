//<Snippet1>
using System;
using System.CodeDom;

namespace CodeDomSamples
{
    public class CodeBinaryOperatorExpressionExample
    {
        public CodeBinaryOperatorExpressionExample()
        {
            //<Snippet2>
            // This CodeBinaryOperatorExpression represents the addition of 1 and 2.
            CodeBinaryOperatorExpression addMethod = new CodeBinaryOperatorExpression(
                
                // Left operand.
                new CodePrimitiveExpression(1),
                
                // CodeBinaryOperatorType enumeration value of Add.
                CodeBinaryOperatorType.Add,
                
                // Right operand.
                new CodePrimitiveExpression(2) );    

            // A C# code generator produces the following source code for the preceeding example code:

            // (1 + 2)        

            //</Snippet2>
        }
    }
}
//</Snippet1>