Public Class Win32
    <DllImport("user32.dll", SetLastError := true)> _
    Public Shared Function MessageBoxA(hWnd As IntPtr, text As String, _
               caption As String, type As UInteger) As Integer
    End Function
End Class