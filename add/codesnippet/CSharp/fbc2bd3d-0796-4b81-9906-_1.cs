        public void DrawRectanglesRectangle(PaintEventArgs e)
        {
                     
            // Create pen.
            Pen blackPen = new Pen(Color.Black, 3);
                     
            // Create array of rectangles.
            Rectangle[] rects =
                     {
                         new Rectangle( 0,   0, 100, 200),
                         new Rectangle(100, 200, 250,  50),
                         new Rectangle(300,   0,  50, 100)
                     };
                     
            // Draw rectangles to screen.
            e.Graphics.DrawRectangles(blackPen, rects);
        }