        public void NextMarkerExample2(PaintEventArgs e)
        {
                     
            // Create a graphics path.
            GraphicsPath myPath = new GraphicsPath();
                     
            // Set up primitives to add to myPath.
            Point[] myPoints = {new Point(20, 20), new Point(120, 120), 
                new Point(20, 120),new Point(20, 20) };        
         
            Rectangle myRect = new Rectangle(120, 120, 100, 100);
                     
            // Add 3 lines, a rectangle, an ellipse, and 2 markers.
            myPath.AddLines(myPoints);
            myPath.SetMarkers();
            myPath.AddRectangle(myRect);
            myPath.SetMarkers();
            myPath.AddEllipse(220, 220, 100, 100);
                     
            // Get the total number of points for the path,
            // and the arrays of the points and types.
            int myPathPointCount = myPath.PointCount;
            PointF[] myPathPoints = myPath.PathPoints;
            byte[] myPathTypes = myPath.PathTypes;
                     
            // Set up variables for listing all the values of the path's
            // points to the screen.
            int i;
            float j = 20;
            Font myFont = new Font("Arial", 8);
            SolidBrush myBrush = new SolidBrush(Color.Black);
                     
            // List the values for all of path points and types to
            // the left side of the screen.
            for(i=0; i < myPathPointCount; i++)
            {
                e.Graphics.DrawString(myPathPoints[i].X.ToString()+
                    ", " + myPathPoints[i].Y.ToString() + ", " +
                    myPathTypes[i].ToString(),  myFont, myBrush,
                    20, j);
                    
                j+=20; 
               
            }
                     
            // Create a GraphicsPathIterator.
            GraphicsPathIterator myPathIterator = new
                GraphicsPathIterator(myPath);
                     
            // Rewind the iterator.
            myPathIterator.Rewind();
                     
            // Create a GraphicsPath to receive a section of myPath.
            GraphicsPath myPathSection = new GraphicsPath();
                     
            // Retrieve and list the number of points contained in
                     
            // the first marker to the right side of the screen.
            int markerPoints;
            markerPoints = myPathIterator.NextMarker(myPathSection);
            e.Graphics.DrawString("Marker: 1" + "  Num Points: " +
                markerPoints.ToString(),  myFont, myBrush, 200, 20);
                
        }