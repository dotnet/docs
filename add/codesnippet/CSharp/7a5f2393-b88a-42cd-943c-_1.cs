        public void DrawLinePoint(PaintEventArgs e)
        {
                     
            // Create pen.
            Pen blackPen = new Pen(Color.Black, 3);
                     
            // Create points that define line.
            Point point1 = new Point(100, 100);
            Point point2 = new Point(500, 100);
                     
            // Draw line to screen.
            e.Graphics.DrawLine(blackPen, point1, point2);
        }