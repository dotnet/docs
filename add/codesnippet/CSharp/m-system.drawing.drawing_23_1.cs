        private void CloseAllFiguresExample(PaintEventArgs e)
        {
                     
            // Create a path containing several open-ended figures.
            GraphicsPath myPath = new GraphicsPath();
            myPath.StartFigure();
            myPath.AddLine(new Point(10, 10), new Point(150, 10));
            myPath.AddLine(new Point(150, 10), new Point(10, 150));
            myPath.StartFigure();
            myPath.AddArc(200, 200, 100, 100, 0, 90);
            myPath.StartFigure();
            Point point1 = new Point(300, 300);
            Point point2 = new Point(400, 325);
            Point point3 = new Point(400, 375);
            Point point4 = new Point(300, 400);
            Point[] points = {point1, point2, point3, point4};
            myPath.AddCurve(points);
                     
            // Close all the figures.
            myPath.CloseAllFigures();
                     
            // Draw the path to the screen.
            e.Graphics.DrawPath(new Pen(Color.Black, 3), myPath);
        }