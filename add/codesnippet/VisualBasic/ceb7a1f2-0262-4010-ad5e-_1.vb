    Public Sub AddCurveExample(ByVal e As PaintEventArgs)

        ' Create some points.
        Dim point1 As New Point(20, 20)
        Dim point2 As New Point(40, 0)
        Dim point3 As New Point(60, 40)
        Dim point4 As New Point(80, 20)

        ' Create an array of the points.
        Dim curvePoints As Point() = {point1, point2, point3, point4}

        ' Create a GraphicsPath object and add a curve.
        Dim myPath As New GraphicsPath
        myPath.AddCurve(curvePoints, 0, 3, 0.8F)

        ' Draw the path to the screen.
        Dim myPen As New Pen(Color.Black, 2)
        e.Graphics.DrawPath(myPen, myPath)
    End Sub