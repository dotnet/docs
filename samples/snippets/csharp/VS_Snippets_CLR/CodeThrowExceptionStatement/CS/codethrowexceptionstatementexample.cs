//<Snippet1>
using System;
using System.CodeDom;

namespace CodeDomSamples
{
    public class CodeThrowExceptionStatementExample
    {
        public CodeThrowExceptionStatementExample()
        {
            //<Snippet2>
            // This CodeThrowExceptionStatement throws a new System.Exception.
            CodeThrowExceptionStatement throwException = new CodeThrowExceptionStatement( 
                // codeExpression parameter indicates the exception to throw.
                // You must use an object create expression to new an exception here.
                new CodeObjectCreateExpression(
                // createType parameter inidicates the type of object to create.
                new CodeTypeReference(typeof(System.Exception)),
                // parameters parameter indicates the constructor parameters.
                new CodeExpression[] {} ) );

            // A C# code generator produces the following source code for the preceeding example code:

            // throw new System.Exception();
            //</Snippet2>
        }
    }
}
//</Snippet1>