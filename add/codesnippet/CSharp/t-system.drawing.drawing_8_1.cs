        // Create a path that consists of a single ellipse.
        GraphicsPath path = new GraphicsPath();
        path.AddEllipse(0, 0, 140, 70);

        // Use the path to construct a brush.
        PathGradientBrush pthGrBrush = new PathGradientBrush(path);

        // Set the color at the center of the path to blue.
        pthGrBrush.CenterColor = Color.FromArgb(255, 0, 0, 255);

        // Set the color along the entire boundary 
        // of the path to aqua.
        Color[] colors = { Color.FromArgb(255, 0, 255, 255) };
        pthGrBrush.SurroundColors = colors;

        e.Graphics.FillEllipse(pthGrBrush, 0, 0, 140, 70);
