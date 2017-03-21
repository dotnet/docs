private:
   void DrawImageRect4Float( PaintEventArgs^ e )
   {
      // Create image.
      Image^ newImage = Image::FromFile( "SampImag.jpg" );

      // Create rectangle for displaying image.
      Rectangle destRect = Rectangle(100,100,450,150);

      // Create coordinates of rectangle for source image.
      float x = 50.0F;
      float y = 50.0F;
      float width = 150.0F;
      float height = 150.0F;
      GraphicsUnit units = GraphicsUnit::Pixel;

      // Draw image to screen.
      e->Graphics->DrawImage( newImage, destRect, x, y, width, height, units );
   }