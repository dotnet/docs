' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Runtime.InteropServices

Module Example
   Public Sub Main()
      Dim arr() As Integer = { 2, 4, 6, 8, 10, 12, 14, 16, 18, 20}
      Dim ptr As IntPtr = Marshal.UnsafeAddrOfPinnedArrayElement(arr, arr.Length - 1)
      Dim size As Integer = Len(arr(0))

      For ctr As Integer = 0 To arr.Length - 1
         Dim newPtr As IntPtr = IntPtr.Subtract(ptr, ctr * size)
         Console.Write("{0}   ", Marshal.ReadInt32(newPtr))
      Next
   End Sub
End Module
' The example displays the following output:
'       20   18   16   14   12   10   8   6   4   2
' </Snippet1>