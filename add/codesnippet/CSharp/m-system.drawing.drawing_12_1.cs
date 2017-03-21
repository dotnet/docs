        public void TransformVectorsExample(PaintEventArgs e)
        {
            Pen myPen = new Pen(Color.Blue, 1);
            Pen myPen2 = new Pen(Color.Red, 1);
                     
            // Create an array of points.
            Point[] myArray =
                     {
                         new Point(20, 20),
                         new Point(120, 20),
                         new Point(120, 120),
                         new Point(20, 120),
                         new Point(20,20)
                     };
                     
            // Draw the Points to the screen before applying the
            // transform.
            e.Graphics.DrawLines(myPen, myArray);
                     
            // Create a matrix, scale it, and translate it.
            Matrix myMatrix = new Matrix();
            myMatrix.Scale(3, 2, MatrixOrder.Append);
            myMatrix.Translate(100, 100, MatrixOrder.Append);
                     
            // List the matrix elements to the screen.
            ListMatrixElements(e,
                myMatrix,
                "Scaled and Translated Matrix",
                6,
                20);
                     
            // Apply the transform to the array.
            myMatrix.TransformVectors(myArray);
                     
            // Draw the Points to the screen again after applying the
            // transform.
            e.Graphics.DrawLines(myPen2, myArray);
        }
                     
        //-------------------------------------------------------
        // This function is a helper function to
        // list the contents of a matrix.
        //-------------------------------------------------------
        public void ListMatrixElements(
            PaintEventArgs e,
            Matrix matrix,
            string matrixName,
            int numElements,
            int y)
        {
                     
            // Set up variables for drawing the array
            // of points to the screen.
            int i;
            float x = 20, X = 200;
            Font myFont = new Font("Arial", 8);
            SolidBrush myBrush = new SolidBrush(Color.Black);
                     
            // Draw the matrix name to the screen.
            e.Graphics.DrawString(
                matrixName + ":  ",
                myFont,
                myBrush,
                x,
                y);
                     
            // Draw the set of path points and types to the screen.
            for(i=0; i<numElements; i++)
            {
                e.Graphics.DrawString(
                    matrix.Elements[i].ToString() + ", ",
                    myFont,
                    myBrush,
                    X,
                    y);
                X += 30;
            }
        }