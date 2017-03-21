        private void AddPieExample(PaintEventArgs e)
        {
                     
            // Create a pie slice of a circle using the AddPie method.
            GraphicsPath myPath = new GraphicsPath();
            myPath.AddPie(20, 20, 70, 70, -45, 90);
                     
            // Draw the path to the screen.
            Pen myPen = new Pen(Color.Black, 2);
            e.Graphics.DrawPath(myPen, myPath);
        }