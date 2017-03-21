        private void AddPolygonExample(PaintEventArgs e)
        {
                     
            // Create an array of points.
            Point[] myArray =
                     {
                         new Point(23, 20),
                         new Point(40, 10),
                         new Point(57, 20),
                         new Point(50, 40),
                         new Point(30, 40)
                     };
                     
            // Create a GraphicsPath object and add a polygon.
            GraphicsPath myPath = new GraphicsPath();
            myPath.AddPolygon(myArray);
                     
            // Draw the path to the screen.
            Pen myPen = new Pen(Color.Black, 2);
            e.Graphics.DrawPath(myPen, myPath);
        }