    Private Sub FillRectanglesRectangleF(ByVal e As PaintEventArgs)

        ' Create solid brush.
        Dim blueBrush As New SolidBrush(Color.Blue)

        ' Create array of rectangles.
        Dim rects As RectangleF() = {New RectangleF(0.0F, 0.0F, 100.0F, 200.0F), _
        New RectangleF(100.0F, 200.0F, 250.0F, 50.0F), _
        New RectangleF(300.0F, 0.0F, 50.0F, 100.0F)}

        ' Fill rectangles to screen.
        e.Graphics.FillRectangles(blueBrush, rects)
    End Sub