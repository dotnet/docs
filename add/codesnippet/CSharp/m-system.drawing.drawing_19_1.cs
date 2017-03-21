        private void CloseFigureExample(PaintEventArgs e)
        {
                     
            // Create a path consisting of two, open-ended lines and close
                     
            // the lines using CloseFigure.
            GraphicsPath myPath = new GraphicsPath();
            myPath.StartFigure();
            myPath.AddLine(new Point(10, 10), new Point(200, 10));
            myPath.AddLine(new Point(200, 10), new Point(200, 200));
            myPath.CloseFigure();
                     
            // Draw the path to the screen.
            e.Graphics.DrawPath(Pens.Black, myPath);
        }