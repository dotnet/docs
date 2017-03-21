    private void RoundingAndTruncatingRectangles(PaintEventArgs e)
    {

        // Construct a new RectangleF.
        RectangleF myRectangleF = 
            new RectangleF(30.6F, 30.7F, 40.8F, 100.9F);

        // Call the Round method.
        Rectangle roundedRectangle = Rectangle.Round(myRectangleF);

        // Draw the rounded rectangle in red.
        Pen redPen = new Pen(Color.Red, 4);
        e.Graphics.DrawRectangle(redPen, roundedRectangle);

        // Call the Truncate method.
        Rectangle truncatedRectangle = Rectangle.Truncate(myRectangleF);

        // Draw the truncated rectangle in white.
        Pen whitePen = new Pen(Color.White, 4);
        e.Graphics.DrawRectangle(whitePen, truncatedRectangle);

        // Dispose of the custom pens.
        redPen.Dispose();
        whitePen.Dispose();
    }