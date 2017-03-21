        private void AddArcExample(PaintEventArgs e)
        {
                     
            // Create a GraphicsPath object.
            GraphicsPath myPath = new GraphicsPath();
                     
            // Set up and call AddArc, and close the figure.
            Rectangle rect = new Rectangle(20, 20, 50, 100);
            myPath.StartFigure();
            myPath.AddArc(rect, 0, 180);
            myPath.CloseFigure();
                     
            // Draw the path to screen.
            e.Graphics.DrawPath(new Pen(Color.Red, 3), myPath);
        }