        private void AddRectangleExample(PaintEventArgs e)
        {
                     
            // Create a GraphicsPath object and add a rectangle to it.
            GraphicsPath myPath = new GraphicsPath();
            Rectangle pathRect = new Rectangle(20, 20, 100, 200);
            myPath.AddRectangle(pathRect);
                     
            // Draw the path to the screen.
            Pen myPen = new Pen(Color.Black, 2);
            e.Graphics.DrawPath(myPen, myPath);
        }