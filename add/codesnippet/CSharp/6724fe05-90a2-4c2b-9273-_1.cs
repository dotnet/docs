        public void DrawRectanglesRectangleF(PaintEventArgs e)
        {
                     
            // Create pen.
            Pen blackPen = new Pen(Color.Black, 3);
                     
            // Create array of rectangles.
            RectangleF[] rects =
                     {
                         new RectangleF( 0.0F,   0.0F, 100.0F, 200.0F),
                         new RectangleF(100.0F, 200.0F, 250.0F,  50.0F),
                         new RectangleF(300.0F,   0.0F,  50.0F, 100.0F)
                     };
                     
            // Draw rectangles to screen.
            e.Graphics.DrawRectangles(blackPen, rects);
        }