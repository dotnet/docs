        public void ToString_Example(PaintEventArgs e)
        {
            // Create a FontFamily object.
            FontFamily myFontFamily = new FontFamily("Arial");
                     
            // Draw a string representation of myFontFamily to the screen.
            e.Graphics.DrawString(
                myFontFamily.ToString(),
                new Font(myFontFamily, 16),
                Brushes.Black,
                new PointF(0, 0));
        }