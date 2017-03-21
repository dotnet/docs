        private void AddPathExample(PaintEventArgs e)
        {
                     
            // Create the first pathright side up triangle.
            Point[] myArray =
                     {
                         new Point(30,30),
                         new Point(60,60),
                         new Point(0,60),
                         new Point(30,30)
                     };
            GraphicsPath myPath = new GraphicsPath();
            myPath.AddLines(myArray);
                     
            // Create the second pathinverted triangle.
            Point[] myArray2 =
                     {
                         new Point(30,30),
                         new Point(0,0),
                         new Point(60,0),
                         new Point(30,30)
                     };
            GraphicsPath myPath2 = new GraphicsPath();
            myPath2.AddLines(myArray2);
                     
            // Add the second path to the first path.
            myPath.AddPath(myPath2,true);
                     
            // Draw the combined path to the screen.
            Pen myPen = new Pen(Color.Black, 2);
            e.Graphics.DrawPath(myPen, myPath);
        }