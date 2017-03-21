    Public Sub CloseAllFiguresExample(ByVal e As PaintEventArgs)

        ' Create a path containing several open-ended figures.
        Dim myPath As New GraphicsPath
        myPath.StartFigure()
        myPath.AddLine(New Point(10, 10), New Point(150, 10))
        myPath.AddLine(New Point(150, 10), New Point(10, 150))
        myPath.StartFigure()
        myPath.AddArc(200, 200, 100, 100, 0, 90)
        myPath.StartFigure()
        Dim point1 As New Point(300, 300)
        Dim point2 As New Point(400, 325)
        Dim point3 As New Point(400, 375)
        Dim point4 As New Point(300, 400)
        Dim points As Point() = {point1, point2, point3, point4}
        myPath.AddCurve(points)

        ' close all the figures.
        myPath.CloseAllFigures()

        ' Draw the path to the screen.
        e.Graphics.DrawPath(New Pen(Color.Black, 3), myPath)
    End Sub