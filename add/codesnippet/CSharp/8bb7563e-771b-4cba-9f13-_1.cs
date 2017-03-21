        private void SetClipGraphicsCombine(PaintEventArgs e)
        {

            // Create temporary graphics object and set its clipping region.
            Graphics newGraphics = this.CreateGraphics();
            newGraphics.SetClip(new Rectangle(0, 0, 100, 100));

            // Update clipping region of graphics to clipping region of new

            // graphics.
            e.Graphics.SetClip(newGraphics, CombineMode.Replace);

            // Fill rectangle to demonstrate clip region.
            e.Graphics.FillRectangle(new SolidBrush(Color.Black), 0, 0, 500, 300);

            // Release new graphics.
            newGraphics.Dispose();
        }