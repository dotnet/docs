//<SNIPPET1>
using namespace System;
using namespace System::Runtime::InteropServices;



void main()
{
	// Create an unmanaged integer.
	int myVal = 42;

	// Read the int as a managed Int32.
        Int32 ^ myManagedVal = Marshal::ReadInt32((IntPtr) &myVal);

	// Display the value to the console.
	Console::WriteLine(myManagedVal);
}
//</SNIPPET1>