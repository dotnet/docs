    Private Sub FillRectangleInt(ByVal e As PaintEventArgs)

        ' Create solid brush.
        Dim blueBrush As New SolidBrush(Color.Blue)

        ' Create location and size of rectangle.
        Dim x As Integer = 0
        Dim y As Integer = 0
        Dim width As Integer = 200
        Dim height As Integer = 200

        ' Fill rectangle to screen.
        e.Graphics.FillRectangle(blueBrush, x, y, width, height)
    End Sub