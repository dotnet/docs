        public void FillPieFloat(PaintEventArgs e)
        {
                     
            // Create solid brush.
            SolidBrush redBrush = new SolidBrush(Color.Red);
                     
            // Create location and size of ellipse.
            float x = 0.0F;
            float y = 0.0F;
            float width = 200.0F;
            float height = 100.0F;
                     
            // Create start and sweep angles.
            float startAngle =  0.0F;
            float sweepAngle = 45.0F;
                     
            // Fill pie to screen.
            e.Graphics.FillPie(redBrush, x, y, width, height, startAngle, sweepAngle);
        }