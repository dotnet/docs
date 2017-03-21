        public void DrawImageUnscaledPoint(PaintEventArgs e)
        {
                     
            // Create image.
            Image newImage = Image.FromFile("SampImag.jpg");
                     
            // Create point for upper-left corner of image.
            Point ulCorner = new Point(100, 100);
                     
            // Draw image to screen.
            e.Graphics.DrawImageUnscaled(newImage, ulCorner);
        }