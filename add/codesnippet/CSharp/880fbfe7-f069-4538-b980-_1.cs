        private void BitmapConstructorEx(PaintEventArgs e)
        {

            // Create a bitmap.
            Bitmap bmp = new Bitmap("c:\\fakePhoto.jpg");
            
           // Retrieve the bitmap data from the the bitmap.
            System.Drawing.Imaging.BitmapData bmpData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), 
                ImageLockMode.ReadOnly, bmp.PixelFormat);

            //Create a new bitmap.
            Bitmap newBitmap = new Bitmap(200, 200, bmpData.Stride, bmp.PixelFormat, bmpData.Scan0);

            bmp.UnlockBits(bmpData);

            // Draw the new bitmap.
            e.Graphics.DrawImage(newBitmap, 10, 10);

        }