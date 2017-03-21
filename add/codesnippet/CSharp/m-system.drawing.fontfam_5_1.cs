        public void GetCellDescent_Example(PaintEventArgs e)
        {
            // Create a FontFamily object.
            FontFamily descentFontFamily = new FontFamily("arial");
                     
            // Get the cell descent of the font family in design units.
            int cellDescent = descentFontFamily.GetCellDescent(FontStyle.Regular);
                     
            // Draw the result as a string to the screen.
            e.Graphics.DrawString(
                "descentFontFamily.GetCellDescent() returns " + cellDescent.ToString() + ".",
                new Font(descentFontFamily, 16),
                Brushes.Black,
                new PointF(0, 0));
        }