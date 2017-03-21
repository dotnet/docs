    private void ChangePageUnit(PaintEventArgs e)
    {

        // Create a rectangle.
        Rectangle rectangle1 = new Rectangle(20, 20, 50, 100);

        // Draw its outline.
        e.Graphics.DrawRectangle(Pens.SlateBlue, rectangle1);

        // Change the page scale.  
        e.Graphics.PageUnit = GraphicsUnit.Point;

        // Draw the rectangle again.
        e.Graphics.DrawRectangle(Pens.Tomato, rectangle1);

    }