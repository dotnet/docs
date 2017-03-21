        private void FillRectanglesRectangle(PaintEventArgs e)
        {

            // Create solid brush.
            SolidBrush blueBrush = new SolidBrush(Color.Blue);

            // Create array of rectangles.
            Rectangle[] rects = { new Rectangle(0, 0, 100, 200), new Rectangle(100, 200, 250, 50), new Rectangle(300, 0, 50, 100) };

            // Fill rectangles to screen.
            e.Graphics.FillRectangles(blueBrush, rects);
        }