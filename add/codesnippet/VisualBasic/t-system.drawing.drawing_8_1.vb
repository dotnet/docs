        ' Create a path that consists of a single ellipse.
        Dim path As New GraphicsPath()
        path.AddEllipse(0, 0, 140, 70)

        ' Use the path to construct a brush.
        Dim pthGrBrush As New PathGradientBrush(path)

        ' Set the color at the center of the path to blue.
        pthGrBrush.CenterColor = Color.FromArgb(255, 0, 0, 255)

        ' Set the color along the entire boundary 
        ' of the path to aqua.
        Dim colors As Color() = {Color.FromArgb(255, 0, 255, 255)}
        pthGrBrush.SurroundColors = colors

        e.Graphics.FillEllipse(pthGrBrush, 0, 0, 140, 70)
