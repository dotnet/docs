    Public Sub RectangleInflateTest2(ByVal e As PaintEventArgs)

        ' Create a rectangle.
        Dim rect As New Rectangle(100, 100, 50, 50)

        ' Draw the uninflated rect to screen.
        e.Graphics.DrawRectangle(Pens.Black, rect)

        ' Set up the inflate size.
        Dim inflateSize As New Size(50, 50)

        ' Call Inflate.
        rect.Inflate(inflateSize)

        ' Draw the inflated rect to screen.
        e.Graphics.DrawRectangle(Pens.Red, rect)
    End Sub