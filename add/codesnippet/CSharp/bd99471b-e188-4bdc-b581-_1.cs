
        // Define DrawImageAbort callback method.
        private bool DrawImageCallback1(IntPtr callBackData)
        {
                     
            // Test for call that passes callBackData parameter.
            if(callBackData==IntPtr.Zero)
            {
                     
                // If no callBackData passed, abort DrawImage method.
                return true;
            }
            else
            {
                     
                // If callBackData passed, continue DrawImage method.
                return false;
            }
        }
        private void DrawImageParaRectAttribAbort(PaintEventArgs e)
        {
                     
            // Create callback method.
            Graphics.DrawImageAbort imageCallback
                = new Graphics.DrawImageAbort(DrawImageCallback1);
                     
            // Create image.
            Image newImage = Image.FromFile("SampImag.jpg");
                     
            // Create parallelogram for drawing original image.
            Point ulCorner = new Point(100, 100);
            Point urCorner = new Point(550, 100);
            Point llCorner = new Point(150, 250);
            Point[] destPara1 = {ulCorner, urCorner, llCorner};
                     
            // Create rectangle for source image.
            Rectangle srcRect = new Rectangle(50, 50, 150, 150);
            GraphicsUnit units = GraphicsUnit.Pixel;
                     
            // Draw original image to screen.
            e.Graphics.DrawImage(newImage, destPara1, srcRect, units);
                     
            // Create parallelogram for drawing adjusted image.
            Point ulCorner2 = new Point(325, 100);
            Point urCorner2 = new Point(550, 100);
            Point llCorner2 = new Point(375, 250);
            Point[] destPara2 = {ulCorner2, urCorner2, llCorner2};
                     
            // Create image attributes and set large gamma.
            ImageAttributes imageAttr = new ImageAttributes();
            imageAttr.SetGamma(4.0F);
            try
            {
                checked
                {
                     
                    // Draw image to screen.
                    e.Graphics.DrawImage(
                        newImage,
                        destPara2,
                        srcRect,
                        units,
                        imageAttr,
                        imageCallback);
                }
            }
            catch (Exception ex)
            {
                e.Graphics.DrawString(
                    ex.ToString(),
                    new Font("Arial", 8),
                    Brushes.Black,
                    new PointF(0, 0));
            }
        }