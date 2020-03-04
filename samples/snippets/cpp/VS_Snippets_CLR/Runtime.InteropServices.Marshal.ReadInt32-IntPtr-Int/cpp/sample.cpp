//<SNIPPET1>
using namespace System;
using namespace System::Runtime::InteropServices;



void main()
{
    // Create an unmanaged int pointer.
    int * myVal;
    int tmp = 42;
    // Initialize it to another value.
    myVal = &tmp;

    // Read value as a managed Int32.
    Int32 ^ myManagedVal = Marshal::ReadInt32((IntPtr) myVal, 0);

    // Display the value to the console.
    Console::WriteLine(myManagedVal);
}
//</SNIPPET1>