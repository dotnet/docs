        public void DrawLinesPoint(PaintEventArgs e)
        {
                     
            // Create pen.
            Pen pen = new Pen(Color.Black, 3);
                     
            // Create array of points that define lines to draw.
            Point[] points =
                     {
                         new Point(10,  10),
                         new Point(10, 100),
                         new Point(200,  50),
                         new Point(250, 300)
                     };
                     
            //Draw lines to screen.
            e.Graphics.DrawLines(pen, points);
        }