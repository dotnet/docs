    Private Sub DrawImageRect4Int(ByVal e As PaintEventArgs)

        ' Create image.
        Dim newImage As Image = Image.FromFile("SampImag.jpg")

        ' Create rectangle for displaying image.
        Dim destRect As New Rectangle(100, 100, 450, 150)

        ' Create coordinates of rectangle for source image.
        Dim x As Integer = 50
        Dim y As Integer = 50
        Dim width As Integer = 150
        Dim height As Integer = 150
        Dim units As GraphicsUnit = GraphicsUnit.Pixel

        ' Draw image to screen.
        e.Graphics.DrawImage(newImage, destRect, x, y, width, height, _
        units)
    End Sub