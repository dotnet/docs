
//<snippet1>
// Sample for the Environment::GetFolderPath method
using namespace System;
int main()
{
   Console::WriteLine();
   Console::WriteLine( "GetFolderPath: {0}", Environment::GetFolderPath( Environment::SpecialFolder::System ) );
}

/*
This example produces the following results:

GetFolderPath: C:\WINNT\System32
*/
//</snippet1>
