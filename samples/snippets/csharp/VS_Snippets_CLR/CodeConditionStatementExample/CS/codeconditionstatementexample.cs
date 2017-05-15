//<Snippet1>
using System;
using System.CodeDom;

namespace CodeDomSamples
{
    public class CodeConditionStatementExample
    {
        public CodeConditionStatementExample()
        {
            //<Snippet2>
            // Create a CodeConditionStatement that tests a boolean value named boolean.
            CodeConditionStatement conditionalStatement = new CodeConditionStatement(
                // The condition to test.
                new CodeVariableReferenceExpression("boolean"),
                // The statements to execute if the condition evaluates to true.
                new CodeStatement[] { new CodeCommentStatement("If condition is true, execute these statements.") },
                // The statements to execute if the condition evalues to false.
                new CodeStatement[] { new CodeCommentStatement("Else block. If condition is false, execute these statements.") } );

            // A C# code generator produces the following source code for the preceeding example code:

            // if (boolean) 
            // {
                //     // If condition is true, execute these statements.
            // }
            // else {
            //     // Else block. If condition is false, execute these statements.
                // }        
    
            //</Snippet2>
        }
    }
}
//</Snippet1>