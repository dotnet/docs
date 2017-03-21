        private void SetColorKeyExample(PaintEventArgs e)
        {
                     
            // Open an Image file and draw it to the screen.
            Image myImage = Image.FromFile("Circle.bmp");
            e.Graphics.DrawImage(myImage, 20, 20);
                     
            // Create an ImageAttributes object and set the color key.
            Color lowerColor = Color.FromArgb(245,0,0);
            Color upperColor = Color.FromArgb(255,0,0);
            ImageAttributes imageAttr = new ImageAttributes();
            imageAttr.SetColorKey(lowerColor,
                upperColor,
                ColorAdjustType.Default);
                     
            // Draw the image with the color key set.
            Rectangle rect = new Rectangle(150, 20, 100, 100);
            e.Graphics.DrawImage(myImage, rect, 0, 0, 100, 100, 
                GraphicsUnit.Pixel, imageAttr);      
            
        }