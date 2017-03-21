        public void IsStyleAvailable_Example(PaintEventArgs e)
        {
            // Create a FontFamily object.
            FontFamily myFontFamily = new FontFamily("Arial");
                     
            // Test whether myFontFamily is available in Italic.
            if(myFontFamily.IsStyleAvailable(FontStyle.Italic))
            {
                     
                // Create a Font object using myFontFamily.
                Font familyFont = new Font(myFontFamily, 16, FontStyle.Italic);
                     
                // Use familyFont to draw text to the screen.
                e.Graphics.DrawString(
                    myFontFamily.Name + " is available in Italic",
                    familyFont,
                    Brushes.Black,
                    new PointF(0, 0));
            }
        }