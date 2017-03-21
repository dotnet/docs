private:
   [System::Runtime::InteropServices::DllImportAttribute("gdi32.dll")]
   static IntPtr SelectPalette( IntPtr hdc, IntPtr htPalette, bool bForceBackground );

   [System::Runtime::InteropServices::DllImportAttribute("gdi32.dll")]
   static int RealizePalette( IntPtr hdc );

public:
   void GetHalftonePaletteVoid( PaintEventArgs^ e )
   {
      // Create and draw image.
      Image^ imageFile = Image::FromFile( "SampImag.jpg" );
      e->Graphics->DrawImage( imageFile, Point(0,0) );

      // Get handle to device context.
      IntPtr hdc = e->Graphics->GetHdc();

      // Get handle to halftone palette.
      IntPtr htPalette = Graphics::GetHalftonePalette();

      // Select and realize new palette.
      SelectPalette( hdc, htPalette, true );
      RealizePalette( hdc );

      // Create new graphics object.
      Graphics^ newGraphics = Graphics::FromHdc( hdc );

      // Draw image with new palette.
      newGraphics->DrawImage( imageFile, 300, 0 );

      // Release handle to device context.
      e->Graphics->ReleaseHdc( hdc );
   }