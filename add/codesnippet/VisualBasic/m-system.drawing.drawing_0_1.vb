    Public Sub StartFigureExample(ByVal e As PaintEventArgs)

        ' Create a GraphicsPath object.
        Dim myPath As New GraphicsPath

        ' First set of figures.
        myPath.StartFigure()
        myPath.AddArc(10, 10, 50, 50, 0, 270)
        myPath.AddLine(New Point(50, 0), New Point(100, 50))
        myPath.AddArc(50, 100, 75, 75, 0, 270)
        myPath.CloseFigure()
        myPath.StartFigure()
        myPath.AddArc(100, 10, 50, 50, 0, 270)

        ' Second set of figures.
        myPath.StartFigure()
        myPath.AddArc(10, 200, 50, 50, 0, 270)
        myPath.CloseFigure()
        myPath.StartFigure()
        myPath.AddLine(New Point(60, 200), New Point(110, 250))
        myPath.AddArc(50, 300, 75, 75, 0, 270)
        myPath.CloseFigure()
        myPath.StartFigure()
        myPath.AddArc(100, 200, 50, 50, 0, 270)

        ' Draw the path to the screen.
        e.Graphics.DrawPath(New Pen(Color.Black), myPath)
    End Sub