    Public Sub GraphicsPathResetExample(ByVal e As PaintEventArgs)
        Dim myFont As New Font("Arial", 8)

        ' Create a path and add a line, an ellipse, and an arc.
        Dim myPath As New GraphicsPath
        myPath.AddLine(New Point(0, 0), New Point(100, 100))
        myPath.AddEllipse(100, 100, 200, 250)
        myPath.AddArc(300, 250, 100, 100, 0, 90)

        ' Draw the pre-reset points array to the screen.
        DrawPointsHelper1(e, myPath.PathPoints, 20)

        ' Reset the path.
        myPath.Reset()

        ' See if any points remain.
        If myPath.PointCount > 0 Then

            ' Draw the post-reset points array to the screen.
            DrawPointsHelper1(e, myPath.PathPoints, 150)

            ' If there are no points, say so.
        Else
            e.Graphics.DrawString("No Points", myFont, Brushes.Black, _
            150, 20)
        End If
    End Sub

    ' A helper function used by GraphicsPathResetExample to draw points.
    Public Sub DrawPointsHelper1(ByVal e As PaintEventArgs, _
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