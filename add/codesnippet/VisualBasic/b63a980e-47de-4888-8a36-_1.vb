    Private Sub DrawEllipseFloat(ByVal e As PaintEventArgs)

        ' Create pen.
        Dim blackPen As New Pen(Color.Black, 3)

        ' Create location and size of ellipse.
        Dim x As Single = 0.0F
        Dim y As Single = 0.0F
        Dim width As Single = 200.0F
        Dim height As Single = 100.0F

        ' Draw ellipse to screen.
        e.Graphics.DrawEllipse(blackPen, x, y, width, height)
    End Sub