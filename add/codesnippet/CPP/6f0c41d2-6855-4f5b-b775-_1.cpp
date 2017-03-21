public:
   void DrawImageRectF( PaintEventArgs^ e )
   {
      // Create image.
      Image^ newImage = Image::FromFile( "SampImag.jpg" );

      // Create rectangle for displaying image.
      RectangleF rect = RectangleF(100.0F,100.0F,450.0F,150.0F);

      // Draw image to screen.
      e->Graphics->DrawImage( newImage, rect );
   }