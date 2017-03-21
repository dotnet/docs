Public Class Win32
    <DllImport("user32.dll", ExactSpelling := False)> _
    Public Shared Function MessageBox(hWnd As IntPtr, text As String, _
               caption As String, type As UInteger) As Integer
    End Function
End Class