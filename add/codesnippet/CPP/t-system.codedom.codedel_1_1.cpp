         // Invokes the delegates for an event named TestEvent, passing a local object reference and a new System.EventArgs.
         array<CodeExpression^>^temp1 = {gcnew CodeThisReferenceExpression,gcnew CodeObjectCreateExpression( "System.EventArgs", nullptr )};
         CodeDelegateInvokeExpression^ invoke1 = gcnew CodeDelegateInvokeExpression( gcnew CodeEventReferenceExpression( gcnew CodeThisReferenceExpression,"TestEvent" ),temp1 );
         
         // A C# code generator produces the following source code for the preceeding example code:
         //    this.TestEvent(this, new System.EventArgs());