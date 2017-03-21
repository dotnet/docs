        public void DrawImage2IntRect(PaintEventArgs e)
        {
                     
            // Create image.
            Image newImage = Image.FromFile("SampImag.jpg");
                     
            // Create coordinates for upper-left corner of image.
            int x = 100;
            int y = 100;
                     
            // Create rectangle for source image.
            Rectangle srcRect = new Rectangle(50, 50, 150, 150);
            GraphicsUnit units = GraphicsUnit.Pixel;
                     
            // Draw image to screen.
            e.Graphics.DrawImage(newImage, x, y, srcRect, units);
        }