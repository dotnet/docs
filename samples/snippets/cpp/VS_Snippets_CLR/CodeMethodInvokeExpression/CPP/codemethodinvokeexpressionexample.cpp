

//<Snippet1>
#using <System.dll>

using namespace System;
using namespace System::CodeDom;

namespace CodeDomSamples
{
   public ref class CodeMethodInvokeExpressionExample
   {
   public:
      CodeMethodInvokeExpressionExample()
      {
         
         //<Snippet2>
         array<CodeExpression^>^temp0 = {gcnew CodePrimitiveExpression( true )};
         
         // parameters array contains the parameters for the method.
         CodeMethodInvokeExpression^ methodInvoke = gcnew CodeMethodInvokeExpression( gcnew CodeThisReferenceExpression,"Dispose",temp0 );
         
         // A C# code generator produces the following source code for the preceeding example code:
         // this.Dispose(true);
         //</Snippet2>
      }

   };

}

//</Snippet1>
