    Public Sub DrawLineInt(ByVal e As PaintEventArgs)

        ' Create pen.
        Dim blackPen As New Pen(Color.Black, 3)

        ' Create coordinates of points that define line.
        Dim x1 As Integer = 100
        Dim y1 As Integer = 100
        Dim x2 As Integer = 500
        Dim y2 As Integer = 100

        ' Draw line to screen.
        e.Graphics.DrawLine(blackPen, x1, y1, x2, y2)
    End Sub