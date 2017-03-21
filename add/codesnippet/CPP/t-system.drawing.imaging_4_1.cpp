   void LockUnlockBitsExample( PaintEventArgs^ e )
   {
      // Create a new bitmap.
      Bitmap^ bmp = gcnew Bitmap( "c:\\fakePhoto.jpg" );

      // Lock the bitmap's bits.  
      Rectangle rect = Rectangle(0,0,bmp->Width,bmp->Height);
      System::Drawing::Imaging::BitmapData^ bmpData = bmp->LockBits( rect, System::Drawing::Imaging::ImageLockMode::ReadWrite, bmp->PixelFormat );

      // Get the address of the first line.
      IntPtr ptr = bmpData->Scan0;

      // Declare an array to hold the bytes of the bitmap.
      // This code is specific to a bitmap with 24 bits per pixels.
      int bytes = Math::Abs(bmpData->Stride) * bmp->Height;
      array<Byte>^rgbValues = gcnew array<Byte>(bytes);

      // Copy the RGB values into the array.
      System::Runtime::InteropServices::Marshal::Copy( ptr, rgbValues, 0, bytes );

      // Set every third value to 255.  
      for ( int counter = 2; counter < rgbValues->Length; counter += 3 )
         rgbValues[ counter ] = 255;

      // Copy the RGB values back to the bitmap
      System::Runtime::InteropServices::Marshal::Copy( rgbValues, 0, ptr, bytes );

      // Unlock the bits.
      bmp->UnlockBits( bmpData );

      // Draw the modified image.
      e->Graphics->DrawImage( bmp, 0, 150 );
   }