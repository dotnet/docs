        public void GetBoundsExample(PaintEventArgs e)
        {
                     
            // Create a GraphicsPath and add an ellipse to it.
            GraphicsPath myPath = new GraphicsPath();
            Rectangle ellipseRect = new Rectangle(20, 20, 100, 100);
            myPath.AddEllipse(ellipseRect);
                     
            // Fill the path with blue and draw it to the screen.
            SolidBrush myBrush = new SolidBrush(Color.Blue);
            e.Graphics.FillPath(myBrush, myPath);
                     
            // Create a region using the GraphicsPath.
            Region myRegion = new Region(myPath);
                     
            // Get the bounding rectangle for myRegion and draw it to the
                     
            // screen in Red.
            RectangleF boundsRect = myRegion.GetBounds(e.Graphics);
            e.Graphics.DrawRectangle(Pens.Red, Rectangle.Round(boundsRect));
        }