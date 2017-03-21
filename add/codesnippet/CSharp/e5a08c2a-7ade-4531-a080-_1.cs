        private void FillRectangleRectangleF(PaintEventArgs e)
        {

            // Create solid brush.
            SolidBrush blueBrush = new SolidBrush(Color.Blue);

            // Create rectangle.
            RectangleF rect = new RectangleF(0.0F, 0.0F, 200.0F, 200.0F);

            // Fill rectangle to screen.
            e.Graphics.FillRectangle(blueBrush, rect);
        }