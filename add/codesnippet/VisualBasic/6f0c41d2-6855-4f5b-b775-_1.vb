    Public Sub DrawImageRectF(ByVal e As PaintEventArgs)

        ' Create image.
        Dim newImage As Image = Image.FromFile("SampImag.jpg")

        ' Create rectangle for displaying image.
        Dim rect As New RectangleF(100.0F, 100.0F, 450.0F, 150.0F)

        ' Draw image to screen.
        e.Graphics.DrawImage(newImage, rect)
    End Sub