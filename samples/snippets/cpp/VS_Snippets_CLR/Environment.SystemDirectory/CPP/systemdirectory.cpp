
//<snippet1>
// Sample for the Environment::SystemDirectory property
using namespace System;
int main()
{
   Console::WriteLine();
   
   //  <-- Keep this information secure! -->
   Console::WriteLine( "SystemDirectory: {0}", Environment::SystemDirectory );
}

/*
This example produces the following results:

SystemDirectory: C:\WINNT\System32
*/
//</snippet1>
