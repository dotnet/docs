    Public Sub RectangleFUnionExample(ByVal e As PaintEventArgs)

        ' Create two rectangles and draw them to the screen.
        Dim firstRectangleF As New RectangleF(0, 0, 75, 50)
        Dim secondRectangleF As New RectangleF(100, 100, 20, 20)

        ' Convert the RectangleF structures to Rectangle structures and

        ' draw them to the screen.
        Dim firstRect As Rectangle = Rectangle.Truncate(firstRectangleF)
        Dim secondRect As Rectangle = Rectangle.Truncate(secondRectangleF)
        e.Graphics.DrawRectangle(Pens.Black, firstRect)
        e.Graphics.DrawRectangle(Pens.Red, secondRect)

        ' Get the union rectangle.
        Dim unionRectangleF As RectangleF = _
        RectangleF.Union(firstRectangleF, secondRectangleF)

        ' Draw the unionRectangleF to the screen.
        Dim unionRect As Rectangle = Rectangle.Truncate(unionRectangleF)
        e.Graphics.DrawRectangle(Pens.Blue, unionRect)
    End Sub