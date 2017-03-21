        public void DrawPieRectangle(PaintEventArgs e)
        {
                     
            // Create pen.
            Pen blackPen = new Pen(Color.Black, 3);
                     
            // Create rectangle for ellipse.
            Rectangle rect = new Rectangle(0, 0, 200, 100);
                     
            // Create start and sweep angles.
            float startAngle =  0.0F;
            float sweepAngle = 45.0F;
                     
            // Draw pie to screen.
            e.Graphics.DrawPie(blackPen, rect, startAngle, sweepAngle);
        }