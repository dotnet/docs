//<Snippet1>
using System;
using System.CodeDom;

namespace CodeDomSamples
{
    public class CodeCastExpressionExample
    {
        public CodeCastExpressionExample()
        {
            //<Snippet2>
            // This CodeCastExpression casts an Int32 of 1000 to an Int64.        
            CodeCastExpression castExpression = new CodeCastExpression(
                // targetType parameter indicating the target type of the cast.
                "System.Int64",
                // The CodeExpression to cast, here an Int32 value of 1000.
                new CodePrimitiveExpression(1000) );    

            // A C# code generator produces the following source code for the preceeding example code:

            // ((long)(1000));
            //</Snippet2>
        }
    }
}
//</Snippet1>