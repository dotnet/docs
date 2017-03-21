    Public Sub DrawImage2Float(ByVal e As PaintEventArgs)

        ' Create image.
        Dim newImage As Image = Image.FromFile("SampImag.jpg")

        ' Create coordinates for upper-left corner of image.
        Dim x As Single = 100.0F
        Dim y As Single = 100.0F

        ' Draw image to screen.
        e.Graphics.DrawImage(newImage, x, y)
    End Sub