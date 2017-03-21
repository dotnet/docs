public:
   void DrawImageUnscaledInt( PaintEventArgs^ e )
   {
      // Create image.
      Image^ newImage = Image::FromFile( "SampImag.jpg" );

      // Create coordinates for upper-left corner of image.
      int x = 100;
      int y = 100;

      // Draw image to screen.
      e->Graphics->DrawImageUnscaled( newImage, x, y );
   }