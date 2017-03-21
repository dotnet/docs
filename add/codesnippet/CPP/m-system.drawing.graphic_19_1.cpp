private:
   void DrawImagePointF( PaintEventArgs^ e )
   {
      // Create image.
      Image^ newImage = Image::FromFile( "SampImag.jpg" );

      // Create point for upper-left corner of image.
      PointF ulCorner = PointF(100.0F,100.0F);

      // Draw image to screen.
      e->Graphics->DrawImage( newImage, ulCorner );
   }