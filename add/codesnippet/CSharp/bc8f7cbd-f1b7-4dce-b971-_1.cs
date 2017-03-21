        private void DrawImageParaFRectF(PaintEventArgs e)
        {
                     
            // Create image.
            Image newImage = Image.FromFile("SampImag.jpg");
                     
            // Create parallelogram for drawing image.
            PointF ulCorner = new PointF(100.0F, 100.0F);
            PointF urCorner = new PointF(550.0F, 100.0F);
            PointF llCorner = new PointF(150.0F, 250.0F);
            PointF[] destPara = {ulCorner, urCorner, llCorner};
                     
            // Create rectangle for source image.
            RectangleF srcRect = new RectangleF(50.0F, 50.0F, 150.0F, 150.0F);
            GraphicsUnit units = GraphicsUnit.Pixel;
                     
            // Draw image to screen.
            e.Graphics.DrawImage(newImage, destPara, srcRect, units);
        }