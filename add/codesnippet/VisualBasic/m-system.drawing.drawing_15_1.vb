    Public Sub AddEllipseExample(ByVal e As PaintEventArgs)

        ' Create a path and add an ellipse.
        Dim myEllipse As New Rectangle(20, 20, 100, 50)
        Dim myPath As New GraphicsPath
        myPath.AddEllipse(myEllipse)

        ' Draw the path to the screen.
        Dim myPen As New Pen(Color.Black, 2)
        e.Graphics.DrawPath(myPen, myPath)
    End Sub