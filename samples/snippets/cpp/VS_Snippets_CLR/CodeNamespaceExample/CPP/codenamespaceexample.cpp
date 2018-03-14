

//<Snippet1>
#using <System.dll>

using namespace System;
using namespace System::CodeDom;

namespace CodeDomSamples
{
   public ref class CodeMemberEventExample
   {
   public:
      CodeMemberEventExample()
      {
         
         //<Snippet2>
         CodeCompileUnit^ compileUnit = gcnew CodeCompileUnit;
         CodeNamespace^ namespace1 = gcnew CodeNamespace( "TestNamespace" );
         compileUnit->Namespaces->Add( namespace1 );
         
         // A C# code generator produces the following source code for the preceeding example code:
         //     namespace TestNamespace {    
         //     }
         //</Snippet2>
      }

   };

}

//</Snippet1>
