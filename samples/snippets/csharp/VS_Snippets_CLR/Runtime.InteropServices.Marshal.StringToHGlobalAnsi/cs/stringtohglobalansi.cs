//<SNIPPET1>
using System;
using System.Runtime.InteropServices;

class MainFunction
{
    static void Main()
    {
    Console.WriteLine("\nStringToGlobalAnsi\n");

    // Create a managed string.
    String  managedString = "I am a managed String";
    Console.WriteLine("1) managedString = " + managedString );

    // Marshal the managed string to unmanaged memory.
    IntPtr stringPointer = (IntPtr)Marshal.StringToHGlobalAnsi(managedString);
    Console.WriteLine("2) stringPointer = {0}", stringPointer );

    // Get the string back from unmanaged memory
    String RetrievedString = Marshal.PtrToStringAnsi( stringPointer);
    Console.WriteLine("3) Retrieved from unmanaged memory = " + RetrievedString );

    // Always free the unmanaged string.
    Marshal.FreeHGlobal(stringPointer);

    // IntPtr handle value is still the same:
    Console.WriteLine("4) stringPointer = " + stringPointer );

    // However, it contains no data after being freed:
    String RetrievedString2 = Marshal.PtrToStringAnsi( stringPointer);
    Console.WriteLine("5) RetrievedString2 = " + RetrievedString2 );
    }
}
//</SNIPPET1>