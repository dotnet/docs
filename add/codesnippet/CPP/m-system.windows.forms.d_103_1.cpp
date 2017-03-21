private:
   void GetAllFormats()
   {
      // Creates a new data object using a string and the text format.
      DataObject^ myDataObject = gcnew DataObject( DataFormats::Text,"Another string" );
      
      // Gets all the data formats and data conversion formats in the DataObject.
      array<String^>^ arrayOfFormats = myDataObject->GetFormats();
      
      // Prints the results.
      textBox1->Text = "The format(s) associated with the data are: \n";
      for ( int i = 0; i < arrayOfFormats->Length; i++ )
      {
         textBox1->Text = String::Concat( textBox1->Text, arrayOfFormats[ i ], "\n" );
      }
   }