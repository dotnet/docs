        public void FillPieRectangle(PaintEventArgs e)
        {
                     
            // Create solid brush.
            SolidBrush redBrush = new SolidBrush(Color.Red);
                     
            // Create rectangle for ellipse.
            Rectangle rect = new Rectangle(0, 0, 200, 100);
                     
            // Create start and sweep angles.
            float startAngle =  0.0F;
            float sweepAngle = 45.0F;
                     
            // Fill pie to screen.
            e.Graphics.FillPie(redBrush, rect, startAngle, sweepAngle);
        }