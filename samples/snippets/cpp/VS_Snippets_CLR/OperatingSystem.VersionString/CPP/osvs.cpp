
//<snippet1>
// This example demonstrates the VersionString property.
using namespace System;
int main()
{
   OperatingSystem^ os = Environment::OSVersion;
   
   // Display the value of OperatingSystem.VersionString. By default, this is
   // the same value as OperatingSystem.ToString.
   Console::WriteLine( L"This operating system is {0}", os->VersionString );
   return 0;
}

/*
This example produces the following results:

This operating system is Microsoft Windows NT 5.1.2600.0 Service Pack 1
*/
//</snippet1>
