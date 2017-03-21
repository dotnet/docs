private:
   void UseTransparentProperty()
   {
      // Set up the PictureBox to display the entire image, and
      // to cover the entire client area.
      PictureBox1->SizeMode = PictureBoxSizeMode::StretchImage;
      PictureBox1->Dock = DockStyle::Fill;
      try
      {
         // Set the Image property of the PictureBox to an image retrieved
         // from the file system.
         PictureBox1->Image = Image::FromFile( "C:\\Documents and Settings\\All Users\\"
         "Documents\\My Pictures\\Sample Pictures\\sunset.jpg" );

         // Set the Parent property of Button1 and Button2 to the 
         // PictureBox.
         Button1->Parent = PictureBox1;
         Button2->Parent = PictureBox1;

         // Set the Color property of both buttons to transparent. 
         // With this setting the buttons assume the color of their
         // parent.
         Button1->BackColor = Color::Transparent;
         Button2->BackColor = Color::Transparent;
      }
      catch ( System::IO::FileNotFoundException^ ) 
      {
         MessageBox::Show( "There was an error."
         "Make sure the image file path is valid." );
      }
   }