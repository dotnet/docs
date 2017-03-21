    Public Sub RectangleInflateTest(ByVal e As PaintEventArgs)

        ' Create a rectangle.
        Dim rect As New Rectangle(100, 100, 50, 50)

        ' Draw the uninflated rectangle to screen.
        e.Graphics.DrawRectangle(Pens.Black, rect)

        ' Call Inflate.
        Dim rect2 As Rectangle = Rectangle.Inflate(rect, 50, 50)

        ' Draw the inflated rectangle to screen.
        e.Graphics.DrawRectangle(Pens.Red, rect2)
    End Sub