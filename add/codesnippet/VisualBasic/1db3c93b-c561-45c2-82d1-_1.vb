    Public Sub FillEllipseRectangle(ByVal e As PaintEventArgs)

        ' Create solid brush.
        Dim redBrush As New SolidBrush(Color.Red)

        ' Create rectangle for ellipse.
        Dim x As Integer = 0
        Dim y As Integer = 0
        Dim width As Integer = 200
        Dim height As Integer = 100
        Dim rect As New Rectangle(x, y, width, height)

        ' Fill ellipse on screen.
        e.Graphics.FillEllipse(redBrush, rect)
    End Sub