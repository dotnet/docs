        public void GetCellAscent_Example(PaintEventArgs e)
        {
            // Create a FontFamily object.
            FontFamily ascentFontFamily = new FontFamily("arial");
                     
            // Get the cell ascent of the font family in design units.
            int cellAscent = ascentFontFamily.GetCellAscent(FontStyle.Regular);
                     
            // Draw the result as a string to the screen.
            e.Graphics.DrawString(
                "ascentFontFamily.GetCellAscent() returns " + cellAscent.ToString() + ".",
                new Font(ascentFontFamily, 16),
                Brushes.Black,
                new PointF(0, 0));
        }