        private void IsVisibleRectangle(PaintEventArgs e)
        {

            // Set clip region.
            Region clipRegion = new Region(new Rectangle(50, 50, 100, 100));
            e.Graphics.SetClip(clipRegion, CombineMode.Replace);

            // Set up coordinates of rectangles.
            Rectangle rect1 = new Rectangle(100, 100, 20, 20);
            Rectangle rect2 = new Rectangle(200, 200, 20, 20);

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