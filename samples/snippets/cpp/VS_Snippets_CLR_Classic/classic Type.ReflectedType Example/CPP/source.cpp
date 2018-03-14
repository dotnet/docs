
// <Snippet1>
using namespace System;
using namespace System::Reflection;

public ref class MyClassA abstract
{
public:
   ref class MyClassB abstract
   {

   };

};

int main()
{
   Console::WriteLine( "Reflected type of MyClassB is {0}", MyClassA::MyClassB::typeid->ReflectedType );
   //Outputs MyClassA, the enclosing type.
}
// </Snippet1>
