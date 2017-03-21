        private void DrawBezierPoint(PaintEventArgs e)
        {
            // Create pen.
            Pen blackPen = new Pen(Color.Black, 3);
                     
            // Create points for curve.
            Point start = new Point(100, 100);
            Point control1 = new Point(200, 10);
            Point control2 = new Point(350, 50);
            Point end = new Point(500, 100);
                     
            // Draw arc to screen.
            e.Graphics.DrawBezier(blackPen, start, control1, control2, end);
        }