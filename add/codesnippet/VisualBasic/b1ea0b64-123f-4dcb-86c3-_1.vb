    Public Sub CopyDataExample(ByVal e As PaintEventArgs)

        ' Create a graphics path.
        Dim myPath As New GraphicsPath

        ' Set up a points array.
        Dim myPoints As Point() = {New Point(20, 20), _
        New Point(120, 120), New Point(20, 120), New Point(20, 20)}

        ' Create a rectangle.
        Dim myRect As New Rectangle(120, 120, 100, 100)

        ' Add the points, rectangle, and an ellipse to the path.
        myPath.AddLines(myPoints)
        myPath.SetMarkers()
        myPath.AddRectangle(myRect)
        myPath.SetMarkers()
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
        For i = 0 To myPathPointCount - 1
            e.Graphics.DrawString(myPathPoints(i).X.ToString() + ", " + _
            myPathPoints(i).Y.ToString() + ", " + _
            myPathTypes(i).ToString(), myFont, myBrush, 20, j)
            j += 20
        Next i

        ' Create a GraphicsPathIterator for myPath and rewind it.
        Dim myPathIterator As New GraphicsPathIterator(myPath)
        myPathIterator.Rewind()

        ' Set up the arrays to receive the copied data.
        Dim points(myPathIterator.Count) As PointF
        Dim types(myPathIterator.Count) As Byte
        Dim myStartIndex As Integer
        Dim myEndIndex As Integer

        ' Increment the starting index to the second marker in the path.
        myPathIterator.NextMarker(myStartIndex, myEndIndex)
        myPathIterator.NextMarker(myStartIndex, myEndIndex)

        ' Copy all the points and types from the starting index to the
        ' ending index to the  points array and the types array
        ' respectively.
        Dim numPointsCopied As Integer = myPathIterator.CopyData(points, _
        types, myStartIndex, myEndIndex)

        ' List the copied points to the right side of the screen.
        j = 20
        Dim copiedStartIndex As Integer = 0
        For i = 0 To numPointsCopied - 1
            copiedStartIndex = myStartIndex + i
            e.Graphics.DrawString("Point: " + _
            copiedStartIndex.ToString() + ", Value: " + _
            points(i).ToString() + ", Type: " + types(i).ToString(), _
            myFont, myBrush, 200, j)
            j += 20
        Next i
    End Sub