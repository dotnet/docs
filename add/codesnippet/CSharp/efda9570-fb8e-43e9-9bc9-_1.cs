        public void DrawPieInt(PaintEventArgs e)
        {
                     
            // Create pen.
            Pen blackPen = new Pen(Color.Black, 3);
                     
            // Create location and size of ellipse.
            int x = 0;
            int y = 0;
            int width = 200;
            int height = 100;
                     
            // Create start and sweep angles.
            int startAngle =  0;
            int sweepAngle = 45;
                     
            // Draw pie to screen.
            e.Graphics.DrawPie(blackPen, x, y, width, height, startAngle, sweepAngle);
        }