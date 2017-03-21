    Public Sub ClearMarkersExample(ByVal e As PaintEventArgs)

        ' Set several markers in a path.
        Dim myPath As New GraphicsPath
        myPath.AddEllipse(0, 0, 100, 200)
        myPath.SetMarkers()
        myPath.AddLine(New Point(100, 100), New Point(200, 100))
        Dim rect As New Rectangle(200, 0, 100, 200)
        myPath.AddRectangle(rect)
        myPath.SetMarkers()
        myPath.AddLine(New Point(250, 200), New Point(250, 300))
        myPath.SetMarkers()

        ' Clear the markers.
        myPath.ClearMarkers()

        ' Draw the path to the screen.
        Dim myPen As New Pen(Color.Black, 2)
        e.Graphics.DrawPath(myPen, myPath)
    End Sub