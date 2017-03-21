    Public Sub SetMarkersExample(ByVal e As PaintEventArgs)

        ' Create a path and set two markers.
        Dim myPath As New GraphicsPath
        myPath.AddLine(New Point(0, 0), New Point(50, 50))
        myPath.SetMarkers()
        Dim rect As New Rectangle(50, 50, 50, 50)
        myPath.AddRectangle(rect)
        myPath.SetMarkers()
        myPath.AddEllipse(100, 100, 100, 50)

        ' Draw the path to screen.
        e.Graphics.DrawPath(New Pen(Color.Black, 2), myPath)
    End Sub