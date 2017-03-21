    Private Sub DrawCurvePoint(ByVal e As PaintEventArgs)

        ' Create pens.
        Dim redPen As New Pen(Color.Red, 3)
        Dim greenPen As New Pen(Color.Green, 3)

        ' Create points that define curve.
        Dim point1 As New Point(50, 50)
        Dim point2 As New Point(100, 25)
        Dim point3 As New Point(200, 5)
        Dim point4 As New Point(250, 50)
        Dim point5 As New Point(300, 100)
        Dim point6 As New Point(350, 200)
        Dim point7 As New Point(250, 250)
        Dim curvePoints As Point() = {point1, point2, point3, point4, _
        point5, point6, point7}

        ' Draw lines between original points to screen.
        e.Graphics.DrawLines(redPen, curvePoints)

        ' Draw curve to screen.
        e.Graphics.DrawCurve(greenPen, curvePoints)
    End Sub