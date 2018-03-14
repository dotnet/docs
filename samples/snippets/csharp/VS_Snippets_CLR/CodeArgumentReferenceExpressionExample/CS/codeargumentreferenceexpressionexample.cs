//<Snippet1>
using System;
using System.CodeDom;

namespace CodeDomSamples
{
    public class CodeArgumentReferenceExpressionExample
    {
        public CodeArgumentReferenceExpressionExample()
    {
            //<Snippet2>            
            // Declare a method that accepts a string parameter named text.
            CodeMemberMethod cmm = new CodeMemberMethod();
            cmm.Parameters.Add( new CodeParameterDeclarationExpression("String", "text") );
            cmm.Name = "WriteString";
            cmm.ReturnType = new CodeTypeReference("System.Void");        
                    
            // Create a method invoke statement to output the string passed to the method.
            CodeMethodInvokeExpression cmie = new CodeMethodInvokeExpression( new CodeTypeReferenceExpression("Console"), "WriteLine", new CodeArgumentReferenceExpression("text") );

            // Add the method invoke expression to the method's statements collection.
            cmm.Statements.Add( cmie );
 
            // A C# code generator produces the following source code for the preceeding example code:        
            //        private void WriteString(String text) 
            //        {
            //            Console.WriteLine(text);
            //        }                         
        //</Snippet2>
    }
    }    
}
//</Snippet1>