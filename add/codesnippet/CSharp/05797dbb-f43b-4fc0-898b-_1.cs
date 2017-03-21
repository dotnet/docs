        public void SetMeasCharRangesExample(PaintEventArgs e)
        {
            Graphics     g = e.Graphics;
            SolidBrush   redBrush = new SolidBrush(Color.FromArgb(50, 255, 0, 0));
                     
            // Layout rectangles, font, and string format used for displaying string.
            Rectangle    layoutRectA = new Rectangle(20, 20, 165, 80);
            Rectangle    layoutRectB = new Rectangle(20, 110, 165, 80);
            Rectangle    layoutRectC = new Rectangle(20, 200, 240, 80);
            Font         tnrFont = new Font("Times New Roman", 16);
            StringFormat strFormat = new StringFormat();
                     
            // Ranges of character positions within a string.
            CharacterRange[] charRanges = { new CharacterRange(3, 5),
                new CharacterRange(15, 2), new CharacterRange(30, 15)};
                     
            // Each region specifies the area occupied by the characters within a
            // range of positions. the values are obtained by using a method that
            // measures the character ranges.
            Region[]     charRegions = new Region[charRanges.Length];
                     
            // String to be displayed.
            string  str =
                "The quick, brown fox easily jumps over the lazy dog.";
                     
            // Set the char ranges for the string format.
            strFormat.SetMeasurableCharacterRanges(charRanges);
           
            // loop counter (unsigned 8-bit integer)
            byte  i;    
           
            // Measure the char ranges for a given string and layout rectangle. Each
            // area occupied by the characters in a range is stored as a region. Then
            // draw the string and layout rectangle, and paint the regions.
            charRegions = g.MeasureCharacterRanges(str, tnrFont,
                layoutRectA, strFormat);
           g.DrawString(str, tnrFont, Brushes.Blue, layoutRectA, strFormat);
            g.DrawRectangle(Pens.Black, layoutRectA);
             
            // Paint the regions.
            for (i = 0; i < charRegions.Length; i++)
                g.FillRegion(redBrush, charRegions[i]);   
           
                     
            // Repeat the above steps, but include trailing spaces in the char
            // range measurement by setting the appropriate string format flag.
            strFormat.FormatFlags = StringFormatFlags.MeasureTrailingSpaces;
            charRegions = g.MeasureCharacterRanges(str, tnrFont,
                layoutRectB, strFormat);
            g.DrawString(str, tnrFont, Brushes.Blue, layoutRectB, strFormat);
            g.DrawRectangle(Pens.Black, layoutRectB);
             
            
            for (i = 0; i < charRegions.Length; i++)
                g.FillRegion(redBrush, charRegions[i]);   
           
            // Clear all the format flags.
            strFormat.FormatFlags = 0;                   
         
            // Repeat the steps, but use a different layout rectangle. the dimensions
            // of the layout rectangle and the size of the font both affect the
            // character range measurement.
            charRegions = g.MeasureCharacterRanges(str, tnrFont,
                layoutRectC, strFormat);
            g.DrawString(str, tnrFont, Brushes.Blue, layoutRectC, strFormat);
            g.DrawRectangle(Pens.Black, layoutRectC);
            
            // Paint the regions.
            for (i = 0; i < charRegions.Length; i++)
                g.FillRegion(redBrush, charRegions[i]);   
            
        }