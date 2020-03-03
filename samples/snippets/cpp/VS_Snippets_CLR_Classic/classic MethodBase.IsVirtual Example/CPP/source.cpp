
// <Snippet1>
using namespace System;
using namespace System::Reflection;

public ref class MyClass
{
public:
   void MyMethod(){}
};

int main()
{
   MethodBase^ m = MyClass::typeid->GetMethod( "MyMethod" );
   Console::WriteLine( "The IsFinal property value of MyMethod is {0}.", m->IsFinal );
   Console::WriteLine( "The IsVirtual property value of MyMethod is {0}.", m->IsVirtual );
}
// </Snippet1>
