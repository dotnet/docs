    Public Sub FillClosedCurvePointF(ByVal e As PaintEventArgs)

        ' Create solid brush.
        Dim redBrush As New SolidBrush(Color.Red)

        'Create array of points for curve.
        Dim point1 As New PointF(100.0F, 100.0F)
        Dim point2 As New PointF(200.0F, 50.0F)
        Dim point3 As New PointF(250.0F, 200.0F)
        Dim point4 As New PointF(50.0F, 150.0F)
        Dim points As PointF() = {point1, point2, point3, point4}

        ' Fill curve on screen.
        e.Graphics.FillClosedCurve(redBrush, points)
    End Sub