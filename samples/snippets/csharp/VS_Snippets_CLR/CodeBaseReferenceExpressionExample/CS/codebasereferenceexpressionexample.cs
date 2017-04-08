//<Snippet1>
using System;
using System.CodeDom;

namespace CodeDomSamples
{
    public class CodeBaseReferenceExpressionExample
    {
        public CodeBaseReferenceExpressionExample()
        {
            //<Snippet2>
            // Example method invoke expression uses CodeBaseReferenceExpression to produce 
            // a base.Dispose method call
            CodeMethodInvokeExpression methodInvokeExpression =                 
                
                // Creates a method invoke expression
                new CodeMethodInvokeExpression(
                
                // targetObject parameter can be a 
                // base class reference
                new CodeBaseReferenceExpression(),
                
                // Method name and method parameter arguments
                "Dispose", new CodeExpression[] {});            

            // A C# code generator produces the following source code for the preceeding example code:

            // base.Dispose();

            //</Snippet2>
        }        
    }
}
//</Snippet1>