//<SNIPPET1>

using namespace System;
using namespace System::Runtime::InteropServices;



void main()
{
	// Create an unmanaged byte.
	const char * myString = "bB";

	// Read the second character of the c string as a managed byte.
        Byte ^ myManagedByte = Marshal::ReadByte((IntPtr) (char *) myString, 1);

	// Display the byte to the console.
	Console::WriteLine(myManagedByte);
}
//</SNIPPET1>