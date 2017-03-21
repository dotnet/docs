        public void DrawLinesPointF(PaintEventArgs e)
        {
                     
            // Create pen.
            Pen pen = new Pen(Color.Black, 3);
                     
            // Create array of points that define lines to draw.
            PointF[] points =
                     {
                         new PointF(10.0F,  10.0F),
                         new PointF(10.0F, 100.0F),
                         new PointF(200.0F,  50.0F),
                         new PointF(250.0F, 300.0F)
                     };
                     
            //Draw lines to screen.
            e.Graphics.DrawLines(pen, points);
        }