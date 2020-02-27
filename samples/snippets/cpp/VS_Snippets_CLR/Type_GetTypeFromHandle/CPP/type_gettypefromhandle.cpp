// System::Type::GetTypeFromHandle(RuntimeTypeHandle)

/*
The following example demonstrates the 'GetTypeFromHandle(RuntimeTypeHandle)' method
of the 'Type' Class.
It defines an empty class 'Myclass1' and obtains an object of 'Myclass1'. Then the runtime handle of
the object is obtained and passed as an argument to 'GetTypeFromHandle(RuntimeTypeHandle)'method. That
returns the type referenced by the specified type handle.
*/

using namespace System;
using namespace System::Reflection;
public ref class MyClass1{};

int main()
{
   // <Snippet1>
   MyClass1^ myClass1 = gcnew MyClass1;
   // Get the type referenced by the specified type handle.
   Type^ myClass1Type = Type::GetTypeFromHandle( Type::GetTypeHandle( myClass1 ) );
   Console::WriteLine( "The Names of the Attributes : {0}", myClass1Type->Attributes );
   // </Snippet1>
}
