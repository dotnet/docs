public:
   void ScaleExample( PaintEventArgs^ e )
   {
      Pen^ myPen = gcnew Pen( Color::Blue,1.0f );
      Pen^ myPen2 = gcnew Pen( Color::Red,1.0f );

      // Draw the rectangle to the screen before applying the
      // transform.
      e->Graphics->DrawRectangle( myPen, 50, 50, 100, 100 );

      // Create a matrix and scale it.
      Matrix^ myMatrix = gcnew Matrix;
      myMatrix->Scale( 3, 2, MatrixOrder::Append );

      // Draw the rectangle to the screen again after applying the
      // transform.
      e->Graphics->Transform = myMatrix;
      e->Graphics->DrawRectangle( myPen2, 50, 50, 100, 100 );
   }