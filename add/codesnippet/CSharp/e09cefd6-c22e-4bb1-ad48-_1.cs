        private void Clone_Example1(PaintEventArgs e)
        {

            // Create a Bitmap object from a file.
            Bitmap myBitmap = new Bitmap("Grapes.jpg");

            // Clone a portion of the Bitmap object.
            Rectangle cloneRect = new Rectangle(0, 0, 100, 100);
            System.Drawing.Imaging.PixelFormat format =
                myBitmap.PixelFormat;
            Bitmap cloneBitmap = myBitmap.Clone(cloneRect, format);

            // Draw the cloned portion of the Bitmap object.
            e.Graphics.DrawImage(cloneBitmap, 0, 0);
        }