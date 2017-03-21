        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        public static extern bool DeleteObject(IntPtr hObject);


        private void DemonstrateGetHbitmap()
        {
            Bitmap bm = new Bitmap("Picture.jpg");
            IntPtr hBitmap = bm.GetHbitmap();

            // Do something with hBitmap.
            DeleteObject(hBitmap);
        }