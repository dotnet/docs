    Public Sub FillEllipseRectangleF(ByVal e As PaintEventArgs)

        ' Create solid brush.
        Dim redBrush As New SolidBrush(Color.Red)

        ' Create rectangle for ellipse.
        Dim x As Single = 0.0F
        Dim y As Single = 0.0F
        Dim width As Single = 200.0F
        Dim height As Single = 100.0F
        Dim rect As New RectangleF(x, y, width, height)

        ' Fill ellipse on screen.
        e.Graphics.FillEllipse(redBrush, rect)
    End Sub