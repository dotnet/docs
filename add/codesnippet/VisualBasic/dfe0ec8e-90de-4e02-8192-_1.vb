    Private Sub DrawCurvePointFTension(ByVal e As PaintEventArgs)

        ' Create pens.
        Dim redPen As New Pen(Color.Red, 3)
        Dim greenPen As New Pen(Color.Green, 3)

        ' Create points that define curve.
        Dim point1 As New PointF(50.0F, 50.0F)
        Dim point2 As New PointF(100.0F, 25.0F)
        Dim point3 As New PointF(200.0F, 5.0F)
        Dim point4 As New PointF(250.0F, 50.0F)
        Dim point5 As New PointF(300.0F, 100.0F)
        Dim point6 As New PointF(350.0F, 200.0F)
        Dim point7 As New PointF(250.0F, 250.0F)
        Dim curvePoints As PointF() = {point1, point2, point3, point4, _
        point5, point6, point7}

        ' Draw lines between original points to screen.
        e.Graphics.DrawLines(redPen, curvePoints)

        ' Create tension.
        Dim tension As Single = 1.0F

        ' Draw curve to screen.
        e.Graphics.DrawCurve(greenPen, curvePoints, tension)
    End Sub