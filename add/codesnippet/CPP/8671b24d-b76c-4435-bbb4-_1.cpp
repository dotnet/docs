public:
   void MultiplyExample( PaintEventArgs^ e )
   {
      Pen^ myPen = gcnew Pen( Color::Blue,1.0f );
      Pen^ myPen2 = gcnew Pen( Color::Red,1.0f );

      // Set up the matrices.
      Matrix^ myMatrix1 = gcnew Matrix( 2.0f,0.0f,0.0f,1.0f,0.0f,0.0f );
      Matrix^ myMatrix2 = gcnew Matrix( 0.0f,1.0f,-1.0f,0.0f,0.0f,0.0f );
      Matrix^ myMatrix3 = gcnew Matrix( 1.0f,0.0f,0.0f,1.0f,250.0f,50.0f );

      // Display the elements of the starting matrix.
      ListMatrixElements( e, myMatrix1, "Beginning Matrix", 6, 40 );

      // Multiply Matrix1 by Matrix 2.
      myMatrix1->Multiply( myMatrix2, MatrixOrder::Append );

      // Display the result of the multiplication of Matrix1 and
      // Matrix2.
      ListMatrixElements( e, myMatrix1, "Matrix After 1st Multiplication", 6, 60 );

      // Multiply the result from the previous multiplication by
      // Matrix3.
      myMatrix1->Multiply( myMatrix3, MatrixOrder::Append );

      // Display the result of the previous multiplication
      // multiplied by Matrix3.
      ListMatrixElements1( e, myMatrix1, "Matrix After 2nd Multiplication", 6, 80 );

      // Draw the rectangle prior to transformation.
      e->Graphics->DrawRectangle( myPen, 0, 0, 100, 100 );

      // Make the transformation.
      e->Graphics->Transform = myMatrix1;

      // Draw the rectangle after transformation.
      e->Graphics->DrawRectangle( myPen2, 0, 0, 100, 100 );
   }

   //-------------------------------------------------------
   // The following function is a helper function to
   // list the contents of a matrix.
   //-------------------------------------------------------
   void ListMatrixElements1( PaintEventArgs^ e, Matrix^ matrix, String^ matrixName, int numElements, int y )
   {
      // Set up variables for drawing the array
      // of points to the screen.
      int i;
      float x = 20,X = 200;
      System::Drawing::Font^ myFont = gcnew System::Drawing::Font( "Arial",8 );
      SolidBrush^ myBrush = gcnew SolidBrush( Color::Black );

      // Draw the matrix name to the screen.
      e->Graphics->DrawString( String::Concat( matrixName, ":  " ), myFont, myBrush, (float)x, (float)y );

      // Draw the set of path points and types to the screen.
      for ( i = 0; i < numElements; i++ )
      {
         e->Graphics->DrawString( String::Concat( matrix->Elements[ i ], ", " ), myFont, myBrush, (float)X, (float)y );
         X += 30;
      }
   }