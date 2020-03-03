//<SNIPPET1>
using namespace System;
using namespace System::Runtime::InteropServices;

int main()
{
    // Create a managed string.
    String^ managedString = "Hello unmanaged world (from the managed world).";

    // Marshal the managed string to unmanaged memory.
    char*  stringPointer = (char*) Marshal::StringToHGlobalAuto(managedString).ToPointer();

    // Pass the string to an unmanaged API.

    // Always free the unmanaged string.
    Marshal::FreeHGlobal(IntPtr(stringPointer));

    return 0;
}
//</SNIPPET1>