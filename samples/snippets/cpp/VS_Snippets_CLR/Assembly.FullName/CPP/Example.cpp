// <Snippet1>
using namespace System;
using namespace System::Reflection;

void main()
{
    Console::WriteLine("The FullName property (also called the display name) of...");
    Console::WriteLine("...the currently executing assembly:");
    Console::WriteLine(Assembly::GetExecutingAssembly()->FullName);

    Console::WriteLine("...the assembly that contains the Int32 type:");
    Console::WriteLine(int::typeid->Assembly->FullName);
}

/* This example produces output similar to the following:

The FullName property (also called the display name) of...
...the currently executing assembly:
ExampleAssembly, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
...the assembly that contains the Int32 type:
mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
 */
//</Snippet1>