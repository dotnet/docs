        private void IntersectClipRectangleF2(PaintEventArgs e)
        {

            // Set clipping region.
            Rectangle clipRect = new Rectangle(0, 0, 200, 200);
            e.Graphics.SetClip(clipRect);

            // Update clipping region to intersection of

            // existing region with specified rectangle.
            RectangleF intersectRectF = new RectangleF(100.0F, 100.0F, 200.0F, 200.0F);
            e.Graphics.IntersectClip(intersectRectF);

            // Fill rectangle to demonstrate effective clipping region.
            e.Graphics.FillRectangle(new SolidBrush(Color.Blue), 0, 0, 500, 500);

            // Reset clipping region to infinite.
            e.Graphics.ResetClip();

            // Draw clipRect and intersectRect to screen.
            e.Graphics.DrawRectangle(new Pen(Color.Black), clipRect);
            e.Graphics.DrawRectangle(new Pen(Color.Red), Rectangle.Round(intersectRectF));
        }