public:
   void TransformVectorsExample( PaintEventArgs^ e )
   {
      Pen^ myPen = gcnew Pen( Color::Blue,1.0f );
      Pen^ myPen2 = gcnew Pen( Color::Red,1.0f );

      // Create an array of points.
      array<Point>^ myArray = {Point(20,20),Point(120,20),Point(120,120),Point(20,120),Point(20,20)};

      // Draw the Points to the screen before applying the
      // transform.
      e->Graphics->DrawLines( myPen, myArray );

      // Create a matrix, scale it, and translate it.
      Matrix^ myMatrix = gcnew Matrix;
      myMatrix->Scale( 3, 2, MatrixOrder::Append );
      myMatrix->Translate( 100, 100, MatrixOrder::Append );

      // List the matrix elements to the screen.
      ListMatrixElements( e, myMatrix, "Scaled and Translated Matrix", 6, 20 );

      // Apply the transform to the array.
      myMatrix->TransformVectors( myArray );

      // Draw the Points to the screen again after applying the
      // transform.
      e->Graphics->DrawLines( myPen2, myArray );
   }

   //-------------------------------------------------------
   // This function is a helper function to
   // list the contents of a matrix.
   //-------------------------------------------------------
   void ListMatrixElements( PaintEventArgs^ e, Matrix^ matrix, String^ matrixName, int numElements, int y )
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