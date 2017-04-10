//<Snippet1>
using System;
using System.CodeDom;

namespace CodeDomSamples
{
    public class CodeDelegateInvokeExpressionExample
    {
        public CodeDelegateInvokeExpressionExample()
        {
            //<Snippet2>

            // Declares a type to contain the delegate and constructor method.
            CodeTypeDeclaration type1 = new CodeTypeDeclaration("DelegateInvokeTest");

            // Declares an event that accepts a custom delegate type of "TestDelegate".
            CodeMemberEvent event1 = new CodeMemberEvent();
            event1.Name = "TestEvent";
            event1.Type = new CodeTypeReference("DelegateInvokeTest.TestDelegate");
            type1.Members.Add( event1 );

            // Declares a delegate type called TestDelegate with an EventArgs parameter.
            CodeTypeDelegate delegate1 = new CodeTypeDelegate("TestDelegate");            
            delegate1.Parameters.Add( new CodeParameterDeclarationExpression("System.Object", "sender") );
            delegate1.Parameters.Add( new CodeParameterDeclarationExpression("System.EventArgs", "e") );        
            type1.Members.Add( delegate1 );

            // Declares a method that matches the "TestDelegate" method signature.
            CodeMemberMethod method1 = new CodeMemberMethod();
            method1.Name = "TestMethod";
            method1.Parameters.Add( new CodeParameterDeclarationExpression("System.Object", "sender") );
            method1.Parameters.Add( new CodeParameterDeclarationExpression("System.EventArgs", "e") );        
            type1.Members.Add( method1 );

            // Defines a constructor that attaches a TestDelegate delegate pointing to the TestMethod method
            // to the TestEvent event.
            CodeConstructor constructor1 = new CodeConstructor();
            constructor1.Attributes = MemberAttributes.Public;            

            constructor1.Statements.Add( new CodeCommentStatement("Attaches a delegate to the TestEvent event.") );

            // Creates and attaches a delegate to the TestEvent.
            CodeDelegateCreateExpression createDelegate1 = new CodeDelegateCreateExpression( 
                new CodeTypeReference( "DelegateInvokeTest.TestDelegate" ), new CodeThisReferenceExpression(), "TestMethod" );                                
            CodeAttachEventStatement attachStatement1 = new CodeAttachEventStatement( new CodeThisReferenceExpression(), "TestEvent", createDelegate1 );            
            constructor1.Statements.Add( attachStatement1 );                    

            constructor1.Statements.Add( new CodeCommentStatement("Invokes the TestEvent event.") );

            // Invokes the TestEvent.
            CodeDelegateInvokeExpression invoke1 = new CodeDelegateInvokeExpression( new CodeEventReferenceExpression(new CodeThisReferenceExpression(), "TestEvent"), 
                new CodeExpression[] { new CodeThisReferenceExpression(), new CodeObjectCreateExpression("System.EventArgs") } );
            constructor1.Statements.Add( invoke1 );
            
            type1.Members.Add( constructor1 );

            // A C# code generator produces the following source code for the preceeding example code:

            //    public class DelegateInvokeTest 
            //    {
            //        
            //        public DelegateInvokeTest() 
            //        {
            //            // Attaches a delegate to the TestEvent event.                        
            //            this.TestEvent += new DelegateInvokeTest.TestDelegate(this.TestMethod);
            //            // Invokes the TestEvent event.
            //            this.TestEvent(this, new System.EventArgs());
            //        }
            //        
            //        private event DelegateInvokeTest.TestDelegate TestEvent;
            //        
            //        private void TestMethod(object sender, System.EventArgs e) 
            //        {
            //        }            
            //    
            //        public delegate void TestDelegate(object sender, System.EventArgs e);
            //    }
            //</Snippet2>
        }

        public void DelegateInvokeOnlyType()
        {            
            //<Snippet3>
            // Invokes the delegates for an event named TestEvent, passing a local object reference and a new System.EventArgs.
            CodeDelegateInvokeExpression invoke1 = new CodeDelegateInvokeExpression( new CodeEventReferenceExpression(new CodeThisReferenceExpression(), "TestEvent"), 
                new CodeExpression[] { new CodeThisReferenceExpression(), new CodeObjectCreateExpression("System.EventArgs") } );
            
            // A C# code generator produces the following source code for the preceeding example code:

            //    this.TestEvent(this, new System.EventArgs());
            //</Snippet3>            
        }
    }
}
//</Snippet1>