      FileStream^ myFileStream = File::Open( "Temp.dif", FileMode::Open );

      // Store the data into Dif format.
      DataObject^ myDataObject = gcnew DataObject;
      myDataObject->SetData( DataFormats::Dif, myFileStream );

      // Check whether the data is stored or not in the specified format.
      bool formatPresent = myDataObject->GetDataPresent( DataFormats::Dif );
      if ( formatPresent )
      {
         Console::WriteLine( "The data has been stored in the Dif format is:'{0}'", formatPresent );
      }
      else
      {
         Console::WriteLine( "The data has not been stored in the specified format" );
      }