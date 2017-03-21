    Public Sub NextPathTypeExample(ByVal e As PaintEventArgs)

        ' Create the GraphicsPath.
        Dim myPath As New GraphicsPath
        Dim myPoints As Point() = {New Point(20, 20), _
        New Point(120, 120), New Point(20, 120), New Point(20, 20)}
        Dim myRect As New Rectangle(120, 120, 100, 100)

        ' Add 3 lines, a rectangle, and an ellipse.
        myPath.AddLines(myPoints)
        myPath.AddRectangle(myRect)
        myPath.AddEllipse(220, 220, 100, 100)

        ' List all of the path points to the screen.
        ListPathPointsHelper(e, myPath, Nothing, 20, 1)

        ' Create a GraphicsPathIterator.
        Dim myPathIterator As New GraphicsPathIterator(myPath)

        ' Rewind the Iterator.
        myPathIterator.Rewind()

        ' Iterate the subpaths and types, and list the results
        ' to the screen.
        Dim j As Integer = 20
        Dim i As Integer
        Dim mySubPaths, subPathStartIndex, subPathEndIndex As Integer
        Dim IsClosed As [Boolean]
        Dim subPathPointType As Byte
        Dim pointTypeStartIndex, pointTypeEndIndex, _
        numPointsFound As Integer
        Dim myFont As New Font("Arial", 8)
        Dim myBrush As New SolidBrush(Color.Black)
        j = 20
        For i = 0 To 2
            mySubPaths = myPathIterator.NextSubpath(subPathStartIndex, _
                subPathEndIndex, IsClosed)
            numPointsFound = myPathIterator.NextPathType(subPathPointType, _
                pointTypeStartIndex, pointTypeEndIndex)
            e.Graphics.DrawString("SubPath: " & i & "  Points Found: " & _
                numPointsFound.ToString() & "  Type of Points: " & _
            subPathPointType.ToString(), myFont, myBrush, 200, j)
            j += 20
        Next i

        ' List the total number of path points to the screen.
        ListPathPointsHelper(e, myPath, myPathIterator, 200, 2)
    End Sub

    ' This is a helper function used by NextPathTypeExample.
    Public Sub ListPathPointsHelper(ByVal e As PaintEventArgs, _
    ByVal myPath As GraphicsPath, ByVal myPathIterator As GraphicsPathIterator, _
    ByVal xOffset As Integer, ByVal listType As Integer)

        ' Get the total number of points for the path,
        ' and the arrays of the points and types.
        Dim myPathPointCount As Integer = myPath.PointCount
        Dim myPathPoints As PointF() = myPath.PathPoints
        Dim myPathTypes As Byte() = myPath.PathTypes

        ' Set up variables for drawing the points to the screen.
        Dim i As Integer
        Dim j As Single = 20
        Dim myFont As New Font("Arial", 8)
        Dim myBrush As New SolidBrush(Color.Black)
        If listType = 1 Then
            ' List all the path points to the screen.

            ' Draw the set of path points and types to the screen.
            For i = 0 To myPathPointCount - 1
                e.Graphics.DrawString(myPathPoints(i).X.ToString() + ", " + _
                    myPathPoints(i).Y.ToString() + ", " + _
                myPathTypes(i).ToString(), myFont, myBrush, xOffset, j)
                j += 20
            Next i
        Else
            If listType = 2 Then
                ' Display the total number of path points.

                ' Draw the total number of points to the screen.
                Dim myPathTotalPoints As Integer = myPathIterator.Count
                e.Graphics.DrawString("Total Points = " + _
                    myPathTotalPoints.ToString(), myFont, myBrush, xOffset, _
                    100)
            Else
                e.Graphics.DrawString("Wrong or no list type argument.", _
                    myFont, myBrush, xOffset, 200)
            End If
        End If
    End Sub