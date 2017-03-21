    Public Sub AddPolygonExample(ByVal e As PaintEventArgs)

        ' Create an array of points.
        Dim myArray As Point() = {New Point(23, 20), New Point(40, 10), _
        New Point(57, 20), New Point(50, 40), New Point(30, 40)}

        ' Create a GraphicsPath object and add a polygon.
        Dim myPath As New GraphicsPath
        myPath.AddPolygon(myArray)

        ' Draw the path to the screen.
        Dim myPen As New Pen(Color.Black, 2)
        e.Graphics.DrawPath(myPen, myPath)
    End Sub