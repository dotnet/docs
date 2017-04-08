' <snippet1>
Imports System
Imports System.Runtime.InteropServices

Public Module Example
    Public Sub Main()
        Dim stringA As String = "I seem to be turned around!"
        Dim copylen As Integer = stringA.Length

        ' Allocate HGlobal memory for source and destination strings
        Dim sptr As IntPtr = Marshal.StringToHGlobalAnsi(stringA)
        Dim dptr As IntPtr = Marshal.AllocHGlobal(copylen)
        Dim offset As Integer = copylen - 1

         For ctr As Integer = 0 To copylen - 1
            Dim b As Byte = Marshal.ReadByte(sptr, ctr)
            Marshal.WriteByte(dptr, offset, b)
            offset -= 1
         Next

        Dim stringB As String = Marshal.PtrToStringAnsi(dptr)

        Console.WriteLine("Original:{1}{0}{1}", stringA, vbCrLf)
        Console.WriteLine("Reversed:{1}{0}{1}", stringB, vbCrLf)

        ' Free HGlobal memory
        Marshal.FreeHGlobal(dptr)
        Marshal.FreeHGlobal(sptr)
    End Sub
End Module
' The example displays the following output:
'       Original:
'       I seem to be turned around!
'
'       Reversed:
'       !dnuora denrut eb ot mees I
'</snippet1>
