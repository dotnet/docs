    Public Sub CloneExample(ByVal e As PaintEventArgs)

        ' Set several markers in a path.
        Dim myPath As New GraphicsPath
        myPath.AddEllipse(0, 0, 100, 200)
        myPath.AddLine(New Point(100, 100), New Point(200, 100))
        Dim rect As New Rectangle(200, 0, 100, 200)
        myPath.AddRectangle(rect)
        myPath.AddLine(New Point(250, 200), New Point(250, 300))

        ' Draw the path to the screen.
        Dim myPen As New Pen(Color.Black, 2)
        e.Graphics.DrawPath(myPen, myPath)

        ' Clone a copy of myPath.
        Dim myPath2 As GraphicsPath = CType(myPath.Clone(), GraphicsPath)

        ' Draw the path to the screen.
        Dim myPen2 As New Pen(Color.Red, 4)
        e.Graphics.DrawPath(myPen2, myPath2)
    End Sub