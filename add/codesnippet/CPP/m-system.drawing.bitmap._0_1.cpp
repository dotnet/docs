private:
   void GetPixel_Example( PaintEventArgs^ e )
   {
      // Create a Bitmap object from an image file.
      Bitmap^ myBitmap = gcnew Bitmap( "Grapes.jpg" );

      // Get the color of a pixel within myBitmap.
      Color pixelColor = myBitmap->GetPixel( 50, 50 );

      // Fill a rectangle with pixelColor.
      SolidBrush^ pixelBrush = gcnew SolidBrush( pixelColor );
      e->Graphics->FillRectangle( pixelBrush, 0, 0, 100, 100 );
   }