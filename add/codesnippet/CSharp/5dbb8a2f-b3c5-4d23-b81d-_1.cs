        public void EnumerateExample(PaintEventArgs e)
        {
            GraphicsPath myPath = new GraphicsPath();
            Point[] myPoints =
                     {
                         new Point(20, 20),
                         new Point(120, 120),
                         new Point(20, 120),
                         new Point(20, 20)
                     };
            Rectangle myRect = new Rectangle(120, 120, 100, 100);
            myPath.AddLines(myPoints);
            myPath.AddRectangle(myRect);
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
            e.Graphics.DrawString("Original Data",
                myFont,
                myBrush,
                20,
                j);
            j += 20;
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
                     
            // Create a GraphicsPathIterator for myPath.
            GraphicsPathIterator myPathIterator =
                new GraphicsPathIterator(myPath);
            myPathIterator.Rewind();
            PointF[] points = new PointF[myPathIterator.Count];
            byte[] types = new byte[myPathIterator.Count];
            int numPoints = myPathIterator.Enumerate(ref points, ref types);
                     
            // Draw the set of copied points and types to the screen.
            j = 20;
            e.Graphics.DrawString("Copied Data",
                myFont,
                myBrush,
                200,
                j);
            j += 20;
            for(i=0; i<points.Length; i++)
            {
                e.Graphics.DrawString("Point: " + i +
                    ", " + "Value: " + points[i].ToString() + ", " +
                    "Type: " + types[i].ToString(),
                    myFont,
                    myBrush,
                    200,
                    j);
                j+=20;
            }
        }