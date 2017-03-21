
        [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = CharSet.Auto)]
        extern static bool DestroyIcon(IntPtr handle);

        private void GetHicon_Example(PaintEventArgs e)
        {

            // Create a Bitmap object from an image file.
            Bitmap myBitmap = new Bitmap(@"c:\FakePhoto.jpg");

            // Draw myBitmap to the screen.
            e.Graphics.DrawImage(myBitmap, 0, 0);

            // Get an Hicon for myBitmap.
            IntPtr Hicon = myBitmap.GetHicon();

            // Create a new icon from the handle. 
            Icon newIcon = Icon.FromHandle(Hicon);

            // Set the form Icon attribute to the new icon.
            this.Icon = newIcon;

            // You can now destroy the icon, since the form creates
            // its own copy of the icon accessible through the Form.Icon property.
            DestroyIcon(newIcon.Handle);

        }