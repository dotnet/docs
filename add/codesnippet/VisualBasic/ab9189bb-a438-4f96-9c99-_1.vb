    Public Sub DrawImage2Int(ByVal e As PaintEventArgs)

        ' Create image.
        Dim newImage As Image = Image.FromFile("SampImag.jpg")

        ' Create coordinates for upper-left corner of image.
        Dim x As Integer = 100
        Dim y As Integer = 100

        ' Draw image to screen.
        e.Graphics.DrawImage(newImage, x, y)
    End Sub