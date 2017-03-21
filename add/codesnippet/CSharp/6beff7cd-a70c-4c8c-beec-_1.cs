        private void Clone_Example2(PaintEventArgs e)
        {

            // Create a Bitmap object from a file.
            Bitmap myBitmap = new Bitmap("Grapes.jpg");

            // Clone a portion of the Bitmap object.
            RectangleF cloneRect = new RectangleF(0, 0, 100, 100);
            System.Drawing.Imaging.PixelFormat format =
                myBitmap.PixelFormat;
            Bitmap cloneBitmap = myBitmap.Clone(cloneRect, format);

            // Draw the cloned portion of the Bitmap object.
            e.Graphics.DrawImage(cloneBitmap, 0, 0);
        }