        private void FillRectanglesRectangleF(PaintEventArgs e)
        {

            // Create solid brush.
            SolidBrush blueBrush = new SolidBrush(Color.Blue);

            // Create array of rectangles.
            RectangleF[] rects = { new RectangleF(0.0F, 0.0F, 100.0F, 200.0F), new RectangleF(100.0F, 200.0F, 250.0F, 50.0F), new RectangleF(300.0F, 0.0F, 50.0F, 100.0F) };

            // Fill rectangles to screen.
            e.Graphics.FillRectangles(blueBrush, rects);
        }