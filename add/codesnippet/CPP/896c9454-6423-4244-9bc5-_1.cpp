   void TranslateTransform_Example2( PaintEventArgs^ e )
   {
      // Create a TextureBrush object.
      TextureBrush^ tBrush = gcnew TextureBrush( gcnew Bitmap( "texture.jpg" ) );

      // Move the texture image 2X in the x-direction.
      tBrush->TranslateTransform( 50, 0 );

      // Fill a rectangle with tBrush.
      e->Graphics->FillRectangle( tBrush, 0, 0, 100, 100 );
   }