        public void DrawRectangleInt(PaintEventArgs e)
        {
                     
            // Create pen.
            Pen blackPen = new Pen(Color.Black, 3);
                     
            // Create location and size of rectangle.
            int x = 0;
            int y = 0;
            int width = 200;
            int height = 200;
                     
            // Draw rectangle to screen.
            e.Graphics.DrawRectangle(blackPen, x, y, width, height);
        }