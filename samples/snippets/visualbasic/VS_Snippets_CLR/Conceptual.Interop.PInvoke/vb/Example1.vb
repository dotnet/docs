' <Snippet1>
Imports System.Runtime.InteropServices

Public Class Win32
    Declare Auto Function MessageBox Lib "user32.dll" _
       (ByVal hWnd As Integer, ByVal txt As String, _
       ByVal caption As String, ByVal Typ As Integer) As IntPtr
End Class

Public Class HelloWorld    
    Public Shared Sub Main()
        Win32.MessageBox(0, "Hello World", "Platform Invoke Sample", 0)
    End Sub
End Class
' </Snippet1>

