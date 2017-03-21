
        // Define DrawImageAbort callback method.
        private bool DrawImageCallback4(IntPtr callBackData)
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
        private void DrawImageParaFRectAttribAbortData(PaintEventArgs e)
        {
                     
            // Create callback method.
            Graphics.DrawImageAbort imageCallback
                = new Graphics.DrawImageAbort(DrawImageCallback4);
            int imageCallbackData = 1;
                     
            // Create image.
            Image newImage = Image.FromFile("SampImag.jpg");
                     
            // Create parallelogram for drawing original image.
            PointF ulCorner1 = new PointF(100.0F, 100.0F);
            PointF urCorner1 = new PointF(325.0F, 100.0F);
            PointF llCorner1 = new PointF(150.0F, 250.0F);
            PointF[] destPara1 = {ulCorner1, urCorner1, llCorner1};
                     
            // Create rectangle for source image.
            RectangleF srcRect = new RectangleF(50.0F, 50.0F, 150.0F, 150.0F);
            GraphicsUnit units = GraphicsUnit.Pixel;
                     
            // Create parallelogram for drawing adjusted image.
            PointF ulCorner2 = new PointF(325.0F, 100.0F);
            PointF urCorner2 = new PointF(550.0F, 100.0F);
            PointF llCorner2 = new PointF(375.0F, 250.0F);
            PointF[] destPara2 = {ulCorner2, urCorner2, llCorner2};
                     
            // Draw original image to screen.
            e.Graphics.DrawImage(newImage, destPara1, srcRect, units);
                     
            // Create image attributes and set large gamma.
            ImageAttributes imageAttr = new ImageAttributes();
            imageAttr.SetGamma(4.0F);
            try
            {
                checked
                {
                     
                    // Draw adjusted image to screen.
                    e.Graphics.DrawImage(
                        newImage,
                        destPara2,
                        srcRect,
                        units,
                        imageAttr,
                        imageCallback,
                        imageCallbackData);
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