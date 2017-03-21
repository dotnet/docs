   // This example uses the DoubleClick event of a ListBox to load text files
   // listed in the ListBox into a TextBox control. This example
   // assumes that the ListBox, named listBox1, contains a list of valid file
   // names with path and that this event handler method
   // is connected to the DoublClick event of a ListBox control named listBox1.
   // This example requires code access permission to access files.
private:
   void listBox1_DoubleClick( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      // Get the name of the file to open from the ListBox.
      String^ file = listBox1->SelectedItem->ToString();
      try
      {
         // Determine if the file exists before loading.
         if ( System::IO::File::Exists( file ) )
         {
            
            // Open the file and use a TextReader to read the contents into the TextBox.
            System::IO::FileInfo^ myFile = gcnew System::IO::FileInfo( listBox1->SelectedItem->ToString() );
            System::IO::TextReader^ myData = myFile->OpenText();
            ;
            textBox1->Text = myData->ReadToEnd();
            myData->Close();
         }
      }
      // Exception is thrown by the OpenText method of the FileInfo class.
      catch ( System::IO::FileNotFoundException^ ) 
      {
         MessageBox::Show( "The file you specified does not exist." );
      }
      // Exception is thrown by the ReadToEnd method of the TextReader class.
      catch ( System::IO::IOException^ ) 
      {
         MessageBox::Show( "There was a problem loading the file into the TextBox. Ensure that the file is a valid text file." );
      }
   }