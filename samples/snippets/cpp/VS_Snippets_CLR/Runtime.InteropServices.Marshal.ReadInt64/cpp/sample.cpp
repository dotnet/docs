//<SNIPPET1>
using namespace System;
using namespace System::Runtime::InteropServices;



void main()
{
	// Create an unmanaged __int64.
	__int64 myVal = 42;

	// Read the value as a managed Int64.
    Int64 ^ myManagedVal = Marshal::ReadInt64((IntPtr) &myVal);

	// Display the value to the console.
	Console::WriteLine(myManagedVal);
}
//</SNIPPET1>