    Private Sub DrawImageParaRectAttrib(ByVal e As PaintEventArgs)

        ' Create image.
        Dim newImage As Image = Image.FromFile("SampImag.jpg")

        ' Create parallelogram for drawing image.
        Dim ulCorner1 As New Point(100, 100)
        Dim urCorner1 As New Point(325, 100)
        Dim llCorner1 As New Point(150, 250)
        Dim destPara1 As Point() = {ulCorner1, urCorner1, llCorner1}

        ' Create rectangle for source image.
        Dim srcRect As New Rectangle(50, 50, 150, 150)
        Dim units As GraphicsUnit = GraphicsUnit.Pixel

        ' Draw original image to screen.
        e.Graphics.DrawImage(newImage, destPara1, srcRect, units)

        ' Create parallelogram for drawing adjusted image.
        Dim ulCorner2 As New Point(325, 100)
        Dim urCorner2 As New Point(550, 100)
        Dim llCorner2 As New Point(375, 250)
        Dim destPara2 As Point() = {ulCorner2, urCorner2, llCorner2}

        ' Create image attributes and set large gamma.
        Dim imageAttr As New ImageAttributes
        imageAttr.SetGamma(4.0F)

        ' Draw adjusted image to screen.
        e.Graphics.DrawImage(newImage, destPara2, srcRect, units, _
        imageAttr)
    End Sub