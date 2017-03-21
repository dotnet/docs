    Public Sub AddClosedCurveExample(ByVal e As PaintEventArgs)

        ' Creates a symetrical, closed curve.
        Dim myArray As Point() = {New Point(20, 100), New Point(40, 150), _
        New Point(60, 125), New Point(40, 100), New Point(60, 75), _
        New Point(40, 50)}
        Dim myPath As New GraphicsPath
        myPath.AddClosedCurve(myArray, 0.5F)
        Dim myPen As New Pen(Color.Black, 2)
        e.Graphics.DrawPath(myPen, myPath)
    End Sub