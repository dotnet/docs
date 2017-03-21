    Public Sub DrawImageRectFRectF(ByVal e As PaintEventArgs)

        ' Create image.
        Dim newImage As Image = Image.FromFile("SampImag.jpg")

        ' Create rectangle for displaying image.
        Dim destRect As New RectangleF(100.0F, 100.0F, 450.0F, 150.0F)

        ' Create rectangle for source image.
        Dim srcRect As New RectangleF(50.0F, 50.0F, 150.0F, 150.0F)
        Dim units As GraphicsUnit = GraphicsUnit.Pixel

        ' Draw image to screen.
        e.Graphics.DrawImage(newImage, destRect, srcRect, units)
    End Sub