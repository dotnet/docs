    Public Sub AddBezierExample(ByVal e As PaintEventArgs)

        ' Create a new Path.
        Dim myPath As New GraphicsPath

        ' Call AddBezier.
        myPath.StartFigure()
        myPath.AddBezier(50, 50, 70, 0, 100, 120, 150, 50)

        ' Close the curve.
        myPath.CloseFigure()

        ' Draw the path to screen.
        e.Graphics.DrawPath(New Pen(Color.Red, 2), myPath)
    End Sub