
// <Snippet1>
using namespace System;
using namespace System::Reflection;
int main()
{
   Type^ objType = System::Array::typeid;
   
   // Print the full assembly name.
   Console::WriteLine( "Full assembly name: {0}.", objType->Assembly->FullName );
   
   // Print the qualified assembly name.
   Console::WriteLine( "Qualified assembly name: {0}.", objType->AssemblyQualifiedName );
}
// The example displays the following output if run under the .NET Framework 4.5:
//    Full assembly name:
//       mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089.
//    Qualified assembly name:
//       System.Array, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089.
// </Snippet1>
