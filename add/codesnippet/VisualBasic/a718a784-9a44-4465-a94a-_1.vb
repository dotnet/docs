    Public Sub DrawPathEllipse(ByVal e As PaintEventArgs)

        ' Create graphics path object and add ellipse.
        Dim graphPath As New GraphicsPath
        graphPath.AddEllipse(0, 0, 200, 100)

        ' Create pen.
        Dim blackPen As New Pen(Color.Black, 3)

        ' Draw graphics path to screen.
        e.Graphics.DrawPath(blackPen, graphPath)
    End Sub