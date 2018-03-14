 '<snippet1>
Imports System
Imports System.Runtime.InteropServices

Module Example
    Sub Main()
         ' Allocate 1 byte of unmanaged memory.
         Dim hGlobal As IntPtr = Marshal.AllocHGlobal(1)
         
         ' Create a new byte.
         Dim b As Byte = 1
         
         Console.WriteLine("Byte written to unmanaged memory: {0}", b)
         
         ' Write the byte to unmanaged memory.
         Marshal.WriteByte(hGlobal, b)
         
         ' Read byte from unmanaged memory.
         Dim c As Byte = Marshal.ReadByte(hGlobal)
         Console.WriteLine("Byte read from unmanaged memory: {0}", c)
         
         ' Free the unmanaged memory.
         Marshal.FreeHGlobal(hGlobal)
         Console.WriteLine("Unmanaged memory was disposed.")
    End Sub
End Module
'</snippet1>