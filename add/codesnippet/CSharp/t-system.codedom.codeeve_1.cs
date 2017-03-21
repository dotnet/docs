            // Represents a reference to an event.
            CodeEventReferenceExpression eventRef1 = new CodeEventReferenceExpression( new CodeThisReferenceExpression(), "TestEvent" );

            // A C# code generator produces the following source code for the preceeding example code:
            
            //        this.TestEvent