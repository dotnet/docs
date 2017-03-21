        private void FillRegionRectangle(PaintEventArgs e)
        {

            // Create solid brush.
            SolidBrush blueBrush = new SolidBrush(Color.Blue);

            // Create rectangle for region.
            Rectangle fillRect = new Rectangle(100, 100, 200, 200);

            // Create region for fill.
            Region fillRegion = new Region(fillRect);

            // Fill region to screen.
            e.Graphics.FillRegion(blueBrush, fillRegion);
        }