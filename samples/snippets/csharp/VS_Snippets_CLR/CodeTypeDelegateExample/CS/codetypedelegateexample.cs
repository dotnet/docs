//<Snippet1>
using System;
using System.CodeDom;

namespace CodeDomSamples
{
    public class CodeTypeDelegateExample
    {
        public CodeTypeDelegateExample()
        {
            //<Snippet2>

            // Declares a type to contain the delegate and constructor method.
            CodeTypeDeclaration type1 = new CodeTypeDeclaration("DelegateTest");

            // Declares an event that accepts a custom delegate type of "TestDelegate".
            CodeMemberEvent event1 = new CodeMemberEvent();
            event1.Name = "TestEvent";
            event1.Type = new CodeTypeReference("DelegateTest.TestDelegate");
            type1.Members.Add( event1 );

            //<Snippet3>
            // Declares a delegate type called TestDelegate with an EventArgs parameter.
            CodeTypeDelegate delegate1 = new CodeTypeDelegate("TestDelegate");            
            delegate1.Parameters.Add( new CodeParameterDeclarationExpression("System.Object", "sender") );
            delegate1.Parameters.Add( new CodeParameterDeclarationExpression("System.EventArgs", "e") );        

            // A C# code generator produces the following source code for the preceeding example code:

            //     public delegate void TestDelegate(object sender, System.EventArgs e);
            //</Snippet3>
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
            CodeDelegateCreateExpression createDelegate1 = new CodeDelegateCreateExpression( 
                new CodeTypeReference( "DelegateTest.TestDelegate" ), new CodeThisReferenceExpression(), "TestMethod" );                                
            CodeAttachEventStatement attachStatement1 = new CodeAttachEventStatement( new CodeThisReferenceExpression(), "TestEvent", createDelegate1 );
            constructor1.Statements.Add( attachStatement1 );                    
            type1.Members.Add( constructor1 );    

            // A C# code generator produces the following source code for the preceeding example code:
            
            //    public class DelegateTest 
            //    {
            //
            //        public DelegateTest() 
            //        {
            //            this.TestEvent += new DelegateTest.TestDelegate(this.TestMethod);
            //        }
            //        
            //        private event DelegateTest.TestDelegate TestEvent;
            //
            //        private void TestMethod(object sender, System.EventArgs e) 
            //        {
            //        }
            //
            //        public delegate void TestDelegate(object sender, System.EventArgs e);
            //    }

            //</Snippet2>
        }        
    }
}
//</Snippet1>