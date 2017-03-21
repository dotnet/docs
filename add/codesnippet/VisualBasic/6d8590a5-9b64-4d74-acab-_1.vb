    Private Sub DrawBeziersPointF(ByVal e As PaintEventArgs)

        ' Create pen.
        Dim blackPen As New Pen(Color.Black, 3)

        ' Create points for curve.
        Dim start As New PointF(100.0F, 100.0F)
        Dim control1 As New PointF(200.0F, 10.0F)
        Dim control2 As New PointF(350.0F, 50.0F)
        Dim end1 As New PointF(500.0F, 100.0F)
        Dim control3 As New PointF(600.0F, 150.0F)
        Dim control4 As New PointF(650.0F, 250.0F)
        Dim end2 As New PointF(500.0F, 300.0F)
        Dim bezierPoints As PointF() = {start, control1, control2, _
        end1, control3, control4, end2}

        ' Draw arc to screen.
        e.Graphics.DrawBeziers(blackPen, bezierPoints)
    End Sub