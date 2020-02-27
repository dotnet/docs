//<SNIPPET1>
using namespace System;
using namespace System::Runtime::InteropServices;



void main()
{
	// Create an unmanaged c string.
	const char * myString = "Hello managed world (from the unmanaged world)!";

	// Convert the c string to a managed String.
	String ^ myManagedString = Marshal::PtrToStringAnsi((IntPtr) (char *) myString);

	// Display the string to the console.
	Console::WriteLine(myManagedString);
}
//</SNIPPET1>