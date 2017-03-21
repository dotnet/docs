        private void DrawImageParaRect(PaintEventArgs e)
        {
            // Create image.
            Image newImage = Image.FromFile("SampImag.jpg");
                     
            // Create parallelogram for drawing image.
            Point ulCorner = new Point(100, 100);
            Point urCorner = new Point(325, 100);
            Point llCorner = new Point(150, 250);
            Point[] destPara = {ulCorner, urCorner, llCorner};
                     
            // Create rectangle for source image.
            Rectangle srcRect = new Rectangle(50, 50, 150, 150);
            GraphicsUnit units = GraphicsUnit.Pixel;
                     
            // Draw image to screen.
            e.Graphics.DrawImage(newImage, destPara, srcRect, units);
        }