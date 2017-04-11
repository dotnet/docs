//<Snippet1>
using System;
using System.CodeDom;

namespace CodeDomSamples
{
    public class CodeReferenceExample
    {
        public CodeReferenceExample()
        {                        
        }

        public void CodeFieldReferenceExample()
        {
            //<Snippet2>
            CodeFieldReferenceExpression fieldRef1 = 
                new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), "TestField");

            // A C# code generator produces the following source code for the preceeding example code:
            
            //    this.TestField
            //</Snippet2>
        }

        public void CodePropertyReferenceExample()
        {
            //<Snippet3>
            CodePropertyReferenceExpression propertyRef1 = 
                new CodePropertyReferenceExpression(new CodeThisReferenceExpression(), "TestProperty");
            
            // A C# code generator produces the following source code for the preceeding example code:

            //    this.TestProperty
            //</Snippet3>
        }

        public void CodeVariableReferenceExample()
        {
            //<Snippet4>
            CodeVariableReferenceExpression variableRef1 =
                new CodeVariableReferenceExpression("TestVariable");
            
            // A C# code generator produces the following source code for the preceeding example code:

            //    TestVariable
            //</Snippet4>
        }
    }
}
//</Snippet1>