    Private Sub FillRectangleRectangle(ByVal e As PaintEventArgs)

        ' Create solid brush.
        Dim blueBrush As New SolidBrush(Color.Blue)

        ' Create rectangle.
        Dim rect As New Rectangle(0, 0, 200, 200)

        ' Fill rectangle to screen.
        e.Graphics.FillRectangle(blueBrush, rect)
    End Sub