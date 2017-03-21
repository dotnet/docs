    Public Sub DrawRectanglesRectangle(ByVal e As PaintEventArgs)

        ' Create pen.
        Dim blackPen As New Pen(Color.Black, 3)

        ' Create array of rectangles.
        Dim rects As Rectangle() = {New Rectangle(0, 0, 100, 200), _
        New Rectangle(100, 200, 250, 50), _
        New Rectangle(300, 0, 50, 100)}

        ' Draw rectangles to screen.
        e.Graphics.DrawRectangles(blackPen, rects)
    End Sub