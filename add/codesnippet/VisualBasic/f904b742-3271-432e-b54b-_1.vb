    Public Sub DrawImage2IntRect(ByVal e As PaintEventArgs)

        ' Create image.
        Dim newImage As Image = Image.FromFile("SampImag.jpg")

        ' Create coordinates for upper-left corner of image.
        Dim x As Integer = 100
        Dim y As Integer = 100

        ' Create rectangle for source image.
        Dim srcRect As New Rectangle(50, 50, 150, 150)
        Dim units As GraphicsUnit = GraphicsUnit.Pixel

        ' Draw image to screen.
        e.Graphics.DrawImage(newImage, x, y, srcRect, units)
    End Sub