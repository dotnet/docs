//<SNIPPET1>
// Remember that the actual size of System.Char in unmanaged memory is 2.
using System;
using System.Runtime.InteropServices;

class Example
{

    static void Main()
    {
        // Create a managed array.
        char[] managedArray = new char[1000];
        managedArray[0] = 'a';
        managedArray[1] = 'b';
        managedArray[2] = 'c';
        managedArray[3] = 'd';
        managedArray[999] = 'Z';

        // Initialize unmanaged memory to hold the array.
        // int size = Marshal.SizeOf(managedArray[0]) * managedArray.Length;  // Incorrect
        int size = Marshal.SystemDefaultCharSize * managedArray.Length;       // Correct


        IntPtr pnt = Marshal.AllocHGlobal(size);

        try
        {
            // Copy the array to unmanaged memory.
            Marshal.Copy(managedArray, 0, pnt, managedArray.Length);

            // Copy the unmanaged array back to another managed array.

            char[] managedArray2 = new char[managedArray.Length];

            Marshal.Copy(pnt, managedArray2, 0, managedArray.Length);
            Console.WriteLine("Here is the roundtripped array: {0} {1} {2} {3} {4}",
                               managedArray2[0], managedArray2[1], managedArray2[2], managedArray2[3],
                               managedArray2[999]);

            Console.WriteLine("The array was copied to unmanaged memory and back.");

        }
        finally
        {
            // Free the unmanaged memory.
            Marshal.FreeHGlobal(pnt);
        }



    }

}
//</SNIPPET1>