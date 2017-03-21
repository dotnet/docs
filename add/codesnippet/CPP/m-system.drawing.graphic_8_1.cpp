public:
   void FromImageImage( PaintEventArgs^ e )
   {
      // Create image.
      Image^ imageFile = Image::FromFile( "SampImag.jpg" );

      // Create graphics object for alteration.
      Graphics^ newGraphics = Graphics::FromImage( imageFile );

      // Alter image.
      newGraphics->FillRectangle( gcnew SolidBrush( Color::Black ), 100, 50, 100, 100 );

      // Draw image to screen.
      e->Graphics->DrawImage( imageFile, PointF(0.0F,0.0F) );

      // Dispose of graphics object.
      delete newGraphics;
   }