        private void SetThresholdExample(PaintEventArgs e)
        {
                     
            // Open an Image file, and draw it to the screen.
            Image myImage = Image.FromFile("Camera.jpg");
            e.Graphics.DrawImage(myImage, 20, 20);
                     
            // Create an ImageAttributes object, and set its color threshold.
            ImageAttributes imageAttr = new ImageAttributes();
            imageAttr.SetThreshold(0.7f);
                     
            // Draw the image with the colors bifurcated.
            Rectangle rect = new Rectangle(300, 20, 200, 200);
            e.Graphics.DrawImage(myImage, rect, 0, 0, 200, 200, 
                GraphicsUnit.Pixel, imageAttr);    
        }