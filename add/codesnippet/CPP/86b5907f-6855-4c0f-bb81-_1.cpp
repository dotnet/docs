   // Define DrawImageAbort callback method.
private:
   bool DrawImageCallback5( IntPtr callBackData )
   {
      // Test for call that passes callBackData parameter.
      if ( callBackData == IntPtr::Zero )
      {
         // If no callBackData passed, abort DrawImage method.
         return true;
      }
      else
      {
         // If callBackData passed, continue DrawImage method.
         return false;
      }
   }

private:
   void DrawImageRect4IntAtrribAbort( PaintEventArgs^ e )
   {
      // Create callback method.
      Graphics::DrawImageAbort^ imageCallback = gcnew Graphics::DrawImageAbort( this, &Form1::DrawImageCallback5 );

      // Create image.
      Image^ newImage = Image::FromFile( "SampImag.jpg" );

      // Create rectangle for displaying original image.
      Rectangle destRect1 = Rectangle(100,25,450,150);

      // Create coordinates of rectangle for source image.
      int x = 50;
      int y = 50;
      int width = 150;
      int height = 150;
      GraphicsUnit units = GraphicsUnit::Pixel;

      // Draw original image to screen.
      e->Graphics->DrawImage( newImage, destRect1, x, y, width, height, units );

      // Create rectangle for adjusted image.
      Rectangle destRect2 = Rectangle(100,175,450,150);

      // Create image attributes and set large gamma.
      ImageAttributes^ imageAttr = gcnew ImageAttributes;
      imageAttr->SetGamma( 4.0F );
      try
      {
         // Draw adjusted image to screen.
         e->Graphics->DrawImage( newImage, destRect2, x, y, width, height, units, imageAttr, imageCallback );
      }
      catch ( Exception^ ex ) 
      {
         e->Graphics->DrawString( ex->ToString(), gcnew System::Drawing::Font( "Arial",8 ), Brushes::Black, PointF(0,0) );
      }
   }