    Private Sub DrawBezierPointF(ByVal e As PaintEventArgs)

        ' Create pen.
        Dim blackPen As New Pen(Color.Black, 3)

        ' Create points for curve.
        Dim start As New PointF(100.0F, 100.0F)
        Dim control1 As New PointF(200.0F, 10.0F)
        Dim control2 As New PointF(350.0F, 50.0F)
        Dim [end] As New PointF(500.0F, 100.0F)

        ' Draw arc to screen.
        e.Graphics.DrawBezier(blackPen, start, control1, control2, [end])
    End Sub