        private void WidenExample(PaintEventArgs e)
        {
                     
            // Create a path and add two ellipses.
            GraphicsPath myPath = new GraphicsPath();
            myPath.AddEllipse(0, 0, 100, 100);
            myPath.AddEllipse(100, 0, 100, 100);
                     
            // Draw the original ellipses to the screen in black.
            e.Graphics.DrawPath(Pens.Black, myPath);
                     
            // Widen the path.
            Pen widenPen = new Pen(Color.Black, 10);
            Matrix widenMatrix = new Matrix();
            widenMatrix.Translate(50, 50);
            myPath.Widen(widenPen, widenMatrix, 1.0f);
                     
            // Draw the widened path to the screen in red.
            e.Graphics.FillPath(new SolidBrush(Color.Red), myPath);
        }