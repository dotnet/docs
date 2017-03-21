public:
   void MultiplyTransformMatrixOrder( PaintEventArgs^ e )
   {
      // Create transform matrix.
      Matrix^ transformMatrix = gcnew Matrix;

      // Translate matrix, prepending translation vector.
      transformMatrix->Translate( 200.0F, 100.0F );

      // Rotate transformation matrix of graphics object,
      // prepending rotation matrix.
      e->Graphics->RotateTransform( 30.0F );

      // Multiply (append to) transformation matrix of
      // graphics object to translate graphics transformation.
      e->Graphics->MultiplyTransform( transformMatrix, MatrixOrder::Append );

      // Draw rotated, translated ellipse.
      e->Graphics->DrawEllipse( gcnew Pen( Color::Blue,3.0f ), -80, -40, 160, 80 );
   }