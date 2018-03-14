    ' Defines the MessageBox function.
    Public Class Win32
        Declare Auto Function MessageBox Lib "user32.dll" (
            ByVal hWnd As Integer, ByVal txt As String,
            ByVal caption As String, ByVal Type As Integer
            ) As Integer
    End Class

    ' Calls the MessageBox function.
    Public Class DemoMessageBox
        Public Shared Sub Main()
            Win32.MessageBox(0, "Here's a MessageBox", "Platform Invoke Sample", 0)
        End Sub
    End Class