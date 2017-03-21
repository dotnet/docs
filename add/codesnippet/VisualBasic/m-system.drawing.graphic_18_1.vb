    Private Sub DrawImagePoint(ByVal e As PaintEventArgs)

        ' Create image.
        Dim newImage As Image = Image.FromFile("SampImag.jpg")

        ' Create Point for upper-left corner of image.
        Dim ulCorner As New Point(100, 100)

        ' Draw image to screen.
        e.Graphics.DrawImage(newImage, ulCorner)
    End Sub