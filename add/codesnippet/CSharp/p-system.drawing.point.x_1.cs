    private void Button1_Click(System.Object sender, System.EventArgs e)
    {

        // Construct a new Point with integers.
        Point Point1 = new Point(100, 100);

        // Create a Graphics object.
        Graphics formGraphics = this.CreateGraphics();

        // Construct another Point, this time using a Size.
        Point Point2 = new Point(new Size(100, 100));

        // Call the equality operator to see if the points are equal,  
        // and if so print out their x and y values.
        if (Point1 == Point2)
        {
            formGraphics.DrawString(String.Format("Point1.X: " +
                "{0},Point2.X: {1}, Point1.Y: {2}, Point2.Y {3}",
                new object[]{Point1.X, Point2.X, Point1.Y, Point2.Y}),
                this.Font, Brushes.Black, new PointF(10, 70));
        }

    }