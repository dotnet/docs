        private void MeasureCharacterRangesRegions(PaintEventArgs e)
        {

            // Set up string.
            string measureString = "First and Second ranges";
            Font stringFont = new Font("Times New Roman", 16.0F);

            // Set character ranges to "First" and "Second".
            CharacterRange[] characterRanges = { new CharacterRange(0, 5), new CharacterRange(10, 6) };

            // Create rectangle for layout.
            float x = 50.0F;
            float y = 50.0F;
            float width = 35.0F;
            float height = 200.0F;
            RectangleF layoutRect = new RectangleF(x, y, width, height);

            // Set string format.
            StringFormat stringFormat = new StringFormat();
            stringFormat.FormatFlags = StringFormatFlags.DirectionVertical;
            stringFormat.SetMeasurableCharacterRanges(characterRanges);

            // Draw string to screen.
            e.Graphics.DrawString(measureString, stringFont, Brushes.Black, x, y, stringFormat);

            // Measure two ranges in string.
            Region[] stringRegions = e.Graphics.MeasureCharacterRanges(measureString, 
		stringFont, layoutRect, stringFormat);

            // Draw rectangle for first measured range.
            RectangleF measureRect1 = stringRegions[0].GetBounds(e.Graphics);
            e.Graphics.DrawRectangle(new Pen(Color.Red, 1), Rectangle.Round(measureRect1));

            // Draw rectangle for second measured range.
            RectangleF measureRect2 = stringRegions[1].GetBounds(e.Graphics);
            e.Graphics.DrawRectangle(new Pen(Color.Blue, 1), Rectangle.Round(measureRect2));
        }