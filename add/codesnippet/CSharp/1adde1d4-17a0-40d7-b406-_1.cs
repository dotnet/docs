        private void AddClosedCurveExample(PaintEventArgs e)
        {
                     
            // Creates a symetrical, closed curve.
            Point[] myArray =
                     {
                         new Point(20,100),
                         new Point(40,150),
                         new Point(60,125),
                         new Point(40,100),
                         new Point(60,75),
                         new Point(40,50)
                     };
                     
            // Create a new path and add curve.
            GraphicsPath myPath = new GraphicsPath();
            myPath.AddClosedCurve(myArray,.5f);
            Pen myPen = new Pen(Color.Black, 2);
                     
            // Draw the path to screen.
            e.Graphics.DrawPath(myPen, myPath);
        }