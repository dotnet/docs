   // Define DrawImageAbort callback method.
private:
   bool DrawImageCallback2( IntPtr callBackData )
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
   void DrawImageParaRectAttribAbortData( PaintEventArgs^ e )
   {
      // Create callback method.
      Graphics::DrawImageAbort^ imageCallback = gcnew Graphics::DrawImageAbort( this, &Form1::DrawImageCallback2 );
      int imageCallbackData = 1;

      // Create image.
      Image^ newImage = Image::FromFile( "SampImag.jpg" );

      // Create parallelogram for drawing original image.
      Point ulCorner = Point(100,100);
      Point urCorner = Point(550,100);
      Point llCorner = Point(150,250);
      array<Point>^ destPara1 = {ulCorner,urCorner,llCorner};

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
      try
      {
         // Draw image to screen.
         e->Graphics->DrawImage( newImage, destPara2, srcRect, units, imageAttr, imageCallback, imageCallbackData );
      }
      catch ( Exception^ ex ) 
      {
         e->Graphics->DrawString( ex->ToString(), gcnew System::Drawing::Font( "Arial",8 ), Brushes::Black, PointF(0,0) );
      }
   }