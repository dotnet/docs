        private void FillRectangleRectangle(PaintEventArgs e)
        {

            // Create solid brush.
            SolidBrush blueBrush = new SolidBrush(Color.Blue);

            // Create rectangle.
            Rectangle rect = new Rectangle(0, 0, 200, 200);

            // Fill rectangle to screen.
            e.Graphics.FillRectangle(blueBrush, rect);
        }