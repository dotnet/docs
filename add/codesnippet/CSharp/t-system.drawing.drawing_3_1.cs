        LinearGradientBrush linGrBrush = new LinearGradientBrush(
           new Point(0, 10),
           new Point(200, 10),
           Color.FromArgb(255, 255, 0, 0),   // Opaque red
           Color.FromArgb(255, 0, 0, 255));  // Opaque blue

        Pen pen = new Pen(linGrBrush);

        e.Graphics.DrawLine(pen, 0, 10, 200, 10);
        e.Graphics.FillEllipse(linGrBrush, 0, 30, 200, 100);
        e.Graphics.FillRectangle(linGrBrush, 0, 155, 500, 30);