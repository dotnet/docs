    Public Sub DrawRectangleRectangle(ByVal e As PaintEventArgs)

        ' Create pen.
        Dim blackPen As New Pen(Color.Black, 3)

        ' Create rectangle.
        Dim rect As New Rectangle(0, 0, 200, 200)

        ' Draw rectangle to screen.
        e.Graphics.DrawRectangle(blackPen, rect)
    End Sub