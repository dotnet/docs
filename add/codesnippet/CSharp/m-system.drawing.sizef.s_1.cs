    private void AddShadow(PaintEventArgs e)
    {

        // Create two SizeF objects.
        SizeF shadowSize = listBox1.Size;
        SizeF addSize = new SizeF(10.5F, 20.8F);

        // Add them together and save the result in shadowSize.
        shadowSize = shadowSize + addSize;

        // Get the location of the ListBox and convert it to a PointF.
        PointF shadowLocation = listBox1.Location;

        // Add two points to get a new location.
        shadowLocation = shadowLocation + new Size(5, 5);

        // Create a rectangleF. 
        RectangleF rectFToFill = 
            new RectangleF(shadowLocation, shadowSize);

        // Create a custom brush using a semi-transparent color, and 
        // then fill in the rectangle.
        Color customColor = Color.FromArgb(50, Color.Gray);
        SolidBrush shadowBrush = new SolidBrush(customColor);
        e.Graphics.FillRectangles(shadowBrush, new RectangleF[]{rectFToFill});

        // Dispose of the brush.
        shadowBrush.Dispose();
    }