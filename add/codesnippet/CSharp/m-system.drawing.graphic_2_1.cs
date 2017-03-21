        private void SetClipPath(PaintEventArgs e)
        {

            // Create graphics path.
            GraphicsPath clipPath = new GraphicsPath();
            clipPath.AddEllipse(0, 0, 200, 100);

            // Set clipping region to path.
            e.Graphics.SetClip(clipPath);

            // Fill rectangle to demonstrate clipping region.
            e.Graphics.FillRectangle(new SolidBrush(Color.Black), 0, 0, 500, 300);
        }