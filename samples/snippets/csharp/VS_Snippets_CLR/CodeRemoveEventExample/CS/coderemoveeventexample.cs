//<Snippet1>
using System;
using System.CodeDom;

namespace CodeDomSamples
{
    public class CodeRemoveEventExample
    {
        public CodeRemoveEventExample()
        {
            //<Snippet2>
            // Creates a delegate of type System.EventHandler pointing to a method named OnMouseEnter.
            CodeDelegateCreateExpression mouseEnterDelegate = new CodeDelegateCreateExpression( new CodeTypeReference("System.EventHandler"), new CodeThisReferenceExpression(), "OnMouseEnter" );
            // Creates a remove event statement that removes the delegate from the TestEvent event.
            CodeRemoveEventStatement removeEvent1 = new CodeRemoveEventStatement( new CodeThisReferenceExpression(), "TestEvent", mouseEnterDelegate );
            
            // A C# code generator produces the following source code for the preceeding example code:

            //     this.TestEvent -= new System.EventHandler(this.OnMouseEnter);
            //</Snippet2>
        }
    }
}
//</Snippet1>