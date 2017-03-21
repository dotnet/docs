        public void DrawLineFloat(PaintEventArgs e)
        {
                     
            // Create pen.
            Pen blackPen = new Pen(Color.Black, 3);
                     
            // Create coordinates of points that define line.
            float x1 = 100.0F;
            float y1 = 100.0F;
            float x2 = 500.0F;
            float y2 = 100.0F;
                     
            // Draw line to screen.
            e.Graphics.DrawLine(blackPen, x1, y1, x2, y2);
        }