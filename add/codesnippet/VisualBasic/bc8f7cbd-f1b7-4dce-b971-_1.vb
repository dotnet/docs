    Private Sub DrawImageParaFRectF(ByVal e As PaintEventArgs)

        ' Create image.
        Dim newImage As Image = Image.FromFile("SampImag.jpg")

        ' Create parallelogram for drawing image.
        Dim ulCorner As New PointF(100.0F, 100.0F)
        Dim urCorner As New PointF(550.0F, 100.0F)
        Dim llCorner As New PointF(150.0F, 250.0F)
        Dim destPara As PointF() = {ulCorner, urCorner, llCorner}

        ' Create rectangle for source image.
        Dim srcRect As New RectangleF(50.0F, 50.0F, 150.0F, 150.0F)
        Dim units As GraphicsUnit = GraphicsUnit.Pixel

        ' Draw image to screen.
        e.Graphics.DrawImage(newImage, destPara, srcRect, units)
    End Sub