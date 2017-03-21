    Private Sub DrawImageRect4FloatAttrib(ByVal e As PaintEventArgs)

        ' Create image.
        Dim newImage As Image = Image.FromFile("SampImag.jpg")

        ' Create rectangle for displaying original image.
        Dim destRect1 As New Rectangle(100, 25, 450, 150)

        ' Create coordinates of rectangle for source image.
        Dim x As Single = 50.0F
        Dim y As Single = 50.0F
        Dim width As Single = 150.0F
        Dim height As Single = 150.0F
        Dim units As GraphicsUnit = GraphicsUnit.Pixel

        ' Draw original image to screen.
        e.Graphics.DrawImage(newImage, destRect1, x, y, width, _
        height, units)

        ' Create rectangle for adjusted image.
        Dim destRect2 As New Rectangle(100, 175, 450, 150)

        ' Create image attributes and set large gamma.
        Dim imageAttr As New ImageAttributes
        imageAttr.SetGamma(4.0F)

        ' Draw adjusted image to screen.
        e.Graphics.DrawImage(newImage, destRect2, x, y, width, height, _
        units, imageAttr)
    End Sub