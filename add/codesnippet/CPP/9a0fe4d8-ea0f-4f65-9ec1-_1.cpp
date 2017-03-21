public:
   void DrawImage2FloatRectF( PaintEventArgs^ e )
   {
      // Create image.
      Image^ newImage = Image::FromFile( "SampImag.jpg" );

      // Create coordinates for upper-left corner of image.
      float x = 100.0F;
      float y = 100.0F;

      // Create rectangle for source image.
      RectangleF srcRect = RectangleF(50.0F,50.0F,150.0F,150.0F);
      GraphicsUnit units = GraphicsUnit::Pixel;

      // Draw image to screen.
      e->Graphics->DrawImage( newImage, x, y, srcRect, units );
   }