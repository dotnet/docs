        public void FillEllipseInt(PaintEventArgs e)
        {
                     
            // Create solid brush.
            SolidBrush redBrush = new SolidBrush(Color.Red);
                     
            // Create location and size of ellipse.
            int x = 0;
            int y = 0;
            int width = 200;
            int height = 100;
                     
            // Fill ellipse on screen.
            e.Graphics.FillEllipse(redBrush, x, y, width, height);
        }