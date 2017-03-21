    Public Sub DrawImage2FloatRectF(ByVal e As PaintEventArgs)

        ' Create image.
        Dim newImage As Image = Image.FromFile("SampImag.jpg")

        ' Create coordinates for upper-left corner of image.
        Dim x As Single = 100.0F
        Dim y As Single = 100.0F

        ' Create rectangle for source image.
        Dim srcRect As New RectangleF(50.0F, 50.0F, 150.0F, 150.0F)
        Dim units As GraphicsUnit = GraphicsUnit.Pixel

        ' Draw image to screen.
        e.Graphics.DrawImage(newImage, x, y, srcRect, units)
    End Sub