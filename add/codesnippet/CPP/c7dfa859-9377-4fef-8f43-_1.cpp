   void MultiplyTransform_Example2( PaintEventArgs^ e )
   {
      // Create a TextureBrush object.
      TextureBrush^ tBrush = gcnew TextureBrush( gcnew Bitmap( "texture.jpg" ) );

      // Create a transformation matrix.
      Matrix^ translateMatrix = gcnew Matrix;
      translateMatrix->Translate( 50, 0 );

      // Multiply the transformation matrix of tBrush by translateMatrix.
      tBrush->MultiplyTransform( translateMatrix );

      // Fill a rectangle with tBrush.
      e->Graphics->FillRectangle( tBrush, 0, 110, 100, 100 );
   }