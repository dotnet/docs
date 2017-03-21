            // Invokes the delegates for an event named TestEvent, passing a local object reference and a new System.EventArgs.
            CodeDelegateInvokeExpression invoke1 = new CodeDelegateInvokeExpression( new CodeEventReferenceExpression(new CodeThisReferenceExpression(), "TestEvent"), 
                new CodeExpression[] { new CodeThisReferenceExpression(), new CodeObjectCreateExpression("System.EventArgs") } );
            
            // A C# code generator produces the following source code for the preceeding example code:

            //    this.TestEvent(this, new System.EventArgs());