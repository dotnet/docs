   void ScaleTransform_Example2( PaintEventArgs^ e )
   {
      // Create a TextureBrush object.
      TextureBrush^ tBrush = gcnew TextureBrush( gcnew Bitmap( "texture.jpg" ) );

      // Scale the texture image 2X in the x-direction.
      tBrush->ScaleTransform( 2, 1, MatrixOrder::Prepend );

      // Fill a rectangle with tBrush.
      e->Graphics->FillRectangle( tBrush, 0, 0, 100, 100 );
   }