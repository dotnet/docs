    Public Sub GraphicsPathReverseExample(ByVal e As PaintEventArgs)

        ' Create a path and add a line, ellipse, and arc.
        Dim myPath As New GraphicsPath
        myPath.AddLine(New Point(0, 0), New Point(100, 100))
        myPath.AddEllipse(100, 100, 200, 250)
        myPath.AddArc(300, 250, 100, 100, 0, 90)

        ' Draw the first set of points to the screen.
        DrawPointsHelper2(e, myPath.PathPoints, 20)

        ' Call GraphicsPath.Reverse.
        myPath.Reverse()

        ' Draw the reversed set of points to the screen.
        DrawPointsHelper2(e, myPath.PathPoints, 150)
    End Sub

    ' A helper function used by GraphicsPathReverseExample to draw points.
    Public Sub DrawPointsHelper2(ByVal e As PaintEventArgs, _
    ByVal pathPoints() As PointF, ByVal xOffset As Integer)
        Dim y As Integer = 20
        Dim myFont As New Font("Arial", 8)
        Dim i As Integer
        For i = 0 To pathPoints.Length - 1
            e.Graphics.DrawString(pathPoints(i).X.ToString() + _
            ", " + pathPoints(i).Y.ToString(), myFont, Brushes.Black, _
            xOffset, y)
            y += 20
        Next i
    End Sub