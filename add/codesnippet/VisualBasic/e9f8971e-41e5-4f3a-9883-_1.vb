    Public Sub AddArcExample(ByVal e As PaintEventArgs)

        ' Create a GraphicsPath object.
        Dim myPath As New GraphicsPath

        ' Set up and call AddArc, and close the figure.
        Dim rect As New Rectangle(20, 20, 50, 100)
        myPath.StartFigure()
        myPath.AddArc(rect, 0, 180)
        myPath.CloseFigure()

        ' Draw the path to screen.
        e.Graphics.DrawPath(New Pen(Color.Red, 3), myPath)
    End Sub