        public void ExcludeClipRectangle(PaintEventArgs e)
        {
                     
            // Create rectangle for exclusion.
            Rectangle excludeRect = new Rectangle(100, 100, 200, 200);
                     
            // Set clipping region to exclude rectangle.
            e.Graphics.ExcludeClip(excludeRect);
                     
            // Fill large rectangle to show clipping region.
            e.Graphics.FillRectangle(new SolidBrush(Color.Blue), 0, 0, 300, 300);
        }