        private void ClearMarkersExample(PaintEventArgs e)
        {
                     
            // Set several markers in a path.
            GraphicsPath myPath = new GraphicsPath();
            myPath.AddEllipse(0, 0, 100, 200);
            myPath.SetMarkers();
            myPath.AddLine(new Point(100, 100), new Point(200, 100));
            Rectangle rect = new Rectangle(200, 0, 100, 200);
            myPath.AddRectangle(rect);
            myPath.SetMarkers();
            myPath.AddLine(new Point(250, 200), new Point(250, 300));
            myPath.SetMarkers();
                     
            // Clear the markers.
            myPath.ClearMarkers();
                     
            // Draw the path to the screen.
            Pen myPen = new Pen(Color.Black, 2);
            e.Graphics.DrawPath(myPen, myPath);
        }