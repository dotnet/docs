    private void ShowLineAndAlignment(PaintEventArgs e)
    {

        // Construct a new Rectangle .
        Rectangle  displayRectangle = 
            new Rectangle (new Point(40, 40), new Size (80, 80));

        // Construct 2 new StringFormat objects
        StringFormat format1 = new StringFormat(StringFormatFlags.NoClip);
        StringFormat format2 = new StringFormat(format1);

        // Set the LineAlignment and Alignment properties for
        // both StringFormat objects to different values.
        format1.LineAlignment = StringAlignment.Near;
        format1.Alignment = StringAlignment.Center;
        format2.LineAlignment = StringAlignment.Center;
        format2.Alignment = StringAlignment.Far;

        // Draw the bounding rectangle and a string for each
        // StringFormat object.
        e.Graphics.DrawRectangle(Pens.Black, displayRectangle);
        e.Graphics.DrawString("Showing Format1", this.Font, 
            Brushes.Red, (RectangleF)displayRectangle, format1);
        e.Graphics.DrawString("Showing Format2", this.Font, 
            Brushes.Red, (RectangleF)displayRectangle, format2);
    }