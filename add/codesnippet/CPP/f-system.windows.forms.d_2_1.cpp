   try
   {
      String^ myString = "This is a String from the ClipBoard";
      
      // Sets the data into the Clipboard.
      Clipboard::SetDataObject( myString );
      IDataObject^ myDataObject = Clipboard::GetDataObject();
      // Checks whether the format of the data is 'UnicodeText' or not.
      if ( myDataObject->GetDataPresent( DataFormats::UnicodeText ) )
      {
         Console::WriteLine( "Data in 'UnicodeText' format: " +
            myDataObject->GetData( DataFormats::UnicodeText ) );
      }
      else
      {
         Console::WriteLine( "No String information was contained in the clipboard." );
      }

      // Checks whether the format of the data is 'Text' or not.
      if ( myDataObject->GetDataPresent( DataFormats::Text ) )
      {
         String^ clipString = (String^)(myDataObject->GetData( DataFormats::StringFormat ));
         Console::WriteLine( "Data in 'Text' format: {0}", clipString );
      }
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( e->Message );
   }