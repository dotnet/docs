    private void HighlightACharacterRange(PaintEventArgs e)
    {

        // Declare the string to draw.
        string message = "This is the string to highlight a word in.";

        // Declare the word to highlight.
        string searchWord = "string";

        // Create a CharacterRange array with the searchWord 
        // location and length.
        CharacterRange[] ranges = 
            new CharacterRange[]{new CharacterRange
            (message.IndexOf(searchWord), searchWord.Length)};

        // Construct a StringFormat object.
        StringFormat stringFormat1 = new StringFormat();

        // Set the ranges on the StringFormat object.
        stringFormat1.SetMeasurableCharacterRanges(ranges);

        // Declare the font to write the message in.
        Font largeFont = new Font(FontFamily.GenericSansSerif, 16.0F,
            GraphicsUnit.Pixel);

        // Construct a new Rectangle.
        Rectangle displayRectangle = new Rectangle(20, 20, 200, 100);

        // Convert the Rectangle to a RectangleF.
        RectangleF displayRectangleF = (RectangleF)displayRectangle;

        // Get the Region to highlight by calling the 
        // MeasureCharacterRanges method.
        Region[] charRegion = e.Graphics.MeasureCharacterRanges(message, 
            largeFont, displayRectangleF, stringFormat1);

        // Draw the message string on the form.
        e.Graphics.DrawString(message, largeFont, Brushes.Blue, 
            displayRectangleF);

        // Fill in the region using a semi-transparent color.
        e.Graphics.FillRegion(new SolidBrush(Color.FromArgb(50, Color.Fuchsia)), 
            charRegion[0]);

        largeFont.Dispose();

    }