//<SNIPPET1>

using namespace System;
using namespace System::Runtime::InteropServices;



void main()
{
    // Create an unmanaged __int64 pointer.
    __int64 * myVal;
    __int64 tmp = 42;
    // Initialize it to another value.
    myVal = &tmp;

    // Read value as a managed Int64.
    Int64 ^ myManagedVal = Marshal::ReadInt64((IntPtr) myVal, 0);

    // Display the value to the console.
    Console::WriteLine(myManagedVal);
}
//</SNIPPET1>