        private void DrawEllipseRectangleF(PaintEventArgs e)
        {
            // Create pen.
            Pen blackPen = new Pen(Color.Black, 3);
                     
            // Create rectangle for ellipse.
            RectangleF rect = new RectangleF(0.0F, 0.0F, 200.0F, 100.0F);
                     
            // Draw ellipse to screen.
            e.Graphics.DrawEllipse(blackPen, rect);
        }