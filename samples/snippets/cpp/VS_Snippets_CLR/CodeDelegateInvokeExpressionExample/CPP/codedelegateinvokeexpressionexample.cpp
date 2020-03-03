

//<Snippet1>
#using <System.dll>

using namespace System;
using namespace System::CodeDom;

namespace CodeDomSamples
{
   public ref class CodeDelegateInvokeExpressionExample
   {
   public:
      CodeDelegateInvokeExpressionExample()
      {
         
         //<Snippet2>
         // Declares a type to contain the delegate and constructor method.
         CodeTypeDeclaration^ type1 = gcnew CodeTypeDeclaration( "DelegateInvokeTest" );
         
         // Declares an event that accepts a custom delegate type of "TestDelegate".
         CodeMemberEvent^ event1 = gcnew CodeMemberEvent;
         event1->Name = "TestEvent";
         event1->Type = gcnew CodeTypeReference( "DelegateInvokeTest.TestDelegate" );
         type1->Members->Add( event1 );
         
         // Declares a delegate type called TestDelegate with an EventArgs parameter.
         CodeTypeDelegate^ delegate1 = gcnew CodeTypeDelegate( "TestDelegate" );
         delegate1->Parameters->Add( gcnew CodeParameterDeclarationExpression( "System.Object","sender" ) );
         delegate1->Parameters->Add( gcnew CodeParameterDeclarationExpression( "System.EventArgs","e" ) );
         type1->Members->Add( delegate1 );
         
         // Declares a method that matches the "TestDelegate" method signature.
         CodeMemberMethod^ method1 = gcnew CodeMemberMethod;
         method1->Name = "TestMethod";
         method1->Parameters->Add( gcnew CodeParameterDeclarationExpression( "System.Object","sender" ) );
         method1->Parameters->Add( gcnew CodeParameterDeclarationExpression( "System.EventArgs","e" ) );
         type1->Members->Add( method1 );
         
         // Defines a constructor that attaches a TestDelegate delegate pointing to the TestMethod method
         // to the TestEvent event.
         CodeConstructor^ constructor1 = gcnew CodeConstructor;
         constructor1->Attributes = MemberAttributes::Public;
         constructor1->Statements->Add( gcnew CodeCommentStatement( "Attaches a delegate to the TestEvent event." ) );
         
         // Creates and attaches a delegate to the TestEvent.
         CodeDelegateCreateExpression^ createDelegate1 = gcnew CodeDelegateCreateExpression( gcnew CodeTypeReference( "DelegateInvokeTest.TestDelegate" ),gcnew CodeThisReferenceExpression,"TestMethod" );
         CodeAttachEventStatement^ attachStatement1 = gcnew CodeAttachEventStatement( gcnew CodeThisReferenceExpression,"TestEvent",createDelegate1 );
         constructor1->Statements->Add( attachStatement1 );
         constructor1->Statements->Add( gcnew CodeCommentStatement( "Invokes the TestEvent event." ) );
         
         // Invokes the TestEvent.
         array<CodeExpression^>^temp0 = {gcnew CodeThisReferenceExpression,gcnew CodeObjectCreateExpression( "System.EventArgs", nullptr )};
         CodeDelegateInvokeExpression^ invoke1 = gcnew CodeDelegateInvokeExpression( gcnew CodeEventReferenceExpression( gcnew CodeThisReferenceExpression,"TestEvent" ),temp0 );
         constructor1->Statements->Add( invoke1 );
         type1->Members->Add( constructor1 );
         
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

      void DelegateInvokeOnlyType()
      {
         
         //<Snippet3>
         // Invokes the delegates for an event named TestEvent, passing a local object reference and a new System.EventArgs.
         array<CodeExpression^>^temp1 = {gcnew CodeThisReferenceExpression,gcnew CodeObjectCreateExpression( "System.EventArgs", nullptr )};
         CodeDelegateInvokeExpression^ invoke1 = gcnew CodeDelegateInvokeExpression( gcnew CodeEventReferenceExpression( gcnew CodeThisReferenceExpression,"TestEvent" ),temp1 );
         
         // A C# code generator produces the following source code for the preceeding example code:
         //    this.TestEvent(this, new System.EventArgs());
         //</Snippet3>            
      }

   };

}

//</Snippet1>
