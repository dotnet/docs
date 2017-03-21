   Bitmap^ MyImage;

public:
   void ShowMyImage( String^ fileToDisplay, int xSize, int ySize )
   {
      
      // Sets up an image object to be displayed.
      if ( MyImage != nullptr )
      {
         delete MyImage;
      }

      
      // Stretches the image to fit the pictureBox.
      pictureBox1->SizeMode = PictureBoxSizeMode::StretchImage;
      MyImage = gcnew Bitmap( fileToDisplay );
      pictureBox1->ClientSize = System::Drawing::Size( xSize, ySize );
      pictureBox1->Image = dynamic_cast<Image^>(MyImage);
   }
