        public void DrawPathEllipse(PaintEventArgs e)
        {
                     
            // Create graphics path object and add ellipse.
            GraphicsPath graphPath = new GraphicsPath();
            graphPath.AddEllipse(0, 0, 200, 100);
                     
            // Create pen.
            Pen blackPen = new Pen(Color.Black, 3);
                     
            // Draw graphics path to screen.
            e.Graphics.DrawPath(blackPen, graphPath);
        }