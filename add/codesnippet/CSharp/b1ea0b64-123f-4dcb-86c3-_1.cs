        public void CopyDataExample(PaintEventArgs e)
        {
                     
            // Create a graphics path.
            GraphicsPath myPath = new GraphicsPath();
                     
            // Set up a points array.
            Point[] myPoints =
                     {
                         new Point(20, 20),
                         new Point(120, 120),
                         new Point(20, 120),
                         new Point(20, 20)
                     };
                     
            // Create a rectangle.
            Rectangle myRect = new Rectangle(120, 120, 100, 100);
                     
            // Add the points, rectangle, and an ellipse to the path.
            myPath.AddLines(myPoints);
            myPath.SetMarkers();
            myPath.AddRectangle(myRect);
            myPath.SetMarkers();
            myPath.AddEllipse(220, 220, 100, 100);
                     
            // Get the total number of points for the path, and arrays of
            // the  points and types.
            int myPathPointCount = myPath.PointCount;
            PointF[] myPathPoints = myPath.PathPoints;
            byte[] myPathTypes = myPath.PathTypes;
                     
            // Set up variables for listing the array of points on the left
            // side of the screen.
            int i;
            float j = 20;
            Font myFont = new Font("Arial", 8);
            SolidBrush myBrush = new SolidBrush(Color.Black);
                     
            // List the set of points and types and types to the left side
            // of the screen.
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
                     
            // Create a GraphicsPathIterator for myPath and rewind it.
            GraphicsPathIterator myPathIterator =
                new GraphicsPathIterator(myPath);
            myPathIterator.Rewind();
                     
            // Set up the arrays to receive the copied data.
            PointF[] points = new PointF[myPathIterator.Count];
            byte[] types = new byte[myPathIterator.Count];
            int myStartIndex;
            int myEndIndex;
                     
            // Increment the starting index to the second marker in the
            // path.
            myPathIterator.NextMarker(out myStartIndex, out myEndIndex);
            myPathIterator.NextMarker(out myStartIndex, out myEndIndex);
                     
            // Copy all the points and types from the starting index to the
            // ending index to the points array and the types array
            // respectively.
            int numPointsCopied = myPathIterator.CopyData(
                ref points,
                ref types,
                myStartIndex,
                myEndIndex);
                     
            // List the copied points to the right side of the screen.
            j = 20;
            int copiedStartIndex = 0;
            for(i=0; i<numPointsCopied; i++)
            {
                copiedStartIndex = myStartIndex + i;
                e.Graphics.DrawString(
                    "Point: " + copiedStartIndex.ToString() +
                    ", Value: " + points[i].ToString() +
                    ", Type: " + types[i].ToString(),
                    myFont,
                    myBrush,
                    200,
                    j);
                j+=20;
            }
        }