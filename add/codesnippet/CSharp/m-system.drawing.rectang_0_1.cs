    Rectangle rectangle1 = new Rectangle(70, 70, 100, 150);

    private void DrawFirstRectangle()
    {
        ControlPaint.DrawReversibleFrame(rectangle1, 
            SystemColors.Highlight, FrameStyle.Thick);
    }

    private void Button1_Click(object sender, EventArgs e)
    {

        // Get the bounds of the screen.
        Rectangle screenRectangle = Screen.PrimaryScreen.Bounds;

        // Check to see if the rectangle is within the bounds of the screen.
        if (screenRectangle.Contains(rectangle1))

            // If so, erase the previous rectangle.
        {
            ControlPaint.DrawReversibleFrame(rectangle1, 
                SystemColors.Highlight, FrameStyle.Thick);

            // Call the Offset method to move the rectangle.
            rectangle1.Offset(20, 20);

            // Draw the new, offset rectangle.
            ControlPaint.DrawReversibleFrame(rectangle1, 
                SystemColors.Highlight, FrameStyle.Thick);
        }
    }