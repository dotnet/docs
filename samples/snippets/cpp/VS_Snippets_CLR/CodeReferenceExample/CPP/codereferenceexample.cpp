

//<Snippet1>
#using <System.dll>

using namespace System;
using namespace System::CodeDom;

namespace CodeDomSamples
{
   public ref class CodeReferenceExample
   {
   public:
      CodeReferenceExample(){}

      void CodeFieldReferenceExample()
      {
         
         //<Snippet2>
         CodeFieldReferenceExpression^ fieldRef1 = gcnew CodeFieldReferenceExpression( gcnew CodeThisReferenceExpression,"TestField" );
         
         // A C# code generator produces the following source code for the preceeding example code:
         //    this.TestField
         //</Snippet2>
      }

      void CodePropertyReferenceExample()
      {
         
         //<Snippet3>
         CodePropertyReferenceExpression^ propertyRef1 = gcnew CodePropertyReferenceExpression( gcnew CodeThisReferenceExpression,"TestProperty" );
         
         // A C# code generator produces the following source code for the preceeding example code:
         //    this.TestProperty
         //</Snippet3>
      }

      void CodeVariableReferenceExample()
      {
         
         //<Snippet4>
         CodeVariableReferenceExpression^ variableRef1 = gcnew CodeVariableReferenceExpression( "TestVariable" );
         
         // A C# code generator produces the following source code for the preceeding example code:
         //    TestVariable
         //</Snippet4>
      }

   };

}

//</Snippet1>
