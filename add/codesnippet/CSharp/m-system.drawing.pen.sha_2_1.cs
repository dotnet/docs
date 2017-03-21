    private void ShowLineJoin(PaintEventArgs e)
    {

        // Create a new pen.
        Pen skyBluePen = new Pen(Brushes.DeepSkyBlue);

        // Set the pen's width.
        skyBluePen.Width = 8.0F;

        // Set the LineJoin property.
        skyBluePen.LineJoin = System.Drawing.Drawing2D.LineJoin.Bevel;

        // Draw a rectangle.
        e.Graphics.DrawRectangle(skyBluePen, 
            new Rectangle(40, 40, 150, 200));

        //Dispose of the pen.
        skyBluePen.Dispose();

    }