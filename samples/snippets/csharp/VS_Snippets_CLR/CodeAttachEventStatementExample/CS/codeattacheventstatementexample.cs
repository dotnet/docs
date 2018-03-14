//<Snippet1>
using System;
using System.CodeDom;

namespace CodeDomSamples
{
    public class CodeAttachEventStatementExample
    {
    public CodeAttachEventStatementExample()
    {
        //<Snippet2>
        // Declares a type to contain the delegate and constructor method.
        CodeTypeDeclaration type1 = new CodeTypeDeclaration("AttachEventTest");

        // Declares an event that needs no custom event arguments class.
        CodeMemberEvent event1 = new CodeMemberEvent();
        event1.Name = "TestEvent";
        event1.Type = new CodeTypeReference("System.EventHandler");
        // Adds the event to the type members.
        type1.Members.Add( event1 );

        // Declares a method that matches the System.EventHandler method signature.
        CodeMemberMethod method1 = new CodeMemberMethod();
        method1.Name = "TestMethod";
        method1.Parameters.Add( new CodeParameterDeclarationExpression("System.Object", "sender") );
        method1.Parameters.Add( new CodeParameterDeclarationExpression("System.EventArgs", "e") );        
        // Adds the method to the type members.
        type1.Members.Add( method1 );

        // Defines a constructor that attaches a TestDelegate delegate pointing to 
        // the TestMethod method to the TestEvent event.
        CodeConstructor constructor1 = new CodeConstructor();
        constructor1.Attributes = MemberAttributes.Public;            

          //<Snippet3>
        // Defines a delegate creation expression that creates an EventHandler delegate pointing to a method named TestMethod.
        CodeDelegateCreateExpression createDelegate1 = new CodeDelegateCreateExpression( 
        new CodeTypeReference( "System.EventHandler" ), new CodeThisReferenceExpression(), "TestMethod" );                                
        // Attaches an EventHandler delegate pointing to TestMethod to the TestEvent event.
        CodeAttachEventStatement attachStatement1 = new CodeAttachEventStatement( new CodeThisReferenceExpression(), "TestEvent", createDelegate1 );

        // A C# code generator produces the following source code for the preceeding example code:

        //     this.TestEvent += new System.EventHandler(this.TestMethod);
        //</Snippet3>

          // Adds the constructor statements to the construtor.
        constructor1.Statements.Add( attachStatement1 );    
        // Adds the construtor to the type members.    
        type1.Members.Add( constructor1 );

        // A C# code generator produces the following source code for the preceeding example code:
            
        //    public class AttachEventTest 
        //    {
        //
        //        public AttachEventTest() 
        //        {
        //            this.TestEvent += new System.EventHandler(this.TestMethod);
        //        }
        //
        //        private event System.EventHandler TestEvent;
        //        
        //        private void TestMethod(object sender, System.EventArgs e) 
        //        {
        //        }
        //    }
        //</Snippet2>
    }
    }
}
//</Snippet1>