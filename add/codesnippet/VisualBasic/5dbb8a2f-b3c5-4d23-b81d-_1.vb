    Public Sub EnumerateExample(ByVal e As PaintEventArgs)
        Dim myPath As New GraphicsPath
        Dim myPoints As Point() = {New Point(20, 20), _
            New Point(120, 120), New Point(20, 120), New Point(20, 20)}
        Dim myRect As New Rectangle(120, 120, 100, 100)
        myPath.AddLines(myPoints)
        myPath.AddRectangle(myRect)
        myPath.AddEllipse(220, 220, 100, 100)

        ' Get the total number of points for the path, and arrays of the
        ' points and types.
        Dim myPathPointCount As Integer = myPath.PointCount
        Dim myPathPoints As PointF() = myPath.PathPoints
        Dim myPathTypes As Byte() = myPath.PathTypes

        ' Set up variables for listing the array of points on the left side
        ' of the screen.
        Dim i As Integer
        Dim j As Single = 20
        Dim myFont As New Font("Arial", 8)
        Dim myBrush As New SolidBrush(Color.Black)

        ' List the set of points and types and types to the left side of
        ' the screen.
        e.Graphics.DrawString("Original Data", myFont, myBrush, 20, j)
        j += 20
        For i = 0 To myPathPointCount - 1
            e.Graphics.DrawString(myPathPoints(i).X.ToString() & ", " & _
            myPathPoints(i).Y.ToString() & ", " & _
            myPathTypes(i).ToString(), myFont, myBrush, 20, j)
            j += 20
        Next i

        ' Create a GraphicsPathIterator for myPath.
        Dim myPathIterator As New GraphicsPathIterator(myPath)
        myPathIterator.Rewind()
        Dim points(myPathIterator.Count) As PointF
        Dim types(myPathIterator.Count) As Byte
        Dim numPoints As Integer = myPathIterator.Enumerate(points, types)

        ' Draw the set of copied points and types to the screen.
        j = 20
        e.Graphics.DrawString("Copied Data", myFont, myBrush, 200, j)
        j += 20
        For i = 0 To points.Length - 1
            e.Graphics.DrawString("Point: " & i & ", " & "Value: " & _
                points(i).ToString() & ", " & "Type: " & _
                types(i).ToString(), myFont, myBrush, 200, j)
            j += 20
        Next i
    End Sub