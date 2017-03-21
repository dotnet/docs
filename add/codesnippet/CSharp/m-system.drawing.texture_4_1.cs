        public void RotateTransform_Example1(PaintEventArgs e)
        {
                     
            // Create a TextureBrush object.
            TextureBrush tBrush = new TextureBrush(new Bitmap("texture.jpg"));
                     
            // Rotate the texture image by 90 degrees.
            tBrush.RotateTransform(90);
                     
            // Fill a rectangle with tBrush.
            e.Graphics.FillRectangle(tBrush, 0, 0, 100, 100);
        }