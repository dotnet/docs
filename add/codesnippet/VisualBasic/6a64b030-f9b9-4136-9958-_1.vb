    Private Sub DrawImageRect4Float(ByVal e As PaintEventArgs)

        ' Create image.
        Dim newImage As Image = Image.FromFile("SampImag.jpg")

        ' Create rectangle for displaying image.
        Dim destRect As New Rectangle(100, 100, 450, 150)

        ' Create coordinates of rectangle for source image.
        Dim x As Single = 50.0F
        Dim y As Single = 50.0F
        Dim width As Single = 150.0F
        Dim height As Single = 150.0F
        Dim units As GraphicsUnit = GraphicsUnit.Pixel

        ' Draw image to screen.
        e.Graphics.DrawImage(newImage, destRect, x, y, width, height, _
        units)
    End Sub