    Private Sub DrawEllipseRectangleF(ByVal e As PaintEventArgs)

        ' Create pen.
        Dim blackPen As New Pen(Color.Black, 3)

        ' Create rectangle for ellipse.
        Dim rect As New RectangleF(0.0F, 0.0F, 200.0F, 100.0F)

        ' Draw ellipse to screen.
        e.Graphics.DrawEllipse(blackPen, rect)
    End Sub