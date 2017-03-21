private:
   void DrawImageRect( PaintEventArgs^ e )
   {
      // Create image.
      Image^ newImage = Image::FromFile( "SampImag.jpg" );

      // Create rectangle for displaying image.
      Rectangle destRect = Rectangle(100,100,450,150);

      // Draw image to screen.
      e->Graphics->DrawImage( newImage, destRect );
   }