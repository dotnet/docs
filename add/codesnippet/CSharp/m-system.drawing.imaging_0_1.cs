        private void SetNoOpExample(PaintEventArgs e)
        {
                     
            // Create an Image object from the file Camera.jpg.
            Image myImage = Image.FromFile("Camera.jpg");
                     
            // Create an ImageAttributes object, and set the gamma to 0.25.
            ImageAttributes imageAttr = new ImageAttributes();
            imageAttr.SetGamma(0.25f);
                     
            // Draw the image with gamma set to 0.25.
            Rectangle rect1 = new Rectangle(20, 20, 200, 200);
            e.Graphics.DrawImage(myImage, rect1, 0, 0, 200, 200, 
                GraphicsUnit.Pixel, imageAttr);    
            
            // Call the ImageAttributes NoOp method.
            imageAttr.SetNoOp();
                     
            // Draw the image after NoOp is set, so the default gamma value
            // of 1.0 will be used.
            Rectangle rect2 = new Rectangle(250, 20, 200, 200);
            e.Graphics.DrawImage(myImage, rect2, 0, 0, 200, 200, 
                GraphicsUnit.Pixel, imageAttr);    
        }