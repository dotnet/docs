        private void AddCurveExample(PaintEventArgs e)
        {
                     
            // Create some points.
            Point point1 = new Point(20, 20);
            Point point2 = new Point(40, 0);
            Point point3 = new Point(60, 40);
            Point point4 = new Point(80, 20);
                     
            // Create an array of the points.
            Point[] curvePoints = {point1, point2, point3, point4};
                     
            // Create a GraphicsPath object and add a curve.
            GraphicsPath myPath = new GraphicsPath();
            myPath.AddCurve(curvePoints, 0, 3, 0.8f);
                     
            // Draw the path to the screen.
            Pen myPen = new Pen(Color.Black, 2);
            e.Graphics.DrawPath(myPen, myPath);
        }