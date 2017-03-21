        private void CloneExample(PaintEventArgs e)
        {
                     
            // Set several markers in a path.
            GraphicsPath myPath = new GraphicsPath();
            myPath.AddEllipse(0, 0, 100, 200);
            myPath.AddLine(new Point(100, 100), new Point(200, 100));
            Rectangle rect = new Rectangle(200, 0, 100, 200);
            myPath.AddRectangle(rect);
            myPath.AddLine(new Point(250, 200), new Point(250, 300));
                     
            // Draw the path to the screen.
            Pen myPen = new Pen(Color.Black, 2);
            e.Graphics.DrawPath(myPen, myPath);
                     
            // Clone a copy of myPath.
            GraphicsPath myPath2 = (GraphicsPath)myPath.Clone();
                     
            // Draw the path to the screen.
            Pen myPen2 = new Pen(Color.Red, 4);
            e.Graphics.DrawPath(myPen2, myPath2);
        }