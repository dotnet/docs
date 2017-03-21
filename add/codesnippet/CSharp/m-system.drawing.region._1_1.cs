        public void Complement_Region_Example(PaintEventArgs e)
        {
                     
            // Create the first rectangle and draw it to the screen in black.
            Rectangle regionRect = new Rectangle(20, 20, 100, 100);
            e.Graphics.DrawRectangle(Pens.Black, regionRect);
                     
            // Create the second rectangle and draw it to the screen in red.
            Rectangle complementRect = new Rectangle(90, 30, 100, 100);
            e.Graphics.DrawRectangle(Pens.Red, complementRect);
                     
            // Create a region from the first rectangle.
            Region myRegion = new Region(regionRect);
                     
            // Create a complement region.
            Region complementRegion = new Region(complementRect);
                     
            // Get the complement of myRegion when combined with
                     
            // complementRegion.
            myRegion.Complement(complementRegion);
                     
            // Fill the complement area with blue.
            SolidBrush myBrush = new SolidBrush(Color.Blue);
            e.Graphics.FillRegion(myBrush, myRegion);
        }