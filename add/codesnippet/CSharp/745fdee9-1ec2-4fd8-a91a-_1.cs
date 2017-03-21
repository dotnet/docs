        private void AddBezierExample(PaintEventArgs e)
        {
                     
            // Create a new Path.
            GraphicsPath myPath = new GraphicsPath();
                     
            // Call AddBezier.
            myPath.StartFigure();
            myPath.AddBezier(50, 50, 70, 0, 100, 120, 150, 50);
                     
            // Close the curve.
            myPath.CloseFigure();
                     
            // Draw the path to screen.
            e.Graphics.DrawPath(new Pen(Color.Red, 2), myPath);
        }