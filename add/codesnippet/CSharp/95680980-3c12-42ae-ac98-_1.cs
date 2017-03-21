        public void NextPathTypeExample(PaintEventArgs e)
        {
                     
            // Create the GraphicsPath.
            GraphicsPath myPath = new GraphicsPath();

            Point[] myPoints = {new Point(20, 20), new Point(120, 120), 
                 new Point(20, 120),new Point(20, 20) }; 
            Rectangle myRect = new Rectangle(120, 120, 100, 100);
                     
            // Add 3 lines, a rectangle, and an ellipse.
            myPath.AddLines(myPoints);
            myPath.AddRectangle(myRect);
            myPath.AddEllipse(220, 220, 100, 100);
                     
            // List all of the path points to the screen.
            ListPathPoints(e, myPath, null, 20, 1);
                     
            // Create a GraphicsPathIterator.
            GraphicsPathIterator myPathIterator = new
                GraphicsPathIterator(myPath);
                     
            // Rewind the Iterator.
            myPathIterator.Rewind();
                     
            // Iterate the subpaths and types, and list the results to
                     
            // the screen.
            int i, j = 20;
            int mySubPaths, subPathStartIndex, subPathEndIndex;
            Boolean IsClosed;
            byte subPathPointType;
            int pointTypeStartIndex,  pointTypeEndIndex, numPointsFound;
            Font myFont = new Font("Arial", 8);
            SolidBrush myBrush = new SolidBrush(Color.Black);
            j = 20;
            for(i = 0;i < 3; i++)
            {
                mySubPaths = myPathIterator.NextSubpath(
                    out subPathStartIndex,
                    out subPathEndIndex,
                    out IsClosed);
                numPointsFound = myPathIterator.NextPathType(
                    out subPathPointType,
                    out pointTypeStartIndex,
                    out pointTypeEndIndex);
                e.Graphics.DrawString(
                    "SubPath: " + i +
                    "  Points Found: " + numPointsFound.ToString() +
                    "  Type of Points: " + subPathPointType.ToString(),
                    myFont,
                    myBrush,
                    200,
                    j);
                j+=20;
            }
                     
            // List the total number of path points to the screen.
            ListPathPoints(e, myPath, myPathIterator, 200, 2);
        }
                     
        //-------------------------------------------------------
        //This function is a helper function used by
        // NextPathTypeExample.
        //-------------------------------------------------------
        public void ListPathPoints(
            PaintEventArgs e,
            GraphicsPath myPath,
            GraphicsPathIterator myPathIterator,
            int xOffset,
            int listType)
        {
                     
            // Get the total number of points for the path,
            // and the arrays of the points and types.
            int myPathPointCount = myPath.PointCount;
            PointF[] myPathPoints = myPath.PathPoints;
            byte[] myPathTypes = myPath.PathTypes;
                     
            // Set up variables for drawing the points to the screen.
            int i;
            float j = 20;
            Font myFont = new Font("Arial", 8);
            SolidBrush myBrush = new SolidBrush(Color.Black);
            if (listType == 1) 
                // List all the path points to the screen.
            {
                     
                // Draw the set of path points and types to the screen.
                for(i=0; i<myPathPointCount; i++)
                {
                    e.Graphics.DrawString(myPathPoints[i].X.ToString()+
                        ", " + myPathPoints[i].Y.ToString() + ", " +
                        myPathTypes[i].ToString(),
                        myFont,
                        myBrush,
                        xOffset,
                        j);
                    j+=20;
                }
            }
            else if (listType == 2) 
                // Display the total number of path points.
            {
                     
                // Draw the total number of points to the screen.
                int myPathTotalPoints = myPathIterator.Count;
                e.Graphics.DrawString("Total Points = " +
                    myPathTotalPoints.ToString(),
                    myFont,
                    myBrush,
                    xOffset,
                    100);
            }
            else
            {
                e.Graphics.DrawString("Wrong or no list type argument.",
                    myFont, myBrush, xOffset, 200);
            }
        }