'<SNIPPET1>
Imports System
Imports System.Runtime.InteropServices

Module Example

    ' Use DllImport to import the Win32 MessageBox function.
    <DllImport("user32.dll", CharSet:=CharSet.Unicode)> _
    Function MessageBox(ByVal hwnd As IntPtr, ByVal t As String, ByVal caption As String, ByVal t2 As UInt32) As Integer
    End Function


    Sub Main()
        ' Call the MessageBox function using platform invoke.
        MessageBox(New IntPtr(0), "Hello World!", "Hello Dialog", 0)
    End Sub

End Module
'</SNIPPET1>