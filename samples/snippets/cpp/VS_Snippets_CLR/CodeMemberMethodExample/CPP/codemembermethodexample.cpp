

//<Snippet1>
#using <System.dll>

using namespace System;
using namespace System::CodeDom;

namespace CodeDomSamples
{
   public ref class CodeMemberMethodExample
   {
   public:
      CodeMemberMethodExample()
      {
         
         //<Snippet2>
         // Defines a method that returns a string passed to it.
         CodeMemberMethod^ method1 = gcnew CodeMemberMethod;
         method1->Name = "ReturnString";
         method1->ReturnType = gcnew CodeTypeReference( "System.String" );
         method1->Parameters->Add( gcnew CodeParameterDeclarationExpression( "System.String","text" ) );
         method1->Statements->Add( gcnew CodeMethodReturnStatement( gcnew CodeArgumentReferenceExpression( "text" ) ) );
         
         // A C# code generator produces the following source code for the preceeding example code:
         //    private string ReturnString(string text) 
         //    {
         //        return text;
         //    }
         //</Snippet2>
      }

   };

}

//</Snippet1>
