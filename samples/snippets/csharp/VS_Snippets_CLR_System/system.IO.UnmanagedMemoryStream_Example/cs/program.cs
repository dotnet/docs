//<snippet00>
// Note: You must compile this sample using the unsafe flag.
// From the command line, type the following: csc sample.cs /unsafe
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

unsafe class Program
{
    static void Main()
    {
        // Create some data to write.
        byte[] text = UnicodeEncoding.Unicode.GetBytes("Data to write.");

        // Allocate a block of unmanaged memory.
        IntPtr memIntPtr = Marshal.AllocHGlobal(text.Length);

        // Get a byte pointer from the unmanaged memory block.
        byte* memBytePtr = (byte*)memIntPtr.ToPointer();

        UnmanagedMemoryStream writeStream =
            new UnmanagedMemoryStream(
            memBytePtr, text.Length, text.Length, FileAccess.Write);

        // Write the data.
        WriteToStream(writeStream, text);

        // Close the stream.
        writeStream.Close();

        // Create another UnmanagedMemoryStream for reading.
        UnmanagedMemoryStream readStream =
            new UnmanagedMemoryStream(memBytePtr, text.Length);

        // Display the contents of the stream to the console.
        PrintStream(readStream);

        // Close the reading stream.
        readStream.Close();

        // Free up the unmanaged memory.
        Marshal.FreeHGlobal(memIntPtr);

    }

    //<snippet01>
    public static void WriteToStream(UnmanagedMemoryStream writeStream, byte[] text)
    {
        // Verify that the stream is writable:
        // By default, UnmanagedMemoryStream objects do not have write access,
        // write access must be set explicitly.
        if (writeStream.CanWrite)
        {
            // Write the data, byte by byte
            for (int i = 0; i < writeStream.Length; i++)
            {
                writeStream.WriteByte(text[i]);
            }
        }
    }
    //</snippet01>

    //<snippet02>
    public static void PrintStream(UnmanagedMemoryStream readStream)
    {
        byte[] text = new byte[readStream.Length];
        // Verify that the stream is writable:
        // By default, UnmanagedMemoryStream objects do not have write access,
        // write access must be set explicitly.
        if (readStream.CanRead)
        {
            // Write the data, byte by byte
            for (int i = 0; i < readStream.Length; i++)
            {
                text[i] = (byte)readStream.ReadByte();
            }
        }

        Console.WriteLine(UnicodeEncoding.Unicode.GetString(text));
    }
    //</snippet02>
}
//</snippet00>