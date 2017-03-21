        private void SetColorMatrixExample(PaintEventArgs e)
        {
                     
            // Create a rectangle image with all colors set to 128 (medium
                     
            // gray).
            Bitmap myBitmap = new Bitmap(50, 50, PixelFormat.Format32bppArgb);
            Graphics g = Graphics.FromImage(myBitmap);
            g.FillRectangle(new SolidBrush(Color.FromArgb(255, 128, 128, 128)),
                new Rectangle(0, 0, 50, 50));
            myBitmap.Save("Rectangle1.jpg");
                     
            // Open an Image file and draw it to the screen.
            Image myImage = Image.FromFile("Rectangle1.jpg");
            e.Graphics.DrawImage(myImage, 20, 20);
                     
            // Initialize the color matrix.
            ColorMatrix myColorMatrix = new ColorMatrix();
            
            // Red
            myColorMatrix.Matrix00 = 1.75f; 
            
            // Green
            myColorMatrix.Matrix11 = 1.00f; 
            
            // Blue
            myColorMatrix.Matrix22 = 1.00f; 
            
            // alpha
            myColorMatrix.Matrix33 = 1.00f; 
           
            // w
            myColorMatrix.Matrix44 = 1.00f; 
            
                     
            // Create an ImageAttributes object and set the color matrix.
            ImageAttributes imageAttr = new ImageAttributes();
            imageAttr.SetColorMatrix(myColorMatrix);
                     
            // Draw the image using the color matrix.
            Rectangle rect = new Rectangle(100, 20, 200, 200);
            e.Graphics.DrawImage(myImage, rect, 0, 0, 200, 200, 
                GraphicsUnit.Pixel, imageAttr);      
            
        }