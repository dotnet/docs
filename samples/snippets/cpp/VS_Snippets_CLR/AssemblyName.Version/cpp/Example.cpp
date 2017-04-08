//<Snippet1>
using namespace System;
using namespace System::Reflection;

[assembly:AssemblyVersion("1.1.0.0")];

void main()
{
    Console::WriteLine("The version of the currently executing assembly is: {0}",
        Assembly::GetExecutingAssembly()->GetName()->Version);

    Console::WriteLine("The version of mscorlib.dll is: {0}",
        String::typeid->Assembly->GetName()->Version);
}

/* This example produces output similar to the following:

The version of the currently executing assembly is: 1.1.0.0
The version of mscorlib.dll is: 2.0.0.0
 */
//</Snippet1>
