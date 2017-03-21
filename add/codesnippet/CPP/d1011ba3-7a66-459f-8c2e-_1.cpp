private:
   void DrawImageParaF( PaintEventArgs^ e )
   {
      // Create image.
      Image^ newImage = Image::FromFile( "SampImag.jpg" );

      // Create parallelogram for drawing image.
      PointF ulCorner = PointF(100.0F,100.0F);
      PointF urCorner = PointF(550.0F,100.0F);
      PointF llCorner = PointF(150.0F,250.0F);
      array<PointF>^ destPara = {ulCorner,urCorner,llCorner};

      // Draw image to screen.
      e->Graphics->DrawImage( newImage, destPara );
   }