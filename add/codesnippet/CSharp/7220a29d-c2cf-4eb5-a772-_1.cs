        public void DrawRectangleRectangle(PaintEventArgs e)
        {
                     
            // Create pen.
            Pen blackPen = new Pen(Color.Black, 3);
                     
            // Create rectangle.
            Rectangle rect = new Rectangle(0, 0, 200, 200);
                     
            // Draw rectangle to screen.
            e.Graphics.DrawRectangle(blackPen, rect);
        }