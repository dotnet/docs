    Private Sub FillRectanglesRectangle(ByVal e As PaintEventArgs)

        ' Create solid brush.
        Dim blueBrush As New SolidBrush(Color.Blue)

        ' Create array of rectangles.
        Dim rects As Rectangle() = {New Rectangle(0, 0, 100, 200), _
        New Rectangle(100, 200, 250, 50), _
        New Rectangle(300, 0, 50, 100)}

        ' Fill rectangles to screen.
        e.Graphics.FillRectangles(blueBrush, rects)
    End Sub