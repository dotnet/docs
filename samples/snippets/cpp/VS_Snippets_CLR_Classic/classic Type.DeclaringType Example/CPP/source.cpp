
// <Snippet1>
using namespace System;
using namespace System::Reflection;

public ref class dtype abstract
{
public:
   ref class MyClassA abstract
   {
   public:
      virtual int m() = 0;
   };

   ref class MyClassB abstract: public MyClassA{};
};

int main()
{
   Console::WriteLine( "The declaring type of m is {0}.", dtype::MyClassB::typeid->GetMethod( "m" )->DeclaringType );
}
// </Snippet1>
