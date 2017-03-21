    Private Sub DrawImagePara(ByVal e As PaintEventArgs)

        ' Create image.
        Dim newImage As Image = Image.FromFile("SampImag.jpg")

        ' Create parallelogram for drawing image.
        Dim ulCorner As New Point(100, 100)
        Dim urCorner As New Point(550, 100)
        Dim llCorner As New Point(150, 250)
        Dim destPara As Point() = {ulCorner, urCorner, llCorner}

        ' Draw image to screen.
        e.Graphics.DrawImage(newImage, destPara)
    End Sub