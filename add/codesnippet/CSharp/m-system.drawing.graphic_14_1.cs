        [System.Runtime.InteropServices.DllImportAttribute("gdi32.dll")]
        private static extern bool Rectangle2(
            IntPtr hdc,
            int ulCornerX, int ulCornerY,
            int lrCornerX, int lrCornerY);

        [System.Security.Permissions.SecurityPermission(
        System.Security.Permissions.SecurityAction.LinkDemand, Flags = 
        System.Security.Permissions.SecurityPermissionFlag.UnmanagedCode)]            
        private void GetHdcForGDI2(PaintEventArgs e)
        {

            // Create pen.
            Pen redPen = new Pen(Color.Red, 1);

            // Draw rectangle with GDI+.
            e.Graphics.DrawRectangle(redPen, 10, 10, 100, 50);

            // Get handle to device context.
            IntPtr hdc = e.Graphics.GetHdc();

            // Draw rectangle with GDI using default pen.
            Rectangle2(hdc, 10, 70, 110, 120);

            // Release handle to device context.
            e.Graphics.ReleaseHdc(hdc);
        }