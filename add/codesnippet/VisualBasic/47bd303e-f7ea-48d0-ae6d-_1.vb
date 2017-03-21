    Public Sub RectangleFIntersectExample(ByVal e As PaintEventArgs)

        ' Create two rectangles.
        Dim firstRectangleF As New RectangleF(0, 0, 75, 50)
        Dim secondRectangleF As New RectangleF(50, 20, 50, 50)

        ' Convert the RectangleF structures to Rectangle structures and

        ' draw them to the screen.
        Dim firstRect As Rectangle = Rectangle.Truncate(firstRectangleF)
        Dim secondRect As Rectangle = Rectangle.Truncate(secondRectangleF)
        e.Graphics.DrawRectangle(Pens.Black, firstRect)
        e.Graphics.DrawRectangle(Pens.Red, secondRect)

        ' Get the intersection.
        Dim intersectRectangleF As RectangleF = _
        RectangleF.Intersect(firstRectangleF, secondRectangleF)

        ' Draw the intersectRectangleF to the screen.
        Dim intersectRect As Rectangle = _
        Rectangle.Truncate(intersectRectangleF)
        e.Graphics.DrawRectangle(Pens.Blue, intersectRect)
    End Sub