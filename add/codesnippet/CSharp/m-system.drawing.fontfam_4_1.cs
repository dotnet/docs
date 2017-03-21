        public void GetName_Example(PaintEventArgs e)
        {
            // Create a FontFamily object.
            FontFamily myFontFamily = new FontFamily("Arial");
                     
            // Get the name of myFontFamily.
            string familyName = myFontFamily.GetName(0);
                     
            // Draw the name of the myFontFamily to the screen as a string.
            e.Graphics.DrawString(
                "The family name is " + familyName,
                new Font(myFontFamily, 16),
                Brushes.Black,
                new PointF(0, 0));
        }