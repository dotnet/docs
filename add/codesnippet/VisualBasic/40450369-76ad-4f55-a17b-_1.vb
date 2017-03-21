    Public Sub TransformExample(ByVal e As PaintEventArgs)

        ' Create a path and add and ellipse.
        Dim myPath As New GraphicsPath
        myPath.AddEllipse(0, 0, 100, 200)

        ' Draw the starting position to screen.
        e.Graphics.DrawPath(Pens.Black, myPath)

        ' Move the ellipse 100 points to the right.
        Dim translateMatrix As New Matrix
        translateMatrix.Translate(100, 0)
        myPath.Transform(translateMatrix)

        ' Draw the transformed ellipse to the screen.
        e.Graphics.DrawPath(New Pen(Color.Red, 2), myPath)
    End Sub