public:
   void ScaleTransformFloat( PaintEventArgs^ e )
   {
      // Set world transform of graphics object to rotate.
      e->Graphics->RotateTransform( 30.0F );

      // Then to scale, prepending to world transform.
      e->Graphics->ScaleTransform( 3.0F, 1.0F );

      // Draw scaled, rotated rectangle to screen.
      e->Graphics->DrawRectangle( gcnew Pen( Color::Blue,3.0f ), 50, 0, 100, 40 );
   }