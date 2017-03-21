        public void FromHtml_Example(PaintEventArgs e)
        {
            // Create a string representation of an HTML color.
            string htmlColor = "Blue";
                     
            // Translate htmlColor to a GDI+ Color structure.
            Color myColor = ColorTranslator.FromHtml(htmlColor);
                     
            // Fill a rectangle with myColor.
            e.Graphics.FillRectangle( new SolidBrush(myColor), 0, 0, 
                100, 100);
        }