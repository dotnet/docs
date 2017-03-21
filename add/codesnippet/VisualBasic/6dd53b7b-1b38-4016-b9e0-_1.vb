    Private Sub DrawImageParaRect(ByVal e As PaintEventArgs)

        ' Create image.
        Dim newImage As Image = Image.FromFile("SampImag.jpg")

        ' Create parallelogram for drawing image.
        Dim ulCorner As New Point(100, 100)
        Dim urCorner As New Point(325, 100)
        Dim llCorner As New Point(150, 250)
        Dim destPara As Point() = {ulCorner, urCorner, llCorner}

        ' Create rectangle for source image.
        Dim srcRect As New Rectangle(50, 50, 150, 150)
        Dim units As GraphicsUnit = GraphicsUnit.Pixel

        ' Draw image to screen.
        e.Graphics.DrawImage(newImage, destPara, srcRect, units)
    End Sub