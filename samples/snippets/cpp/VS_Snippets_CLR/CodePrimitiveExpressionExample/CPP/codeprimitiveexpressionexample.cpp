

//<Snippet1>
#using <System.dll>

using namespace System;
using namespace System::CodeDom;

namespace CodeDomSamples
{
   public ref class CodePrimitiveExpressionExample
   {
   public:
      CodePrimitiveExpressionExample()
      {
         
         //<Snippet2>
         // Represents a string.
         CodePrimitiveExpression^ stringPrimitive = gcnew CodePrimitiveExpression( "Test String" );
         
         // Represents an integer.
         CodePrimitiveExpression^ intPrimitive = gcnew CodePrimitiveExpression( 10 );
         
         // Represents a floating point number.
         CodePrimitiveExpression^ floatPrimitive = gcnew CodePrimitiveExpression( 1.03189 );
         
         // Represents a null value expression.
         CodePrimitiveExpression^ nullPrimitive = gcnew CodePrimitiveExpression( 0 );
         
         //</Snippet2>
      }

   };

}

//</Snippet1>
