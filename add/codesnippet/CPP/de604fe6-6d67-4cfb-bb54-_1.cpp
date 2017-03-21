private:
   void SetRemapTableExample( PaintEventArgs^ e )
   {
      // Create a filled, red image, and save it to Circle2.jpg.
      Bitmap^ myBitmap = gcnew Bitmap( 50,50 );
      Graphics^ g = Graphics::FromImage( myBitmap );
      g->Clear( Color::White );
      g->FillEllipse( gcnew SolidBrush( Color::Red ), Rectangle(0,0,50,50) );
      myBitmap->Save( "Circle2.jpg" );

      // Create an Image object from the Circle2.jpg file, and draw it to
      // the screen.
      Image^ myImage = Image::FromFile( "Circle2.jpg" );
      e->Graphics->DrawImage( myImage, 20, 20 );

      // Create a color map.
      array<ColorMap^>^myColorMap = gcnew array<ColorMap^>(1);
      myColorMap[ 0 ] = gcnew ColorMap;
      myColorMap[ 0 ]->OldColor = Color::Red;
      myColorMap[ 0 ]->NewColor = Color::Green;

      // Create an ImageAttributes object, and then pass the
      // myColorMap object to the SetRemapTable method.
      ImageAttributes^ imageAttr = gcnew ImageAttributes;
      imageAttr->SetRemapTable( myColorMap );

      // Draw the image with the remap table set.
      Rectangle rect = Rectangle(150,20,50,50);
      e->Graphics->DrawImage( myImage, rect, 0, 0, 50, 50, GraphicsUnit::Pixel, imageAttr );
   }