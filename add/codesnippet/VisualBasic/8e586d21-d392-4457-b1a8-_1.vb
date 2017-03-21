    Private Sub DrawImageUnscaled(ByVal e As PaintEventArgs) 
        Dim filepath As String = "C:\Documents and Settings\All Users\Documents\" _
            & "My Pictures\Sample Pictures\Water Lilies.jpg"
        Dim bitmap1 As New Bitmap(filepath)
        e.Graphics.DrawImageUnscaledAndClipped(bitmap1, _
            New Rectangle(10, 10, 250, 250))
    End Sub