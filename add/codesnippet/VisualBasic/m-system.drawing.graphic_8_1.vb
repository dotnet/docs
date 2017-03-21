    Private Sub FromImageImage2(ByVal e As PaintEventArgs)

        ' Create image.
        Dim imageFile As Image = Image.FromFile("SampImag.jpg")

        ' Create graphics object for alteration.
        Dim newGraphics As Graphics = Graphics.FromImage(imageFile)

        ' Alter image.
        newGraphics.FillRectangle(New SolidBrush(Color.Black), _
        100, 50, 100, 100)

        ' Draw image to screen.
        e.Graphics.DrawImage(imageFile, New PointF(0.0F, 0.0F))

        ' Dispose of graphics object.
        newGraphics.Dispose()
    End Sub