

//<Snippet1>
#using <System.dll>

using namespace System;
using namespace System::CodeDom;

namespace CodeDomSamples
{
   public ref class CodeConditionStatementExample
   {
   public:
      CodeConditionStatementExample()
      {
         
         //<Snippet2>
         // Create a CodeConditionStatement that tests a boolean value named boolean.
         array<CodeStatement^>^temp0 = {gcnew CodeCommentStatement( "If condition is true, execute these statements." )};
         array<CodeStatement^>^temp1 = {gcnew CodeCommentStatement( "Else block. If condition is false, execute these statements." )};
         
         // The statements to execute if the condition evalues to false.
         CodeConditionStatement^ conditionalStatement = gcnew CodeConditionStatement( gcnew CodeVariableReferenceExpression( "boolean" ),temp0,temp1 );
         
         // A C# code generator produces the following source code for the preceeding example code:
         // if (boolean) 
         // {
         //     // If condition is true, execute these statements.
         // }
         // else {
         //     // Else block. If condition is false, execute these statements.
         // }        
         //</Snippet2>
      }

   };

}

//</Snippet1>
