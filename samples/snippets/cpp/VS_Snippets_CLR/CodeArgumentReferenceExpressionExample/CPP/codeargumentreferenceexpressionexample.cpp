

//<Snippet1>
#using <System.dll>

using namespace System;
using namespace System::CodeDom;

namespace CodeDomSamples
{
   public ref class CodeArgumentReferenceExpressionExample
   {
   public:
      CodeArgumentReferenceExpressionExample()
      {
         
         //<Snippet2>
         // Declare a method that accepts a string parameter named text.
         CodeMemberMethod^ cmm = gcnew CodeMemberMethod;
         cmm->Parameters->Add( gcnew CodeParameterDeclarationExpression( "String","text" ) );
         cmm->Name = "WriteString";
         cmm->ReturnType = gcnew CodeTypeReference( "System::Void" );
         array<CodeExpression^>^ce = {gcnew CodeArgumentReferenceExpression( "test1" )};
         
         // Create a method invoke statement to output the string passed to the method.
         CodeMethodInvokeExpression^ cmie = gcnew CodeMethodInvokeExpression( gcnew CodeTypeReferenceExpression( "Console" ),"WriteLine",ce );
         
         // Add the method invoke expression to the method's statements collection.
         cmm->Statements->Add( cmie );
         
         // A C++ code generator produces the following source code for the preceeding example code:
         // private:
         //  void WriteString(String text) {
         //       Console::WriteLine(text);
         // }
         //</Snippet2>
      }

   };

}

//</Snippet1>
