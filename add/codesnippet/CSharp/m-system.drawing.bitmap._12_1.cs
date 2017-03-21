        private void MakeTransparent_Example2(PaintEventArgs e)
        {

            // Create a Bitmap object from an image file.
            Bitmap myBitmap = new Bitmap("Grapes.gif");

            // Draw myBitmap to the screen.
            e.Graphics.DrawImage(
                myBitmap, 0, 0, myBitmap.Width, myBitmap.Height);

            // Get the color of a background pixel.
            Color backColor = myBitmap.GetPixel(1, 1);

            // Make backColor transparent for myBitmap.
            myBitmap.MakeTransparent(backColor);

            // Draw the transparent bitmap to the screen.
            e.Graphics.DrawImage(
                myBitmap, myBitmap.Width, 0, myBitmap.Width, myBitmap.Height);
        }