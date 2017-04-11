//<SNIPPET1>

using namespace System;
using namespace System::Runtime::InteropServices;



void main()
{
	// Create an unmanaged short.
	short myShort = 42;

	// Read the short as a managed Int16.
        Int16 ^ myManagedVal = Marshal::ReadInt16((IntPtr) &myShort);

	// Display the value to the console.
	Console::WriteLine(myManagedVal);
}
//</SNIPPET1>