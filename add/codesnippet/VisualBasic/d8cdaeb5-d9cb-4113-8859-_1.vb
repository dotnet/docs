    Public Sub FillClosedCurvePointFillMode(ByVal e As PaintEventArgs)

        ' Create solid brush.
        Dim redBrush As New SolidBrush(Color.Red)

        'Create array of points for curve.
        Dim point1 As New Point(100, 100)
        Dim point2 As New Point(200, 50)
        Dim point3 As New Point(250, 200)
        Dim point4 As New Point(50, 150)
        Dim points As Point() = {point1, point2, point3, point4}

        ' Set fill mode.
        Dim newFillMode As FillMode = FillMode.Winding

        ' Fill curve on screen.
        e.Graphics.FillClosedCurve(redBrush, points, newFillMode)
    End Sub