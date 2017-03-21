    Private Sub DrawImagePointF(ByVal e As PaintEventArgs)

        ' Create image.
        Dim newImage As Image = Image.FromFile("SampImag.jpg")

        ' Create point for upper-left corner of image.
        Dim ulCorner As New PointF(100.0F, 100.0F)

        ' Draw image to screen.
        e.Graphics.DrawImage(newImage, ulCorner)
    End Sub