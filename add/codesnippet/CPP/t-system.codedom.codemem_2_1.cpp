         // Declares an event that accepts a delegate type of System.EventHandler.
         CodeMemberEvent^ event1 = gcnew CodeMemberEvent;
         
         // Sets a name for the event.
         event1->Name = "TestEvent";
         
         // Sets the type of event.
         event1->Type = gcnew CodeTypeReference( "System.EventHandler" );
         
         // A C# code generator produces the following source code for the preceeding example code:
         //    private event System.EventHandler TestEvent;