

        private void DemonstrateGetHbitmapWithColor()
        {
            Bitmap bm = new Bitmap("Picture.jpg");
            IntPtr hBitmap = bm.GetHbitmap(Color.Blue);

            // Do something with hBitmap.
            DeleteObject(hBitmap);
        }