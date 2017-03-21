        private void DrawImageRect4IntAtrrib(PaintEventArgs e)
        {
                     
            // Create image.
            Image newImage = Image.FromFile("SampImag.jpg");
                     
            // Create rectangle for displaying original image.
            Rectangle destRect1 = new Rectangle(100, 25, 450, 150);
                     
            // Create coordinates of rectangle for source image.
            int x = 50;
            int y = 50;
            int width = 150;
            int height = 150;
            GraphicsUnit units = GraphicsUnit.Pixel;
                     
            // Draw original image to screen.
            e.Graphics.DrawImage(newImage, destRect1, x, y, width, height, units);
                     
            // Create rectangle for adjusted image.
            Rectangle destRect2 = new Rectangle(100, 175, 450, 150);
                     
            // Create image attributes and set large gamma.
            ImageAttributes imageAttr = new ImageAttributes();
            imageAttr.SetGamma(4.0F);
                     
            // Draw adjusted image to screen.
            e.Graphics.DrawImage(newImage, destRect2, x, y, width, height, units, imageAttr);
        }