        private void DrawEllipseRectangle(PaintEventArgs e)
        {
            // Create pen.
            Pen blackPen = new Pen(Color.Black, 3);
                     
            // Create rectangle for ellipse.
            Rectangle rect = new Rectangle(0, 0, 200, 100);
                     
            // Draw ellipse to screen.
            e.Graphics.DrawEllipse(blackPen, rect);
        }