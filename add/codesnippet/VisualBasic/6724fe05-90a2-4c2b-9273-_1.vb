    Public Sub DrawRectanglesRectangleF(ByVal e As PaintEventArgs)

        ' Create pen.
        Dim blackPen As New Pen(Color.Black, 3)

        ' Create array of rectangles.
        Dim rects As RectangleF() = {New RectangleF(0.0F, 0.0F, 100.0F, 200.0F), _
        New RectangleF(100.0F, 200.0F, 250.0F, 50.0F), _
        New RectangleF(300.0F, 0.0F, 50.0F, 100.0F)}

        ' Draw rectangles to screen.
        e.Graphics.DrawRectangles(blackPen, rects)
    End Sub