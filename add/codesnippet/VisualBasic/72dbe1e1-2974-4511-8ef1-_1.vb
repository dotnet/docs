    Private Sub DrawEllipseInt(ByVal e As PaintEventArgs)

        ' Create pen.
        Dim blackPen As New Pen(Color.Black, 3)

        ' Create location and size of ellipse.
        Dim x As Integer = 0
        Dim y As Integer = 0
        Dim width As Integer = 200
        Dim height As Integer = 100

        ' Draw ellipse to screen.
        e.Graphics.DrawEllipse(blackPen, x, y, width, height)
    End Sub