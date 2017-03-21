        private void MeasureStringWidthFormat(PaintEventArgs e)
        {

            // Set up string.
            string measureString = "Measure String";
            Font stringFont = new Font("Arial", 16);

            // Set maximum width of string.
            int stringWidth = 100;

            // Set string format.
            StringFormat newStringFormat = new StringFormat();
            newStringFormat.FormatFlags = StringFormatFlags.DirectionVertical;

            // Measure string.
            SizeF stringSize = new SizeF();
            stringSize = e.Graphics.MeasureString(measureString, stringFont, stringWidth, newStringFormat);

            // Draw rectangle representing size of string.
            e.Graphics.DrawRectangle(new Pen(Color.Red, 1), 0.0F, 0.0F, stringSize.Width, stringSize.Height);

            // Draw string to screen.
            e.Graphics.DrawString(measureString, stringFont, Brushes.Black, new PointF(0, 0), newStringFormat);
        }