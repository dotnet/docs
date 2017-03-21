        private void FillRectangleInt(PaintEventArgs e)
        {

            // Create solid brush.
            SolidBrush blueBrush = new SolidBrush(Color.Blue);

            // Create location and size of rectangle.
            int x = 0;
            int y = 0;
            int width = 200;
            int height = 200;

            // Fill rectangle to screen.
            e.Graphics.FillRectangle(blueBrush, x, y, width, height);
        }