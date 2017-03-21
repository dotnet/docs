        public void GraphicsPathResetExample(PaintEventArgs e)
        {
            Font myFont = new Font("Arial", 8);
                     
            // Create a path and add a line, an ellipse, and an arc.
            GraphicsPath myPath = new GraphicsPath();
            myPath.AddLine(new Point(0, 0), new Point(100, 100));
            myPath.AddEllipse(100, 100, 200, 250);
            myPath.AddArc(300, 250, 100, 100, 0, 90);
                     
            // Draw the pre-reset points array to the screen.
            DrawPoints1(e, myPath.PathPoints, 20);
                     
            // Reset the path.
            myPath.Reset();
                     
            // See if any points remain.
            if(myPath.PointCount > 0)
            {
                     
                // Draw the post-reset points array to the screen.
                DrawPoints1(e, myPath.PathPoints, 150);
            }
            else
                     
                // If there are no points, say so.
                e.Graphics.DrawString("No Points",
                    myFont,
                    Brushes.Black,
                    150,
                    20);
        } 
        //End GraphicsPathResetExample
                     
        // A helper function GraphicsPathResetExample uses to draw the points.
                     
        // to the screen.
        public void DrawPoints1(PaintEventArgs e, PointF[] pathPoints, int xOffset)
        {
            int y = 20;
            Font myFont = new Font("Arial", 8);
            for(int i=0;i < pathPoints.Length; i++)
            {
                e.Graphics.DrawString(pathPoints[i].X.ToString() + ", " +
                    pathPoints[i].Y.ToString(),
                    myFont,
                    Brushes.Black,
                    xOffset,
                    y);
                y += 20;
            }
        } 
        // End DrawPoints