    Private Sub DrawImageRect(ByVal e As PaintEventArgs)

        ' Create image.
        Dim newImage As Image = Image.FromFile("SampImag.jpg")

        ' Create rectangle for displaying image.
        Dim destRect As New Rectangle(100, 100, 450, 150)

        ' Draw image to screen.
        e.Graphics.DrawImage(newImage, destRect)
    End Sub