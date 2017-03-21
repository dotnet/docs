        private void DrawImagePara(PaintEventArgs e)
        {
            // Create image.
            Image newImage = Image.FromFile("SampImag.jpg");
                     
            // Create parallelogram for drawing image.
            Point ulCorner = new Point(100, 100);
            Point urCorner = new Point(550, 100);
            Point llCorner = new Point(150, 250);
            Point[] destPara = {ulCorner, urCorner, llCorner};
                     
            // Draw image to screen.
            e.Graphics.DrawImage(newImage, destPara);
        }