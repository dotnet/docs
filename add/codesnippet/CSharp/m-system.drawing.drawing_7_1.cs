        private void SetMarkersExample(PaintEventArgs e)
        {
                     
            // Create a path and set two markers.
            GraphicsPath myPath = new GraphicsPath();
            myPath.AddLine(new Point(0, 0), new Point(50, 50));
            myPath.SetMarkers();
            Rectangle rect = new Rectangle(50, 50, 50, 50);
            myPath.AddRectangle(rect);
            myPath.SetMarkers();
            myPath.AddEllipse(100, 100, 100, 50);
                     
            // Draw the path to screen.
            e.Graphics.DrawPath(new Pen(Color.Black, 2), myPath);
        }