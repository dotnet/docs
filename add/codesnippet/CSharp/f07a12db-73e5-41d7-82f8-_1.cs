        private void SetClipRectangleCombine(PaintEventArgs e)
        {

            // Create rectangle for clipping region.
            Rectangle clipRect = new Rectangle(0, 0, 100, 100);

            // Set clipping region of graphics to rectangle.
            e.Graphics.SetClip(clipRect, CombineMode.Replace);

            // Fill rectangle to demonstrate clip region.
            e.Graphics.FillRectangle(new SolidBrush(Color.Black), 0, 0, 500, 300);
        }