        public void IsVisible_RectF_Example(PaintEventArgs e)
        {
                     
            // Create the first rectangle and draw it to the screen in blue.
            Rectangle regionRect = new Rectangle(20, 20, 100, 100);
            e.Graphics.DrawRectangle(Pens.Blue, regionRect);
                     
            // Create the second rectangle and draw it to the screen in red.
            RectangleF myRect = new RectangleF(90, 30, 100, 100);
            e.Graphics.DrawRectangle(Pens.Red, Rectangle.Round(myRect));
                     
            // Create a region using the first rectangle.
            Region myRegion = new Region(regionRect);
                     
            // Determine if myRect is contained in the region.
            bool contained = myRegion.IsVisible(myRect);
                     
            // Display the result.
            Font myFont = new Font("Arial", 8);
            SolidBrush myBrush = new SolidBrush(Color.Black);
            e.Graphics.DrawString("contained = " + contained.ToString(),
                myFont,
                myBrush,
                new PointF(20, 140));
        }