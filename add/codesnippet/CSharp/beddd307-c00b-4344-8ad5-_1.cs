        public void FillEllipseRectangleF(PaintEventArgs e)
        {
                     
            // Create solid brush.
            SolidBrush redBrush = new SolidBrush(Color.Red);
                     
            // Create rectangle for ellipse.
            float x = 0.0F;
            float y = 0.0F;
            float width = 200.0F;
            float height = 100.0F;
            RectangleF rect = new RectangleF(x, y, width, height);
                     
            // Fill ellipse on screen.
            e.Graphics.FillEllipse(redBrush, rect);
        }