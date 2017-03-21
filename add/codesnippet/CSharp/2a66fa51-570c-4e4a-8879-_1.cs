        private void SetClipRegionCombine(PaintEventArgs e)
        {

            // Create region for clipping.
            Region clipRegion = new Region(new Rectangle(0, 0, 100, 100));

            // Set clipping region of graphics to region.
            e.Graphics.SetClip(clipRegion, CombineMode.Replace);

            // Fill rectangle to demonstrate clip region.
            e.Graphics.FillRectangle(new SolidBrush(Color.Black), 0, 0, 500, 300);
        }