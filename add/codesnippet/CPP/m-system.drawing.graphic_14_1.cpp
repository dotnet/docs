private:
   [System::Runtime::InteropServices::DllImportAttribute("gdi32.dll")]
   static bool Rectangle2( IntPtr hdc, int ulCornerX, int ulCornerY, int lrCornerX, int lrCornerY );

public:
   void GetHdcForGDI2( PaintEventArgs^ e )
   {
      // Create pen.
      Pen^ redPen = gcnew Pen( Color::Red,1.0f );

      // Draw rectangle with GDI+.
      e->Graphics->DrawRectangle( redPen, 10, 10, 100, 50 );

      // Get handle to device context.
      IntPtr hdc = e->Graphics->GetHdc();

      // Draw rectangle with GDI using default pen.
      Rectangle2( hdc, 10, 70, 110, 120 );

      // Release handle to device context.
      e->Graphics->ReleaseHdc( hdc );
   }