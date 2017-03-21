    Public Sub DrawImage4Int(ByVal e As PaintEventArgs)

        ' Create image.
        Dim newImage As Image = Image.FromFile("SampImag.jpg")

        ' Create coordinates for upper-left corner

        ' of image and for size of image.
        Dim x As Integer = 100
        Dim y As Integer = 100
        Dim width As Integer = 450
        Dim height As Integer = 150

        ' Draw image to screen.
        e.Graphics.DrawImage(newImage, x, y, width, height)
    End Sub