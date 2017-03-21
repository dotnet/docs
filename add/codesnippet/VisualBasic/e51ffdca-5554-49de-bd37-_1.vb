    Public Sub DrawImageUnscaledPoint(ByVal e As PaintEventArgs)

        ' Create image.
        Dim newImage As Image = Image.FromFile("SampImag.jpg")

        ' Create point for upper-left corner of image.
        Dim ulCorner As New Point(100, 100)

        ' Draw image to screen.
        e.Graphics.DrawImageUnscaled(newImage, ulCorner)
    End Sub