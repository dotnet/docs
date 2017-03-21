        public void DrawImage2Int(PaintEventArgs e)
        {
                        
            // Create image.
            Image newImage = Image.FromFile("SampImag.jpg");
                        
            // Create coordinates for upper-left corner of image.
            int x = 100;
            int y = 100;
                        
            // Draw image to screen.
            e.Graphics.DrawImage(newImage, x, y);
        }