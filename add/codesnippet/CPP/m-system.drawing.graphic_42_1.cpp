private:
   void DrawImagePara( PaintEventArgs^ e )
   {
      // Create image.
      Image^ newImage = Image::FromFile( "SampImag.jpg" );

      // Create parallelogram for drawing image.
      Point ulCorner = Point(100,100);
      Point urCorner = Point(550,100);
      Point llCorner = Point(150,250);
      array<Point>^ destPara = {ulCorner,urCorner,llCorner};

      // Draw image to screen.
      e->Graphics->DrawImage( newImage, destPara );
   }