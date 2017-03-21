    Public Sub DrawImage4Float(ByVal e As PaintEventArgs)

        ' Create image.
        Dim newImage As Image = Image.FromFile("SampImag.jpg")

        ' Create coordinates for upper-left corner

        ' of image and for size of image.
        Dim x As Single = 100.0F
        Dim y As Single = 100.0F
        Dim width As Single = 450.0F
        Dim height As Single = 150.0F

        ' Draw image to screen.
        e.Graphics.DrawImage(newImage, x, y, width, height)
    End Sub