        GraphicsPath path = new GraphicsPath();

        // Add an open figure.
        path.AddArc(0, 0, 150, 120, 30, 120);

        // Add an intrinsically closed figure.
        path.AddEllipse(50, 50, 50, 100);

        Pen pen = new Pen(Color.FromArgb(128, 0, 0, 255), 5);
        SolidBrush brush = new SolidBrush(Color.Red);

        // The fill mode is FillMode.Alternate by default.
        e.Graphics.FillPath(brush, path);
        e.Graphics.DrawPath(pen, path);