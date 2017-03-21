        private void IsVisible4Int(PaintEventArgs e)
        {

            // Set clip region.
            Region clipRegion = new Region(new Rectangle(50, 50, 100, 100));
            e.Graphics.SetClip(clipRegion, CombineMode.Replace);

            // Set up coordinates of rectangles.
            int x1 = 100;
            int y1 = 100;
            int width1 = 20;
            int height1 = 20;
            int x2 = 200;
            int y2 = 200;
            int width2 = 20;
            int height2 = 20;

            // If rectangle is visible, fill it.
            if (e.Graphics.IsVisible(x1, y1, width1, height1))
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.Red), x1, y1, width1, height1);
            }
            if (e.Graphics.IsVisible(x2, y2, width2, height2))
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.Blue), x2, y2, width2, height2);
            }
        }