        public void GetRegionDataExample(PaintEventArgs e)
        {
                     
            // Create a rectangle and draw it to the screen in black.
            Rectangle regionRect = new Rectangle(20, 20, 100, 100);
            e.Graphics.DrawRectangle(Pens.Black, regionRect);
                     
            // Create a region using the first rectangle.
            Region myRegion = new Region(regionRect);
                     
            // Get the RegionData for this region.
            RegionData myRegionData = myRegion.GetRegionData();
            int myRegionDataLength = myRegionData.Data.Length;
            DisplayRegionData(e, myRegionDataLength, myRegionData);
        }
                     
        // THIS IS A HELPER FUNCTION FOR GetRegionData.
        public void DisplayRegionData(PaintEventArgs e,
            int len,
            RegionData dat)
        {
                     
            // Display the result.
            int i;
            float x = 20, y = 140;
            Font myFont = new Font("Arial", 8);
            SolidBrush myBrush = new SolidBrush(Color.Black);
            e.Graphics.DrawString("myRegionData = ",
                myFont,
                myBrush,
                new PointF(x, y));
            y = 160;
            for(i = 0; i < len; i++)
            {
                if(x > 300)
                {
                    y += 20;
                    x = 20;
                }
                e.Graphics.DrawString(dat.Data[i].ToString(),
                    myFont,
                    myBrush,
                    new PointF(x, y));
                x += 30;
            }
        }