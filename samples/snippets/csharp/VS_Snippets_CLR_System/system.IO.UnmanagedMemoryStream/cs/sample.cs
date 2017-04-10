//<snippet1>

// Note: you must compile this sample using the unsafe flag.
// From the command line, type the following: csc sample.cs /unsafe

using System;
using System.IO;
using System.Text;
using System.Runtime.InteropServices;

unsafe class TestWriter
{
    
    static void Main()
	{
		
            // Create some data to read and write.
            byte[] message = UnicodeEncoding.Unicode.GetBytes("Here is some data.");

	    // Allocate a block of unmanaged memory and return an IntPtr object.	
            IntPtr memIntPtr = Marshal.AllocHGlobal(message.Length);

            // Get a byte pointer from the IntPtr object.
            byte* memBytePtr = (byte*) memIntPtr.ToPointer();

            // Create an UnmanagedMemoryStream object using a pointer to unmanaged memory.
            UnmanagedMemoryStream writeStream = new UnmanagedMemoryStream(memBytePtr, message.Length, message.Length, FileAccess.Write);

            // Write the data.
            writeStream.Write(message, 0, message.Length);

            // Close the stream.
            writeStream.Close();

            // Create another UnmanagedMemoryStream object using a pointer to unmanaged memory.
            UnmanagedMemoryStream readStream = new UnmanagedMemoryStream(memBytePtr, message.Length, message.Length, FileAccess.Read);

	    // Create a byte array to hold data from unmanaged memory.
            byte[] outMessage = new byte[message.Length];

            // Read from unmanaged memory to the byte array.
            readStream.Read(outMessage, 0, message.Length);

            // Close the stream.
            readStream.Close();

            // Display the data to the console.
            Console.WriteLine(UnicodeEncoding.Unicode.GetString(outMessage));

            // Free the block of unmanaged memory.
            Marshal.FreeHGlobal(memIntPtr);

            Console.ReadLine();
    }
}
//</snippet1>