public:
   void DrawImage4Int( PaintEventArgs^ e )
   {
      // Create image.
      Image^ newImage = Image::FromFile( "SampImag.jpg" );

      // Create coordinates for upper-left corner.
      // of image and for size of image.
      int x = 100;
      int y = 100;
      int width = 450;
      int height = 150;

      // Draw image to screen.
      e->Graphics->DrawImage( newImage, x, y, width, height );
   }