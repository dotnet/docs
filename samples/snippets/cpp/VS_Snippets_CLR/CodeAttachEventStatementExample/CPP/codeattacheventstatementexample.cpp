

//<Snippet1>
#using <System.dll>

using namespace System;
using namespace System::CodeDom;

namespace CodeDomSamples
{
   public ref class CodeAttachEventStatementExample
   {
   public:
      CodeAttachEventStatementExample()
      {
         
         //<Snippet2>
         // Declares a type to contain the delegate and constructor method.
         CodeTypeDeclaration^ type1 = gcnew CodeTypeDeclaration( "AttachEventTest" );
         
         // Declares an event that needs no custom event arguments class.
         CodeMemberEvent^ event1 = gcnew CodeMemberEvent;
         event1->Name = "TestEvent";
         event1->Type = gcnew CodeTypeReference( "System.EventHandler" );
         
         // Adds the event to the type members.
         type1->Members->Add( event1 );
         
         // Declares a method that matches the System.EventHandler method signature.
         CodeMemberMethod^ method1 = gcnew CodeMemberMethod;
         method1->Name = "TestMethod";
         method1->Parameters->Add( gcnew CodeParameterDeclarationExpression( "System.Object","sender" ) );
         method1->Parameters->Add( gcnew CodeParameterDeclarationExpression( "System.EventArgs","e" ) );
         
         // Adds the method to the type members.
         type1->Members->Add( method1 );
         
         // Defines a constructor that attaches a TestDelegate delegate pointing to 
         // the TestMethod method to the TestEvent event.
         CodeConstructor^ constructor1 = gcnew CodeConstructor;
         constructor1->Attributes = MemberAttributes::Public;
         
         //<Snippet3>
         // Defines a delegate creation expression that creates an EventHandler delegate pointing to a method named TestMethod.
         CodeDelegateCreateExpression^ createDelegate1 = gcnew CodeDelegateCreateExpression( gcnew CodeTypeReference( "System.EventHandler" ),gcnew CodeThisReferenceExpression,"TestMethod" );
         
         // Attaches an EventHandler delegate pointing to TestMethod to the TestEvent event.
         CodeAttachEventStatement^ attachStatement1 = gcnew CodeAttachEventStatement( gcnew CodeThisReferenceExpression,"TestEvent",createDelegate1 );
         
         // A C# code generator produces the following source code for the preceeding example code:
         //     this.TestEvent += new System.EventHandler(this.TestMethod);
         //</Snippet3>
         // Adds the constructor statements to the construtor.
         constructor1->Statements->Add( attachStatement1 );
         
         // Adds the construtor to the type members.    
         type1->Members->Add( constructor1 );
         
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

   };

}

//</Snippet1>
