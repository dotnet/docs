        private void AddRectanglesExample(PaintEventArgs e)
        {
                     
            // Adds a pattern of rectangles to a GraphicsPath object.
            GraphicsPath myPath = new GraphicsPath();
            Rectangle[] pathRects =
                     {
                         new Rectangle(20,20,100,200),
                         new Rectangle(40,40,120,220),
                         new Rectangle(60,60,240,140)
                     };
            myPath.AddRectangles(pathRects);
                     
            // Draw the path to the screen.
            Pen myPen = new Pen(Color.Black, 2);
            e.Graphics.DrawPath(myPen, myPath);
        }