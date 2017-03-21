    Private Sub CopyPixels1(ByVal e As PaintEventArgs) 
        e.Graphics.CopyFromScreen(Me.Location, _
            New Point(40, 40), New Size(100, 100))
    
    End Sub