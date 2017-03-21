private:
   void DrawImageParaRect( PaintEventArgs^ e )
   {

      // Create image.
      Image^ newImage = Image::FromFile( "SampImag.jpg" );

      // Create parallelogram for drawing image.
      Point ulCorner = Point(100,100);
      Point urCorner = Point(325,100);
      Point llCorner = Point(150,250);
      array<Point>^ destPara = {ulCorner,urCorner,llCorner};

      // Create rectangle for source image.
      Rectangle srcRect = Rectangle(50,50,150,150);
      GraphicsUnit units = GraphicsUnit::Pixel;

      // Draw image to screen.
      e->Graphics->DrawImage( newImage, destPara, srcRect, units );
   }