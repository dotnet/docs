    Public Sub DrawLinePoint(ByVal e As PaintEventArgs)

        ' Create pen.
        Dim blackPen As New Pen(Color.Black, 3)

        ' Create points that define line.
        Dim point1 As New Point(100, 100)
        Dim point2 As New Point(500, 100)

        ' Draw line to screen.
        e.Graphics.DrawLine(blackPen, point1, point2)
    End Sub