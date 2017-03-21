    private void ShowRectangleUnion(PaintEventArgs e)
    {

        // Declare two rectangles and draw them.
        Rectangle rectangle1 = new Rectangle(30, 40, 50, 100);
        Rectangle rectangle2 = new Rectangle(50, 60, 100, 60);
        e.Graphics.DrawRectangle(Pens.Sienna, rectangle1);
        e.Graphics.DrawRectangle(Pens.BlueViolet, rectangle2);

        // Declare a third rectangle as a union of the first two.
        Rectangle rectangle3 = Rectangle.Union(rectangle1, rectangle2);

        // Fill in the third rectangle in a semi-transparent color.
        Color transparentColor = Color.FromArgb(40, 135, 135, 255);
        e.Graphics.FillRectangle(new SolidBrush(transparentColor), rectangle3);
    }