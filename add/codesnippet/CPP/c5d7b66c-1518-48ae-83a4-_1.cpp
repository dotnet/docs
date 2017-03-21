private:
   void DrawImageRectRect( PaintEventArgs^ e )
   {
      // Create image.
      Image^ newImage = Image::FromFile( "SampImag.jpg" );

      // Create rectangle for displaying image.
      Rectangle destRect = Rectangle(100,100,450,150);

      // Create rectangle for source image.
      Rectangle srcRect = Rectangle(50,50,150,150);
      GraphicsUnit units = GraphicsUnit::Pixel;

      // Draw image to screen.
      e->Graphics->DrawImage( newImage, destRect, srcRect, units );
   }