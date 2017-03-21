        private void AddLineExample(PaintEventArgs e)
        {
                     
            //Create a path and add a symetrical triangle using AddLine.
            GraphicsPath myPath = new GraphicsPath();
            myPath.AddLine(30, 30, 60, 60);
            myPath.AddLine(60, 60, 0, 60);
            myPath.AddLine(0, 60, 30, 30);
                     
            // Draw the path to the screen.
            Pen myPen = new Pen(Color.Black, 2);
            e.Graphics.DrawPath(myPen, myPath);
        }