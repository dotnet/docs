        public void GetHashCode_Example(PaintEventArgs e)
        {
            // Create a FontFamily object.
            FontFamily myFontFamily = new FontFamily("Arial");
                     
            // Get the hash code for myFontFamily.
            int hashCode = myFontFamily.GetHashCode();
                     
            // Draw the value of hashCode to the screen as a string.
            e.Graphics.DrawString(
                "hashCode = " + hashCode.ToString(),
                new Font(myFontFamily, 16),
                Brushes.Black,
                new PointF(0, 0));
        }