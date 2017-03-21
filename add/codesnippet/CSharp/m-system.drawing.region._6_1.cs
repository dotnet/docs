        public void TranslateExample(PaintEventArgs e)
        {
                     
            // Create the first rectangle and draw it to the screen in blue.
            Rectangle regionRect = new Rectangle(100, 50, 100, 100);
            e.Graphics.DrawRectangle(Pens.Blue, regionRect);
                     
            // Create a region using the first rectangle.
            Region myRegion = new Region(regionRect);
                     
            // Apply the translation to the region.
            myRegion.Translate(150, 100);
                     
            // Fill the transformed region with red and draw it to the screen in red.
            SolidBrush myBrush = new SolidBrush(Color.Red);
            e.Graphics.FillRegion(myBrush, myRegion);
        }