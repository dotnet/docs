private:
   void AddMyImage()
   {
      // Assign an image to the imageList.
      imageList1->Images->Add( Image::FromFile( "C:\\Graphics\\MyBitmap.bmp" ) );
      // Assign the imageList to the button control.
      button1->ImageList = imageList1;
      // Select the image from the ImageList (using the ImageIndex property).
      button1->ImageIndex = 0;
   }