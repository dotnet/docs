        Dim path As New GraphicsPath()

        ' Add an open figure.
        path.AddArc(0, 0, 150, 120, 30, 120)

        ' Add an intrinsically closed figure.
        path.AddEllipse(50, 50, 50, 100)

        Dim pen As New Pen(Color.FromArgb(128, 0, 0, 255), 5)
        Dim brush As New SolidBrush(Color.Red)

        ' The fill mode is FillMode.Alternate by default.
        e.Graphics.FillPath(brush, path)
        e.Graphics.DrawPath(pen, path)
