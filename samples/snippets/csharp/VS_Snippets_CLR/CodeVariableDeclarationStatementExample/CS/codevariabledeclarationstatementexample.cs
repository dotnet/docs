//<Snippet1>
using System;
using System.CodeDom;

namespace CodeDomSamples
{
    public class CodeVariableDeclarationStatementExample
    {
        public CodeVariableDeclarationStatementExample()
        {
            //<Snippet2>
            CodeVariableDeclarationStatement variableDeclaration = new CodeVariableDeclarationStatement(
                // Type of the variable to declare.
                typeof(string),
                // Name of the variable to declare.
                "TestString",
                // Optional initExpression parameter initializes the variable.
                new CodePrimitiveExpression("Testing") );

            // A C# code generator produces the following source code for the preceeding example code:

            // string TestString = "Testing";
            //</Snippet2>
    
        }
    }
}
//</Snippet1>