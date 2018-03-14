//<SNIPPET1>
using namespace System;
using namespace System::Runtime::InteropServices;

#include <iostream>                                                 // for printf


int main()
{
    // Create a managed string.
    String^ managedString = "Hello unmanaged world (from the managed world).";

    // Marshal the managed string to unmanaged memory.
    char* stringPointer = (char*) Marshal::StringToHGlobalAnsi(managedString ).ToPointer();

    printf("stringPointer = %s\n", stringPointer);

    // Always free the unmanaged string.
    Marshal::FreeHGlobal(IntPtr(stringPointer));

    return 0;
}
//</SNIPPET1>