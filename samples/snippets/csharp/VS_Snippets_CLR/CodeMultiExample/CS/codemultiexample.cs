//<Snippet1>
using System;
using System.CodeDom;

namespace CodeDomSamples
{

    public class CodeMultiExample
    {
        public CodeMultiExample()
        {            
        }
        
        public void CodeEventReferenceExample()
        {
            //<Snippet2>
            // Represents a reference to an event.
            CodeEventReferenceExpression eventRef1 = new CodeEventReferenceExpression( new CodeThisReferenceExpression(), "TestEvent" );

            // A C# code generator produces the following source code for the preceeding example code:
            
            //        this.TestEvent
            //</Snippet2>
        }

        public void CodeIndexerExample()
        {
            //<Snippet3>                        
            System.CodeDom.CodeIndexerExpression indexerExpression = new CodeIndexerExpression( new CodeThisReferenceExpression(), new CodePrimitiveExpression(1) );

            // A C# code generator produces the following source code for the preceeding example code:
            
            //        this[1];        
            //</Snippet3>
        }

        public void CodeDirectionExample()
        {
            //<Snippet4>            
            // Declares a parameter passed by reference using a CodeDirectionExpression.
            CodeDirectionExpression param1 = new CodeDirectionExpression(FieldDirection.Ref, new CodeFieldReferenceExpression( new CodeThisReferenceExpression(), "TestParameter" ));
            // Invokes a method on this named TestMethod using the direction expression as a parameter.
            CodeMethodInvokeExpression methodInvoke1 = new CodeMethodInvokeExpression(new CodeThisReferenceExpression(), "TestMethod", param1 );
            
            // A C# code generator produces the following source code for the preceeding example code:    
            
            //        this.TestMethod(ref TestParameter);
            //</Snippet4>            
        }

        public void CreateExpressionExample()
        {
            //<Snippet5>
            CodeObjectCreateExpression objectCreate1 = new CodeObjectCreateExpression( "System.DateTime", new CodeExpression[] {} );            

            // A C# code generator produces the following source code for the preceeding example code:    

            //        new System.DateTime();
            //</Snippet5>
        }
    }
}
//</Snippet1>