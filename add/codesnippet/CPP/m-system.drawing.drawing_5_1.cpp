public:
   void ResetExample( PaintEventArgs^ e )
   {
      Pen^ myPen = gcnew Pen( Color::Blue,1.0f );
      Pen^ myPen2 = gcnew Pen( Color::Red,1.0f );

      // Create a matrix that scales by 5 in the x direction and
      // by 3 in the y direction.
      Matrix^ myMatrix = gcnew Matrix( 5.0f,0.0f,0.0f,3.0f,0.0f,0.0f );

      // List the matrix elements to the screen.
      ListMatrixElements( e, myMatrix, "Beginning Matrix", 6, 20 );

      // Reset the matrix to identity.
      myMatrix->Reset();

      // Again list the matrix elements to the screen.
      ListMatrixElements2( e, myMatrix, "Matrix After Reset", 6, 40 );

      // Translate the matrix by 50 points in the x-axis and 40 points
      // in the y-axis.
      myMatrix->Translate( 50.0f, 40.0f );

      // List the matrix elements to the screen.
      ListMatrixElements1( e, myMatrix, "Matrix After Translation", 6, 60 );

      // Draw a rectangle to the screen.
      e->Graphics->DrawRectangle( myPen, 0, 0, 100, 100 );

      // Apply the matrix transform to the Graphics.
      e->Graphics->Transform = myMatrix;

      // Draw another rectangle to the screen that has the transform
      // applied.
      e->Graphics->DrawRectangle( myPen2, 0, 0, 100, 100 );
   }

   //-------------------------------------------------------
   // This function is a helper function to
   // list the contents of a matrix.
   //-------------------------------------------------------
   void ListMatrixElements2( PaintEventArgs^ e, Matrix^ matrix, String^ matrixName, int numElements, int y )
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