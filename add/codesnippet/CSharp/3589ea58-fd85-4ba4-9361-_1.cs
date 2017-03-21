        private void DrawArcInt(PaintEventArgs e)
        {
            // Create pen.
            Pen blackPen= new Pen(Color.Black, 3);
                     
            // Create coordinates of rectangle to bound ellipse.
            int x = 0;
            int y = 0;
            int width = 100;
            int height = 200;
                     
            // Create start and sweep angles on ellipse.
            int startAngle =  45;
            int sweepAngle = 270;
                     
            // Draw arc to screen.
            e.Graphics.DrawArc(blackPen, x, y, width, height, startAngle, sweepAngle);
        }