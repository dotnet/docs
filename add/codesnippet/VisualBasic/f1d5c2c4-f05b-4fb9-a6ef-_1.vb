    Private Sub CopyPixels4(ByVal e As PaintEventArgs) 
        e.Graphics.CopyFromScreen(0, 0, 20, 20, _
            New Size(160, 160), CopyPixelOperation.SourceInvert)
    End Sub