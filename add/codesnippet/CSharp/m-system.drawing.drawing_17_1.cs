        private void HasCurveExample(PaintEventArgs e)
        {
                     
            // Create a path and add three lines,
            // a rectangle and an ellipse.
            GraphicsPath myPath = new GraphicsPath();
            
            Point[] myPoints = {new Point(20, 20), new Point(120, 120), 
                new Point(20, 120),new Point(20, 20) }; 

            Rectangle myRect = new Rectangle(120, 120, 100, 100);
            myPath.AddLines(myPoints);
            myPath.AddRectangle(myRect);
            myPath.AddEllipse(220, 220, 100, 100);
                     
            // Create a GraphicsPathIterator for myPath.
            GraphicsPathIterator myPathIterator = new
                GraphicsPathIterator(myPath);
                     
            // Test for a curve.
            bool myHasCurve = myPathIterator.HasCurve();
                     
            // Show the test result.
            MessageBox.Show(myHasCurve.ToString());
        }