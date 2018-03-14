//<Snippet1>
using System;
using System.CodeDom;

namespace CodeDomSamples
{
    public class CodePrimitiveExpressionExample
    {
        public CodePrimitiveExpressionExample()
        {
            //<Snippet2>
            // Represents a string.
            CodePrimitiveExpression stringPrimitive = new CodePrimitiveExpression("Test String");
            // Represents an integer.
            CodePrimitiveExpression intPrimitive = new CodePrimitiveExpression(10);
            // Represents a floating point number.
            CodePrimitiveExpression floatPrimitive = new CodePrimitiveExpression(1.03189);
            // Represents a null value expression.
            CodePrimitiveExpression nullPrimitive = new CodePrimitiveExpression(null);            
            //</Snippet2>
        }
    }
}
//</Snippet1>