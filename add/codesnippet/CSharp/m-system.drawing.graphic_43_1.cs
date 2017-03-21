        private void GetNearestColorColor(PaintEventArgs e)
        {
            // Create solid brush with arbitrary color.
            Color arbColor = Color.FromArgb(255, 165, 63, 136);
            SolidBrush arbBrush = new SolidBrush(arbColor);

            // Fill ellipse on screen.
            e.Graphics.FillEllipse(arbBrush, 0, 0, 200, 100);

            // Get nearest color.
            Color realColor = e.Graphics.GetNearestColor(arbColor);
            SolidBrush realBrush = new SolidBrush(realColor);

            // Fill ellipse on screen.
            e.Graphics.FillEllipse(realBrush, 0, 100, 200, 100);
        }