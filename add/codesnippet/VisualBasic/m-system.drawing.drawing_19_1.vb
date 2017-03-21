    Public Sub CloseFigureExample(ByVal e As PaintEventArgs)

        ' Create a path consisting of two, open-ended lines and close

        ' the lines using CloseFigure.
        Dim myPath As New GraphicsPath
        myPath.StartFigure()
        myPath.AddLine(New Point(10, 10), New Point(200, 10))
        myPath.AddLine(New Point(200, 10), New Point(200, 200))
        myPath.CloseFigure()

        ' Draw the path to the screen.
        e.Graphics.DrawPath(Pens.Black, myPath)
    End Sub