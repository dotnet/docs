public:
   void RotateTransformAngleMatrixOrder( PaintEventArgs^ e )
   {
      // Set world transform of graphics object to translate.
      e->Graphics->TranslateTransform( 100.0F, 0.0F );

      // Then to rotate, appending rotation matrix.
      e->Graphics->RotateTransform( 30.0F, MatrixOrder::Append );

      // Draw translated, rotated ellipse to screen.
      e->Graphics->DrawEllipse( gcnew Pen( Color::Blue,3.0f ), 0, 0, 200, 80 );
   }