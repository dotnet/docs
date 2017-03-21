        private void DrawImageRect4Int(PaintEventArgs e)
        {
                     
            // Create image.
            Image newImage = Image.FromFile("SampImag.jpg");
                     
            // Create rectangle for displaying image.
            Rectangle destRect = new Rectangle(100, 100, 450, 150);
                     
            // Create coordinates of rectangle for source image.
            int x = 50;
            int y = 50;
            int width = 150;
            int height = 150;
            GraphicsUnit units = GraphicsUnit.Pixel;
                     
            // Draw image to screen.
            e.Graphics.DrawImage(newImage, destRect, x, y, width, height, units);
        }