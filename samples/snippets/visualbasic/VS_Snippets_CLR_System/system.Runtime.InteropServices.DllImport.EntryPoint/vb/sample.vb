'<SNIPPET1>
Imports System
Imports System.Runtime.InteropServices

Module Example

    ' Use DllImport to import the Win32 MessageBox function.
    ' Specify the method to import using the EntryPoint field and 
    ' then change the name to MyNewMessageBoxMethod.
    <DllImport("user32.dll", CharSet:=CharSet.Unicode, EntryPoint:="MessageBox")> _
    Function MyNewMessageBoxMethod(ByVal hwnd As IntPtr, ByVal t As String, ByVal caption As String, ByVal t2 As UInt32) As Integer
    End Function


    Sub Main()
        ' Call the MessageBox function using platform invoke.
        MyNewMessageBoxMethod(New IntPtr(0), "Hello World!", "Hello Dialog", 0)
    End Sub

End Module
'</SNIPPET1>