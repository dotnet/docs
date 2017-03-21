    Public Sub FillPathEllipse(ByVal e As PaintEventArgs)

        ' Create solid brush.
        Dim redBrush As New SolidBrush(Color.Red)

        ' Create graphics path object and add ellipse.
        Dim graphPath As New GraphicsPath
        graphPath.AddEllipse(0, 0, 200, 100)

        ' Fill graphics path to screen.
        e.Graphics.FillPath(redBrush, graphPath)
    End Sub