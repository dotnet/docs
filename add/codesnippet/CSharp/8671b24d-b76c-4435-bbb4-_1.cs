        public void MultiplyExample(PaintEventArgs e)
        {
            Pen myPen = new Pen(Color.Blue, 1);
            Pen myPen2 = new Pen(Color.Red, 1);
                     
            // Set up the matrices.
            Matrix myMatrix1 = new Matrix(
                2.0f, 0.0f, 0.0f, 1.0f, 0.0f, 0.0f);  
            
            Matrix myMatrix2 = new Matrix(
                0.0f, 1.0f, -1.0f, 0.0f, 0.0f, 0.0f); 
          
            Matrix myMatrix3 = new Matrix(
                1.0f, 0.0f, 0.0f, 1.0f, 250.0f, 50.0f);  
         
                     
            // Display the elements of the starting matrix.
            ListMatrixElements(e, myMatrix1, "Beginning Matrix", 6, 40);
                     
            // Multiply Matrix1 by Matrix 2.
            myMatrix1.Multiply(myMatrix2, MatrixOrder.Append);
                     
            // Display the result of the multiplication of Matrix1 and
                     
            // Matrix2.
            ListMatrixElements(e,
                myMatrix1,
                "Matrix After 1st Multiplication",
                6,
                60);
                     
            // Multiply the result from the pervious multiplication by
            // Matrix3.
            myMatrix1.Multiply(myMatrix3, MatrixOrder.Append);
                     
            // Display the result of the previous multiplication
            // multiplied by Matrix3.
            ListMatrixElements1(e,
                myMatrix1,
                "Matrix After 2nd Multiplication",
                6,
                80);
                     
            // Draw the rectangle prior to transformation.
            e.Graphics.DrawRectangle(myPen, 0, 0, 100, 100);
                     
            // Make the transformation.
            e.Graphics.Transform = myMatrix1;
                     
            // Draw the rectangle after transformation.
            e.Graphics.DrawRectangle(myPen2, 0, 0, 100, 100);
        }
                     
        //-------------------------------------------------------
        // The following function is a helper function to
        // list the contents of a matrix.
        //-------------------------------------------------------
        public void ListMatrixElements1(
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