         // Defines a delegate creation expression that creates an EventHandler delegate pointing to a method named TestMethod.
         CodeDelegateCreateExpression^ createDelegate1 = gcnew CodeDelegateCreateExpression( gcnew CodeTypeReference( "System.EventHandler" ),gcnew CodeThisReferenceExpression,"TestMethod" );
         
         // Attaches an EventHandler delegate pointing to TestMethod to the TestEvent event.
         CodeAttachEventStatement^ attachStatement1 = gcnew CodeAttachEventStatement( gcnew CodeThisReferenceExpression,"TestEvent",createDelegate1 );
         
         // A C# code generator produces the following source code for the preceeding example code:
         //     this.TestEvent += new System.EventHandler(this.TestMethod);