private:
   void Button2_Click( System::Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      try
      {
         Bitmap^ image1 = dynamic_cast<Bitmap^>(Image::FromFile( "C:\\Documents and Settings\\"
         "All Users\\Documents\\My Music\\music.bmp", true ));
         TextureBrush^ texture = gcnew TextureBrush( image1 );
         texture->WrapMode = System::Drawing::Drawing2D::WrapMode::Tile;
         Graphics^ formGraphics = this->CreateGraphics();
         formGraphics->FillEllipse( texture, RectangleF(90.0F,110.0F,100,100) );
         delete formGraphics;
      }
      catch ( System::IO::FileNotFoundException^ ) 
      {
         MessageBox::Show( "There was an error opening the bitmap."
         "Please check the path." );
      }
   }