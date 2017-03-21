        private void AddLinesExample(PaintEventArgs e)
        {
                     
            // Create a symetrical triangle using an array of points.
            Point[] myArray =
                     {
                         new Point(30,30),
                         new Point(60,60),
                         new Point(0,60),
                         new Point(30,30)
                     };
                     
            //Create a path and add lines.
            GraphicsPath myPath = new GraphicsPath();
            myPath.AddLines(myArray);
                     
            // Draw the path to the screen.
            Pen myPen = new Pen(Color.Black, 2);
            e.Graphics.DrawPath(myPen, myPath);
        }