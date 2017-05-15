//<snippet1>
using System;
using System.Runtime.InteropServices;

 class Example
 {
     static void Main(string[] args)
     {
          // Allocate 1 byte of unmanaged memory.
          IntPtr hGlobal = Marshal.AllocHGlobal(1);

          // Create a new byte.
          byte b = 1;
          Console.WriteLine("Byte written to unmanaged memory: " + b);

          // Write the byte to unmanaged memory.
          Marshal.WriteByte(hGlobal, b);

          // Read byte from unmanaged memory.
          byte c = Marshal.ReadByte(hGlobal);
          Console.WriteLine("Byte read from unmanaged memory: " + c);

          // Free the unmanaged memory.
          Marshal.FreeHGlobal(hGlobal);
          Console.WriteLine("Unmanaged memory was disposed.");
     }
}
//</snippet1>