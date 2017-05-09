
// <Snippet1>
using namespace System;
using namespace System::Reflection;
int main()
{
   Module^ mod = Assembly::GetExecutingAssembly()->GetModules()[ 0 ];
   Console::WriteLine( "Module Name is {0}", mod->Name );
   Console::WriteLine( "Module FullyQualifiedName is {0}", mod->FullyQualifiedName );
   Console::WriteLine( "Module ScopeName is {0}", mod->ScopeName );
}

/*
Produces this output:
Module Name is modname.exe
Module FullyQualifiedName is C:\Bin\modname.exe
Module ScopeName is modname.exe
*/
// </Snippet1>
