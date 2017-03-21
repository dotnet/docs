private:
   void IconToBitmap( PaintEventArgs^ e )
   {
      // Construct an Icon.
      System::Drawing::Icon^ icon1 = gcnew System::Drawing::Icon( SystemIcons::Exclamation,40,40 );

      // Call ToBitmap to convert it.
      Bitmap^ bmp = icon1->ToBitmap();

      // Draw the bitmap.
      e->Graphics->DrawImage( bmp, Point(30,30) );
   }