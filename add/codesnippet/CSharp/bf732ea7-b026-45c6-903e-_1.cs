        private void MeasureStringPointFFormat(PaintEventArgs e)
        {

            // Set up string.
            string measureString = "Measure String";
            Font stringFont = new Font("Arial", 16);

            // Set point for upper-left corner of string.
            float x = 50.0F;
            float y = 50.0F;
            PointF ulCorner = new PointF(x, y);

            // Set string format.
            StringFormat newStringFormat = new StringFormat();
            newStringFormat.FormatFlags = StringFormatFlags.DirectionVertical;

            // Measure string.
            SizeF stringSize = new SizeF();
            stringSize = e.Graphics.MeasureString(measureString, stringFont, ulCorner, newStringFormat);

            // Draw rectangle representing size of string.
            e.Graphics.DrawRectangle(new Pen(Color.Red, 1), x, y, stringSize.Width, stringSize.Height);

            // Draw string to screen.
            e.Graphics.DrawString(measureString, stringFont, Brushes.Black, ulCorner, newStringFormat);
        }