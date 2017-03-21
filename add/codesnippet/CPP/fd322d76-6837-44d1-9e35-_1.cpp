private:
   void DrawImageParaRectAttrib( PaintEventArgs^ e )
   {
      // Create image.
      Image^ newImage = Image::FromFile( "SampImag.jpg" );

      // Create parallelogram for drawing image.
      Point ulCorner1 = Point(100,100);
      Point urCorner1 = Point(325,100);
      Point llCorner1 = Point(150,250);
      array<Point>^ destPara1 = {ulCorner1,urCorner1,llCorner1};

      // Create rectangle for source image.
      Rectangle srcRect = Rectangle(50,50,150,150);
      GraphicsUnit units = GraphicsUnit::Pixel;

      // Draw original image to screen.
      e->Graphics->DrawImage( newImage, destPara1, srcRect, units );

      // Create parallelogram for drawing adjusted image.
      Point ulCorner2 = Point(325,100);
      Point urCorner2 = Point(550,100);
      Point llCorner2 = Point(375,250);
      array<Point>^ destPara2 = {ulCorner2,urCorner2,llCorner2};

      // Create image attributes and set large gamma.
      ImageAttributes^ imageAttr = gcnew ImageAttributes;
      imageAttr->SetGamma( 4.0F );

      // Draw adjusted image to screen.
      e->Graphics->DrawImage( newImage, destPara2, srcRect, units, imageAttr );
   }