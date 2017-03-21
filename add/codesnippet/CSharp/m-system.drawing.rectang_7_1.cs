        public void RectangleInflateTest3(PaintEventArgs e)
        {
                     
            // Create a rectangle.
            Rectangle rect = new Rectangle(100, 100, 50, 50);
                     
            // Draw the uninflated rectangle to screen.
            e.Graphics.DrawRectangle(Pens.Black, rect);
                     
            // Call Inflate.
            rect.Inflate(50, 50);
                     
            // Draw the inflated rectangle to screen.
            e.Graphics.DrawRectangle(Pens.Red, rect);
        }