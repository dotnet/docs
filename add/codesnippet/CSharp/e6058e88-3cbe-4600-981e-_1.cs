    private void ConvertRectangleToRectangleF(PaintEventArgs e)
    {

        // Create a rectangle.
        Rectangle rectangle1 = new Rectangle(30, 40, 50, 100);

        // Convert it to a RectangleF.
        RectangleF convertedRectangle = rectangle1;

        // Create a new RectangleF.
        RectangleF rectangle2 = new RectangleF(new PointF(30.0F, 40.0F),
            new SizeF(50.0F, 100.0F));

        // Create a custom, partially transparent brush.
        SolidBrush redBrush = new SolidBrush(Color.FromArgb(40, Color.Red));

        // Compare the converted rectangle with the new one.  If they 
        // are equal draw and fill the rectangles on the form.
        if (convertedRectangle == rectangle2)
        {
            e.Graphics.FillRectangle(redBrush, rectangle2);
        }

        // Dispose of the custom brush.
        redBrush.Dispose();
    }
