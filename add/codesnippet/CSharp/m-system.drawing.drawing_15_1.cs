        private void AddEllipseExample(PaintEventArgs e)
        {
                     
            // Create a path and add an ellipse.
            Rectangle myEllipse = new Rectangle(20, 20, 100, 50);
            GraphicsPath myPath = new GraphicsPath();
            myPath.AddEllipse(myEllipse);
                     
            // Draw the path to the screen.
            Pen myPen = new Pen(Color.Black, 2);
            e.Graphics.DrawPath(myPen, myPath);
        }