        public void FillPathEllipse(PaintEventArgs e)
        {
                     
            // Create solid brush.
            SolidBrush redBrush = new SolidBrush(Color.Red);
                     
            // Create graphics path object and add ellipse.
            GraphicsPath graphPath = new GraphicsPath();
            graphPath.AddEllipse(0, 0, 200, 100);
                     
            // Fill graphics path to screen.
            e.Graphics.FillPath(redBrush, graphPath);
        }