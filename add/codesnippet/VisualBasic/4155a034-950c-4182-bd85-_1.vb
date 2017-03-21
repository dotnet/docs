    Private Sub DrawEllipseRectangle(ByVal e As PaintEventArgs)

        ' Create pen.
        Dim blackPen As New Pen(Color.Black, 3)

        ' Create rectangle for ellipse.
        Dim rect As New Rectangle(0, 0, 200, 100)

        ' Draw ellipse to screen.
        e.Graphics.DrawEllipse(blackPen, rect)
    End Sub