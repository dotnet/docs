        public void DrawImage4Float(PaintEventArgs e)
        {
                     
            // Create image.
            Image newImage = Image.FromFile("SampImag.jpg");
                     
            // Create coordinates for upper-left corner.
                     
            // of image and for size of image.
            float x = 100.0F;
            float y = 100.0F;
            float width = 450.0F;
            float height = 150.0F;
                     
            // Draw image to screen.
            e.Graphics.DrawImage(newImage, x, y, width, height);
        }