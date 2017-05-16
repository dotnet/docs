

//<Snippet1>
#using <System.dll>

using namespace System;
using namespace System::CodeDom;

public ref class CodeThrowExceptionStatementExample
{
public:
   CodeThrowExceptionStatementExample()
   {
      //<Snippet2>
      // This CodeThrowExceptionStatement throws a new System.Exception.
      array<CodeExpression^>^temp0;
      CodeThrowExceptionStatement^ throwException = gcnew CodeThrowExceptionStatement( gcnew CodeObjectCreateExpression( gcnew CodeTypeReference( System::Exception::typeid ),temp0 ) );

      // A C# code generator produces the following source code for the preceeding example code:
      // throw new System.Exception();
      //</Snippet2>
   }
};
//</Snippet1>
