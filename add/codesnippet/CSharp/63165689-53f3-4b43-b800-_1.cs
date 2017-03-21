        private void NextSubpathExample(PaintEventArgs e)
        {
                     
            // Create the GraphicsPath.
            GraphicsPath myPath = new GraphicsPath();
            Point[] myPoints = {new Point(20, 20), new Point(120, 120), 
                new Point(20, 120),new Point(20, 20) }; 
            Rectangle myRect = new Rectangle(120, 120, 100, 100);
                     
            // Add 3 lines, a rectangle, an ellipse, and 2 markers.
            myPath.AddLines(myPoints);
            myPath.AddRectangle(myRect);
            myPath.AddEllipse(220, 220, 100, 100);
                     
            // Get the total number of points for the path,
                     
            // and the arrays of the points and types.
            int myPathPointCount = myPath.PointCount;
            PointF[] myPathPoints = myPath.PathPoints;
            byte[] myPathTypes = myPath.PathTypes;
                     
            // Set up variables for drawing the array of
                     
            // points to the screen.
            int i;
            float j = 20;
            Font myFont = new Font("Arial", 8);
            SolidBrush myBrush = new SolidBrush(Color.Black);
                     
            // Draw the set of path points and types to the screen.
            for(i=0; i < myPathPointCount; i++)
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
            bool myIsClosed;
                     
            // get the number of Subpaths.
            int numSubpaths = myPathIterator.NextSubpath(myPath,
                out myIsClosed);
            numSubpaths -= 1;
                     
            // Rewind the Iterator.
            myPathIterator.Rewind();
                     
            // List the Subpaths to the screen.
            j=20;
            for(i=0;i<numSubpaths;i++)
            {
                myPathIterator.NextSubpath(out myStartIndex,
                    out myEndIndex,
                    out myIsClosed);
                e.Graphics.DrawString("Subpath " + i.ToString() +
                    ":  Start: " + myStartIndex.ToString()+
                    "  End: " + myEndIndex.ToString() +
                    "  IsClosed: " + myIsClosed.ToString(),
                    myFont,
                    myBrush,
                    200,
                    j);
                j += 20;
            }
                     
            // Draw the total number of Subpaths to the screen.
            j += 20;
            e.Graphics.DrawString("Number Subpaths = " +
                numSubpaths.ToString(),
                myFont,
                myBrush,
                200,
                j);
        }