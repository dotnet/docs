

//<Snippet1>
#using <System.dll>

using namespace System;
using namespace System::CodeDom;

namespace CodeDomSamples
{
   public ref class CodeVariableDeclarationStatementExample
   {
   public:
      CodeVariableDeclarationStatementExample()
      {
         //<Snippet2>
         // Type of the variable to declare.
         // Name of the variable to declare.
         // Optional initExpression parameter initializes the variable.
         CodeVariableDeclarationStatement^ variableDeclaration = gcnew CodeVariableDeclarationStatement( String::typeid,"TestString",gcnew CodePrimitiveExpression( "Testing" ) );
         
         // A C# code generator produces the following source code for the preceeding example code:
         // string TestString = "Testing";
         //</Snippet2>
      }
   };
}
//</Snippet1>
