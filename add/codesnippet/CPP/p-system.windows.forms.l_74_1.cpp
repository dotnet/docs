public:
   void CreateMyLabel()
   {
      // Create a new label and create a bitmap.
      Label^ label1 = gcnew Label;
      Image^ image1 = Image::FromFile( "c:\\MyImage.bmp" );

      // Set the size of the label to accommodate the bitmap size.
      label1->Size = System::Drawing::Size( image1->Width, image1->Height );

      // Initialize the label control's Image property.
      label1->Image = image1;

      // ...Code to add the control to the form...
   }