   [System::Runtime::InteropServices::DllImportAttribute("gdi32.dll")]
   static bool DeleteObject( IntPtr hObject );

private:
   void DemonstrateGetHbitmap()
   {
      Bitmap^ bm = gcnew Bitmap( "Picture.jpg" );
      IntPtr hBitmap = bm->GetHbitmap();
      
      // Do something with hBitmap.
      DeleteObject( hBitmap );
   }