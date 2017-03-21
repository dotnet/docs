        public void RectangleFIntersectExample(PaintEventArgs e)
        {
                     
            // Create two rectangles.
            RectangleF firstRectangleF = new RectangleF(0, 0, 75, 50);
            RectangleF secondRectangleF = new RectangleF(50, 20, 50, 50);
                     
            // Convert the RectangleF structures to Rectangle structures and draw them to the
                     
            // screen.
            Rectangle firstRect = Rectangle.Truncate(firstRectangleF);
            Rectangle secondRect = Rectangle.Truncate(secondRectangleF);
            e.Graphics.DrawRectangle(Pens.Black, firstRect);
            e.Graphics.DrawRectangle(Pens.Red, secondRect);
                     
            // Get the intersection.
            RectangleF intersectRectangleF =
                RectangleF.Intersect(firstRectangleF,
                secondRectangleF);
                     
            // Draw the intersectRectangleF to the screen.
            Rectangle intersectRect =
                Rectangle.Truncate(intersectRectangleF);
            e.Graphics.DrawRectangle(Pens.Blue, intersectRect);
        }