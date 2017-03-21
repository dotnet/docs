    Private Sub DrawBezierPoint(ByVal e As PaintEventArgs)

        ' Create pen.
        Dim blackPen As New Pen(Color.Black, 3)

        ' Create points for curve.
        Dim start As New Point(100, 100)
        Dim control1 As New Point(200, 10)
        Dim control2 As New Point(350, 50)
        Dim [end] As New Point(500, 100)

        ' Draw arc to screen.
        e.Graphics.DrawBezier(blackPen, start, control1, control2, [end])
    End Sub