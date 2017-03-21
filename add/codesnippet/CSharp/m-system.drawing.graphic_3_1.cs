        public void ExcludeClipRegion(PaintEventArgs e)
        {
                     
            // Create rectangle for region.
            Rectangle excludeRect = new Rectangle(100, 100, 200, 200);
                     
            // Create region for exclusion.
            Region excludeRegion = new Region(excludeRect);
                     
            // Set clipping region to exclude region.
            e.Graphics.ExcludeClip(excludeRegion);
                     
            // Fill large rectangle to show clipping region.
            e.Graphics.FillRectangle(new SolidBrush(Color.Blue), 0, 0, 300, 300);
        }