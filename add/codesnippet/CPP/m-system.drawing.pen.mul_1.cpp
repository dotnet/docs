public:
   void MultiplyTransform_Example1( PaintEventArgs^ e )
   {
      
      // Create a Pen object.
      Pen^ myPen = gcnew Pen( Color::Black,5.0f );
      
      // Create a translation matrix.
      Matrix^ penMatrix = gcnew Matrix;
      penMatrix->Scale( 3, 1 );
      
      // Multiply the transformation matrix of myPen by transMatrix.
      myPen->MultiplyTransform( penMatrix );
      
      // Draw a line to the screen.
      e->Graphics->DrawLine( myPen, 0, 0, 100, 100 );
   }