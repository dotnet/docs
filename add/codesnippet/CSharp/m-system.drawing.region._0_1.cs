        public void Union_RectF_Example(PaintEventArgs e)
        {
                     
            // Create the first rectangle and draw it to the screen in black.
            Rectangle regionRect = new Rectangle(20, 20, 100, 100);
            e.Graphics.DrawRectangle(Pens.Black, regionRect);
                     
            // create the second rectangle and draw it to the screen in red.
            RectangleF unionRect = new RectangleF(90, 30, 100, 100);
            e.Graphics.DrawRectangle(Pens.Red,
                Rectangle.Round(unionRect));
                     
            // Create a region using the first rectangle.
            Region myRegion = new Region(regionRect);
                     
            // Get the area of union for myRegion when combined with
                     
            // complementRect.
            myRegion.Union(unionRect);
                     
            // Fill the union area of myRegion with blue.
            SolidBrush myBrush = new SolidBrush(Color.Blue);
            e.Graphics.FillRegion(myBrush, myRegion);
        }