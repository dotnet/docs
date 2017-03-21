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