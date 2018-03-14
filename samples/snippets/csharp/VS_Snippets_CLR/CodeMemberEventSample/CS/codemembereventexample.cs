//<Snippet1>
using System;
using System.CodeDom;

namespace CodeDomSamples
{
    public class CodeMemberEventExample
    {
        public CodeMemberEventExample()
        {
            //<Snippet2>
            // Declares a type to contain an event and constructor method.
            CodeTypeDeclaration type1 = new CodeTypeDeclaration("EventTest");

            //<Snippet3>
            // Declares an event that accepts a delegate type of System.EventHandler.
            CodeMemberEvent event1 = new CodeMemberEvent();
            // Sets a name for the event.
            event1.Name = "TestEvent";
            // Sets the type of event.
            event1.Type = new CodeTypeReference("System.EventHandler");

            // A C# code generator produces the following source code for the preceeding example code:

            //    private event System.EventHandler TestEvent;
            //</Snippet3>

            // Adds the event to the type members collection.
            type1.Members.Add( event1 );

            // Declares an empty type constructor.
            CodeConstructor constructor1 = new CodeConstructor();
            constructor1.Attributes = MemberAttributes.Public;
            type1.Members.Add( constructor1 );    

            // A C# code generator produces the following source code for the preceeding example code:

            //    public class EventTest 
            //    {
            //        
            //        public EventTest() 
            //        {
            //        }
            //        
            //        private event System.EventHandler TestEvent;
            //    }

            //</Snippet2>
        }
    }
}
//</Snippet1>