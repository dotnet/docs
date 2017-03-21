    Public Sub AddRectanglesExample(ByVal e As PaintEventArgs)

        ' Adds a pattern of rectangles to a GraphicsPath object.
        Dim myPath As New GraphicsPath
        Dim pathRects As Rectangle() = {New Rectangle(20, 20, 100, 200), _
        New Rectangle(40, 40, 120, 220), New Rectangle(60, 60, 240, 140)}
        myPath.AddRectangles(pathRects)

        ' Draw the path to the screen.
        Dim myPen As New Pen(Color.Black, 2)
        e.Graphics.DrawPath(myPen, myPath)
    End Sub