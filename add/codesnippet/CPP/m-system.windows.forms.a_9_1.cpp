   void InitializePictureBox()
   {
      this->PictureBox1 = gcnew System::Windows::Forms::PictureBox;
      this->PictureBox1->BorderStyle =
         System::Windows::Forms::BorderStyle::FixedSingle;
      this->PictureBox1->SizeMode = PictureBoxSizeMode::StretchImage;
      this->PictureBox1->Location = System::Drawing::Point( 72, 112 );
      this->PictureBox1->Name = "PictureBox1";
      this->PictureBox1->Size = System::Drawing::Size( 160, 136 );
      this->PictureBox1->TabIndex = 6;
      this->PictureBox1->TabStop = false;
   }

   void InitializeOpenFileDialog()
   {
      this->OpenFileDialog1 = gcnew System::Windows::Forms::OpenFileDialog;
      
      // Set the file dialog to filter for graphics files.
      this->OpenFileDialog1->Filter =
         "Images (*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|" +
         "All files (*.*)|*.*";
      
      // Allow the user to select multiple images.
      this->OpenFileDialog1->Multiselect = true;
      this->OpenFileDialog1->Title = "My Image Browser";
   }

   void fileButton_Click( System::Object^ sender, System::EventArgs^ e )
   {
      OpenFileDialog1->ShowDialog();
   }

   // This method handles the FileOK event.  It opens each file 
   // selected and loads the image from a stream into PictureBox1.
   void OpenFileDialog1_FileOk( Object^ sender,
      System::ComponentModel::CancelEventArgs^ e )
   {
      this->Activate();
      array<String^>^ files = OpenFileDialog1->FileNames;
      
      // Open each file and display the image in PictureBox1.
      // Call Application.DoEvents to force a repaint after each
      // file is read.        
      for each ( String^ file in files )
      {
         System::IO::FileInfo^ fileInfo = gcnew System::IO::FileInfo( file );
         System::IO::FileStream^ fileStream = fileInfo->OpenRead();
         PictureBox1->Image = System::Drawing::Image::FromStream( fileStream );
         Application::DoEvents();
         fileStream->Close();
         
         // Call Sleep so the picture is briefly displayed, 
         //which will create a slide-show effect.
         System::Threading::Thread::Sleep( 2000 );
      }
      PictureBox1->Image = nullptr;
   }