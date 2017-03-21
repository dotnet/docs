        private void NextMarkerExample(PaintEventArgs e)
        {
                     
            // Create the GraphicsPath.
            GraphicsPath myPath = new GraphicsPath();
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
                     
            // Set up variables for drawing the array
                     
            // of points to the screen.
            int i;
            float j = 20;
            Font myFont = new Font("Arial", 8);
            SolidBrush myBrush = new SolidBrush(Color.Black);
                     
            // Draw the set of path points and types to the screen.
            for(i=0; i<myPathPointCount; i++)
            {
                e.Graphics.DrawString(myPathPoints[i].X.ToString()+
                    ", " + myPathPoints[i].Y.ToString() + ", " +
                    myPathTypes[i].ToString(),
                    myFont,
                    myBrush,
                    20,
                    j);
                j+=20;
            }
                     
            // Create a GraphicsPathIterator.
            GraphicsPathIterator myPathIterator = new
                GraphicsPathIterator(myPath);
            int myStartIndex;
            int myEndIndex;
                     
            // Rewind the Iterator.
            myPathIterator.Rewind();
                     
            // Draw the Markers and their start and end points
                     
            // to the screen.
            j=20;
            for(i=0;i<3;i++)
            {
                myPathIterator.NextMarker(out myStartIndex, out myEndIndex);
                e.Graphics.DrawString("Marker " + i.ToString() +
                    ":  Start: " + myStartIndex.ToString()+
                    "  End: " + myEndIndex.ToString(),
                    myFont,
                    myBrush,
                    200,
                    j);
                j += 20;
            }
                     
            // Draw the total number of points to the screen.
            j += 20;
            int myPathTotalPoints = myPathIterator.Count;
            e.Graphics.DrawString("Total Points = " +
                myPathTotalPoints.ToString(),
                myFont,
                myBrush,
                200,
                j);
        }