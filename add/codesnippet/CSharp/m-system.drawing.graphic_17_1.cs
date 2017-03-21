        private void FromHwndHwnd(PaintEventArgs e)
        {

            // Get handle to form.
            IntPtr hwnd = this.Handle;

            // Create new graphics object using handle to window.
            Graphics newGraphics = Graphics.FromHwnd(hwnd);

            // Draw rectangle to screen.
            newGraphics.DrawRectangle(new Pen(Color.Red, 3), 0, 0, 200, 100);

            // Dispose of new graphics.
            newGraphics.Dispose();
        }