private:
   void DrawImagePoint( PaintEventArgs^ e )
   {
      // Create image.
      Image^ newImage = Image::FromFile( "SampImag.jpg" );

      // Create Point for upper-left corner of image.
      Point ulCorner = Point(100,100);

      // Draw image to screen.
      e->Graphics->DrawImage( newImage, ulCorner );
   }