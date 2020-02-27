//<SNIPPET1>

using namespace System;
using namespace System::Runtime::InteropServices;

void main()
{
    // Create an unmanaged short pointer.
    short * myShort;
    short tmp = 42;
    // Initialize it to another value.
    myShort = &tmp;

    // Read value as a managed Int16.
    Int16 ^ myManagedVal = Marshal::ReadInt16((IntPtr) myShort, 0);

    // Display the value to the console.
    Console::WriteLine(myManagedVal);
}
//</SNIPPET1>