        [System.Runtime.InteropServices.DllImportAttribute("user32.dll", CharSet = CharSet.Unicode)]
        private static extern IntPtr LoadImage(int Hinstance,
            string name, int type, int width, int height, int load);

        private void Hicon_Example(PaintEventArgs e)
        {

            // Get a handle to an icon.
            IntPtr Hicon = LoadImage(0, "smile.ico", 1, 0, 0, 16);

            // Create a Bitmap object from the icon handle.
            Bitmap iconBitmap = Bitmap.FromHicon(Hicon);

            // Draw the Bitmap object to the screen.
            e.Graphics.DrawImage(iconBitmap, 0, 0);
        }