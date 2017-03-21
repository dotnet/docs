   void SetWrapModeExample( PaintEventArgs^ e )
   {
      // Create a filled, red circle, and save it to Circle3.jpg.
      Bitmap^ myBitmap = gcnew Bitmap( 50,50 );
      Graphics^ g = Graphics::FromImage( myBitmap );
      g->Clear( Color::White );
      g->FillEllipse( gcnew SolidBrush( Color::Red ), Rectangle(0,0,25,25) );
      myBitmap->Save( "Circle3.jpg" );

      // Create an Image object from the Circle3.jpg file, and draw it
      // to the screen.
      Image^ myImage = Image::FromFile( "Circle3.jpg" );
      e->Graphics->DrawImage( myImage, 20, 20 );

      // Set the wrap mode.
      ImageAttributes^ imageAttr = gcnew ImageAttributes;
      imageAttr->SetWrapMode( WrapMode::Tile );

      // Create a TextureBrush.
      Rectangle brushRect = Rectangle(0,0,25,25);
      TextureBrush^ myTBrush = gcnew TextureBrush( myImage,brushRect,imageAttr );

      // Draw to the screen a rectangle filled with red circles.
      e->Graphics->FillRectangle( myTBrush, 100, 20, 200, 200 );
   }