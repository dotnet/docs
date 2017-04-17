

//<Snippet1>
#using <System.dll>

using namespace System;
using namespace System::CodeDom;
public ref class CodeBaseReferenceExpressionExample
{
public:
   CodeBaseReferenceExpressionExample()
   {
      
      //<Snippet2>
      // Example method invoke expression uses CodeBaseReferenceExpression to produce
      // a base.Dispose method call
      CodeMethodInvokeExpression^ methodInvokeExpression = 
         gcnew CodeMethodInvokeExpression(              // Creates a method invoke expression
            gcnew CodeBaseReferenceExpression,          // targetObjectparameter can be a base class reference
            "Dispose",gcnew array<CodeExpression^>{} ); // Method name and method parameter arguments
      
      // A C# code generator produces the following source code for the preceeding example code:
      // base.Dispose();
      //</Snippet2>
   }

};

//</Snippet1>
