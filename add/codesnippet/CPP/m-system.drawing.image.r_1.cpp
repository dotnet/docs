   Bitmap^ bitmap1;
   void InitializeBitmap()
   {
      try
      {
         bitmap1 = dynamic_cast<Bitmap^>(Bitmap::FromFile( "C:\\Documents and Settings\\"
         "All Users\\Documents\\My Music\\music.bmp" ));
         PictureBox1->SizeMode = PictureBoxSizeMode::AutoSize;
         PictureBox1->Image = bitmap1;
      }
      catch ( System::IO::FileNotFoundException^ ) 
      {
         MessageBox::Show( "There was an error."
         "Check the path to the bitmap." );
      }

   }

   void Button1_Click( System::Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      if ( bitmap1 != nullptr )
      {
         bitmap1->RotateFlip( RotateFlipType::Rotate180FlipY );
         PictureBox1->Image = bitmap1;
      }
   }