        public void RectangleFUnionExample(PaintEventArgs e)
        {
                     
            // Create two rectangles and draw them to the screen.
            RectangleF firstRectangleF = new RectangleF(0, 0, 75, 50);
            RectangleF secondRectangleF = new RectangleF(100, 100, 20, 20);
                     
            // Convert the RectangleF structures to Rectangle structures and draw them to the
                     
            // screen.
            Rectangle firstRect = Rectangle.Truncate(firstRectangleF);
            Rectangle secondRect = Rectangle.Truncate(secondRectangleF);
            e.Graphics.DrawRectangle(Pens.Black, firstRect);
            e.Graphics.DrawRectangle(Pens.Red, secondRect);
                     
            // Get the union rectangle.
            RectangleF unionRectangleF = RectangleF.Union(firstRectangleF,
                secondRectangleF);
                     
            // Draw the unionRectangleF to the screen.
            Rectangle unionRect = Rectangle.Truncate(unionRectangleF);
            e.Graphics.DrawRectangle(Pens.Blue, unionRect);
        }