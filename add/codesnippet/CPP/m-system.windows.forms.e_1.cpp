private:
   void TextBox1_Validating( Object^ sender,
      System::ComponentModel::CancelEventArgs^ e )
   {
      // If nothing is entered,
      // an ArgumentException is caught; if an invalid directory is entered, 
      // a DirectoryNotFoundException is caught. An appropriate error message 
      // is displayed in either case.
      try
      {
         System::IO::DirectoryInfo^ directory = gcnew System::IO::DirectoryInfo( TextBox1->Text );
         directory->GetFiles();
         ErrorProvider1->SetError( TextBox1, "" );
      }
      catch ( System::ArgumentException^ ) 
      {
         ErrorProvider1->SetError( TextBox1, "Please enter a directory" );
      }
      catch ( System::IO::DirectoryNotFoundException^ ) 
      {
         ErrorProvider1->SetError( TextBox1, "The directory does not exist."
         "Try again with a different directory." );
      }
   }

   // This method handles the LostFocus event for TextBox1 by setting the 
   // dialog's InitialDirectory property to the text in TextBox1.
   void TextBox1_LostFocus( Object^ sender, System::EventArgs^ e )
   {
      OpenFileDialog1->InitialDirectory = TextBox1->Text;
   }

   // This method demonstrates using the ErrorProvider.GetError method 
   // to check for an error before opening the dialog box.
   void Button1_Click( System::Object^ sender, System::EventArgs^ e )
   {
      //If there is no error, then open the dialog box.
      if ( ErrorProvider1->GetError( TextBox1 )->Equals( "" ) )
      {
         ::DialogResult dialogResult = OpenFileDialog1->ShowDialog();
      }
   }