        public void GetLineSpacing_Example(PaintEventArgs e)
        {
            // Create a FontFamily object.
            FontFamily myFontFamily = new FontFamily("Arial");
                     
            // Get the line spacing for myFontFamily.
            int lineSpacing = myFontFamily.GetLineSpacing(FontStyle.Regular);
                     
            // Draw the value of lineSpacing to the screen as a string.
            e.Graphics.DrawString(
                "lineSpacing = " + lineSpacing.ToString(),
                new Font(myFontFamily, 16),
                Brushes.Black,
                new PointF(0, 0));
        }