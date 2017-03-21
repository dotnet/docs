private:
   void MakeTransparent_Example1( PaintEventArgs^ e )
   {
      // Create a Bitmap object from an image file.
      Bitmap^ myBitmap = gcnew Bitmap( "Grapes.gif" );

      // Draw myBitmap to the screen.
      e->Graphics->DrawImage( myBitmap, 0, 0, myBitmap->Width, myBitmap->Height );

      // Make the default transparent color transparent for myBitmap.
      myBitmap->MakeTransparent();

      // Draw the transparent bitmap to the screen.
      e->Graphics->DrawImage( myBitmap, myBitmap->Width, 0, myBitmap->Width, myBitmap->Height );
   }