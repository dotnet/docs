    Private Sub FillRectangleFloat(ByVal e As PaintEventArgs)

        ' Create solid brush.
        Dim blueBrush As New SolidBrush(Color.Blue)

        ' Create location and size of rectangle.
        Dim x As Single = 0.0F
        Dim y As Single = 0.0F
        Dim width As Single = 200.0F
        Dim height As Single = 200.0F

        ' Fill rectangle to screen.
        e.Graphics.FillRectangle(blueBrush, x, y, width, height)
    End Sub