
    protected void DrawCaps(PaintEventArgs e)
    {
        GraphicsPath hPath = new GraphicsPath();

        // Create the outline for our custom end cap.
        hPath.AddLine(new Point(0, 0), new Point(0, 5));
        hPath.AddLine(new Point(0, 5), new Point(5, 1));
        hPath.AddLine(new Point(5, 1), new Point(3, 1));

        // Construct the hook-shaped end cap.
        CustomLineCap HookCap = new CustomLineCap(null, hPath);

        // Set the start cap and end cap of the HookCap to be rounded.
        HookCap.SetStrokeCaps(LineCap.Round, LineCap.Round);

        // Create a pen and set end custom start and end
        // caps to the hook cap.
        Pen customCapPen = new Pen(Color.Black, 5);
        customCapPen.CustomStartCap = HookCap;
        customCapPen.CustomEndCap = HookCap;

        // Create a second pen using the start and end caps from
        // the hook cap.
        Pen capPen = new Pen(Color.Red, 10);
        LineCap startCap;
        LineCap endCap;
        HookCap.GetStrokeCaps(out startCap, out endCap);
        capPen.StartCap = startCap;
        capPen.EndCap = endCap;

        // Create a line to draw.
        Point[] points = { new Point(100, 100), new Point(200, 50), 
            new Point(250, 300) };

        // Draw the lines.
        e.Graphics.DrawLines(capPen, points);
        e.Graphics.DrawLines(customCapPen, points);

    }