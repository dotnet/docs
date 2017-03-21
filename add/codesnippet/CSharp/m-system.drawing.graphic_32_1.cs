        private void IntersectClipRectangle(PaintEventArgs e)
        {

            // Set clipping region.
            Rectangle clipRect = new Rectangle(0, 0, 200, 200);
            e.Graphics.SetClip(clipRect);

            // Update clipping region to intersection of

            // existing region with specified rectangle.
            Rectangle intersectRect = new Rectangle(100, 100, 200, 200);
            e.Graphics.IntersectClip(intersectRect);

            // Fill rectangle to demonstrate effective clipping region.
            e.Graphics.FillRectangle(new SolidBrush(Color.Blue), 0, 0, 500, 500);

            // Reset clipping region to infinite.
            e.Graphics.ResetClip();

            // Draw clipRect and intersectRect to screen.
            e.Graphics.DrawRectangle(new Pen(Color.Black), clipRect);
            e.Graphics.DrawRectangle(new Pen(Color.Red), intersectRect);
        }