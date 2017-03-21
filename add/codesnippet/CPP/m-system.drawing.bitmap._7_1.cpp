   void DemonstrateGetHbitmapWithColor()
   {
      Bitmap^ bm = gcnew Bitmap( "Picture.jpg" );
      IntPtr hBitmap = bm->GetHbitmap( Color::Blue );
      
      // Do something with hBitmap.
      DeleteObject( hBitmap );
   }