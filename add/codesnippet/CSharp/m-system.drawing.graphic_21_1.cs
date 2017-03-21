        private void IsVisibleRectangleF(PaintEventArgs e)
        {

            // Set clip region.
            Region clipRegion = new Region(new Rectangle(50, 50, 100, 100));
            e.Graphics.SetClip(clipRegion, CombineMode.Replace);

            // Set up coordinates of rectangles.
            RectangleF rect1 = new RectangleF(100.0F, 100.0F, 20.0F, 20.0F);
            RectangleF rect2 = new RectangleF(200.0F, 200.0F, 20.0F, 20.0F);

            // If rectangle is visible, fill it.
            if (e.Graphics.IsVisible(rect1))
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.Red), rect1);
            }
            if (e.Graphics.IsVisible(rect2))
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.Blue), rect2);
            }
        }