

//<Snippet1>
#using <System.dll>

using namespace System;
using namespace System::CodeDom;

namespace CodeDomSamples
{
   public ref class CodeRemoveEventExample
   {
   public:
      CodeRemoveEventExample()
      {
         
         //<Snippet2>
         // Creates a delegate of type System.EventHandler pointing to a method named OnMouseEnter.
         CodeDelegateCreateExpression^ mouseEnterDelegate = gcnew CodeDelegateCreateExpression( gcnew CodeTypeReference( "System.EventHandler" ),gcnew CodeThisReferenceExpression,"OnMouseEnter" );
         
         // Creates a remove event statement that removes the delegate from the TestEvent event.
         CodeRemoveEventStatement^ removeEvent1 = gcnew CodeRemoveEventStatement( gcnew CodeThisReferenceExpression,"TestEvent",mouseEnterDelegate );
         
         // A C# code generator produces the following source code for the preceeding example code:
         //     this.TestEvent -= new System.EventHandler(this.OnMouseEnter);
         //</Snippet2>
      }

   };

}

//</Snippet1>
