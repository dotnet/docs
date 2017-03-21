        public void FillPieInt(PaintEventArgs e)
        {
                     
            // Create solid brush.
            SolidBrush redBrush = new SolidBrush(Color.Red);
                     
            // Create location and size of ellipse.
            int x = 0;
            int y = 0;
            int width = 200;
            int height = 100;
                     
            // Create start and sweep angles.
            int startAngle =  0;
            int sweepAngle = 45;
                     
            // Fill pie to screen.
            e.Graphics.FillPie(redBrush, x, y, width, height, startAngle, sweepAngle);
        }