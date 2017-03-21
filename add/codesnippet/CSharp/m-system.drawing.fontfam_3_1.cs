        public void GetEmHeight_Example(PaintEventArgs e)
        {
            // Create a FontFamily object.
            FontFamily emFontFamily = new FontFamily("arial");
                     
            // Get the em height of the font family in design units.
            int emHeight = emFontFamily.GetEmHeight(FontStyle.Regular);
                     
            // Draw the result as a string to the screen.
            e.Graphics.DrawString(
                "emFontFamily.GetEmHeight() returns " + emHeight.ToString() + ".",
                new Font(emFontFamily, 16),
                Brushes.Black,
                new PointF(0, 0));
        }