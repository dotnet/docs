        private void SetGammaExample(PaintEventArgs e)
        {
                     
            // Create an Image object from the file Camera.jpg, and draw it to
            // the screen.
            Image myImage = Image.FromFile("Camera.jpg");
            e.Graphics.DrawImage(myImage, 20, 20);
                     
            // Create an ImageAttributes object and set the gamma to 2.2.
            System.Drawing.Imaging.ImageAttributes imageAttr = 
                   new System.Drawing.Imaging.ImageAttributes();
            imageAttr.SetGamma(2.2f);
                     
            // Draw the image with gamma set to 2.2.
            Rectangle rect = new Rectangle(250, 20, 200, 200);
            e.Graphics.DrawImage(myImage, rect, 0, 0, 200, 200, 
                GraphicsUnit.Pixel, imageAttr);    
        }