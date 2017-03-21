        public void DrawLinePointF(PaintEventArgs e)
        {
                     
            // Create pen.
            Pen blackPen = new Pen(Color.Black, 3);
                     
            // Create points that define line.
            PointF point1 = new PointF(100.0F, 100.0F);
            PointF point2 = new PointF(500.0F, 100.0F);
                     
            // Draw line to screen.
            e.Graphics.DrawLine(blackPen, point1, point2);
        }