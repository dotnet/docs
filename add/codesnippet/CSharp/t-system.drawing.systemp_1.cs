    private void CreatePointsAndSizes(PaintEventArgs e)
    {

        // Create the starting point.
        Point startPoint = new Point(subtractButton.Size);

        // Use the addition operator to get the end point.
        Point endPoint = startPoint + new Size(140, 150);

        // Draw a line between the points.
        e.Graphics.DrawLine(SystemPens.Highlight, startPoint, endPoint);

        // Convert the starting point to a size and compare it to the
        // subtractButton size.  
        Size buttonSize = (Size)startPoint;
        if (buttonSize == subtractButton.Size)

            // If the sizes are equal, tell the user.
        {
            e.Graphics.DrawString("The sizes are equal.", 
                new Font(this.Font, FontStyle.Italic), 
                Brushes.Indigo, 10.0F, 65.0F);
        }

    }