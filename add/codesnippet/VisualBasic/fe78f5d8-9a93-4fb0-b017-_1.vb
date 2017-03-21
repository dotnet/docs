    Public Sub NextSubpathExample2(ByVal e As PaintEventArgs)

        ' Create a graphics path.
        Dim myPath As New GraphicsPath

        ' Set up primitives to add to myPath.
        Dim myPoints As Point() = {New Point(20, 20), _
            New Point(120, 120), New Point(20, 120), New Point(20, 20)}
        Dim myRect As New Rectangle(120, 120, 100, 100)

        ' Add 3 lines, a rectangle, an ellipse, and 2 markers.
        myPath.AddLines(myPoints)
        myPath.SetMarkers()
        myPath.AddRectangle(myRect)
        myPath.SetMarkers()
        myPath.AddEllipse(220, 220, 100, 100)

        ' Get the total number of points for the path,

        ' and the arrays of the points and types.
        Dim myPathPointCount As Integer = myPath.PointCount
        Dim myPathPoints As PointF() = myPath.PathPoints
        Dim myPathTypes As Byte() = myPath.PathTypes

        ' Set up variables for drawing the array
        ' of points to the screen.
        Dim i As Integer
        Dim j As Single = 20
        Dim myFont As New Font("Arial", 8)
        Dim myBrush As New SolidBrush(Color.Black)

        ' Draw the set of path points and types to the screen.
        For i = 0 To myPathPointCount - 1
            e.Graphics.DrawString(myPathPoints(i).X.ToString() + _
                ", " + myPathPoints(i).Y.ToString() + ", " + _
                myPathTypes(i).ToString(), myFont, myBrush, 20, j)
            j += 20
        Next i

        ' Create a GraphicsPathIterator for myPath.
        Dim myPathIterator As New GraphicsPathIterator(myPath)

        ' Rewind the iterator.
        myPathIterator.Rewind()

        ' Create the GraphicsPath section.
        Dim myPathSection As New GraphicsPath

        ' Draw the 3rd subpath and the number of points therein
        ' to the screen.
        Dim subpathPoints As Integer
        Dim IsClosed2 As Boolean

        ' Iterate to the third subpath.
        subpathPoints = myPathIterator.NextSubpath(myPathSection, _
            IsClosed2)
        subpathPoints = myPathIterator.NextSubpath(myPathSection, _
            IsClosed2)
        subpathPoints = myPathIterator.NextSubpath(myPathSection, _
            IsClosed2)

        ' Write the number of subpath points to the screen.
        e.Graphics.DrawString("Subpath: 3" + "   Num Points: " + _
        subpathPoints.ToString(), myFont, myBrush, 200, 20)
    End Sub