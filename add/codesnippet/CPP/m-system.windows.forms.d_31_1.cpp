private:
   void GetAllFormats2()
   {
      // Creates a new data object using a string and the text format.
      DataObject^ myDataObject = gcnew DataObject( DataFormats::Text,"Another string" );
      
      // Gets the original data formats in the DataObject.
      array<String^>^ arrayOfFormats = myDataObject->GetFormats( false );
      
      // Prints the results.
      textBox1->Text = "The format(s) associated with the data are: \n";
      for ( int i = 0; i < arrayOfFormats->Length; i++ )
      {
         textBox1->Text = String::Concat( textBox1->Text, arrayOfFormats[ i ], "\n" );
      }
      
      // Gets the all data formats and data conversion formats for the DataObject.
      arrayOfFormats = myDataObject->GetFormats( true );
      
      // Prints the results.
      textBox1->Text = String::Concat( textBox1->Text , "The data formats and conversion ",
         "format(s) associated with the data are: \n" );
      for ( int i = 0; i < arrayOfFormats->Length; i++ )
      {
         textBox1->Text = String::Concat( textBox1->Text, arrayOfFormats[ i ], "\n" );
      }
   }