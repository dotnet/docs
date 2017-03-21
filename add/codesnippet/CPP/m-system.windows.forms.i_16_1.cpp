private:
   void GetData3()
   {
      // Creates a new data object using a text string.
      String^ myString = "Hello World!";
      DataObject^ myDataObject = gcnew DataObject( DataFormats::Text,myString );

      // Displays the string with autoConvert equal to false.
      if ( myDataObject->GetData( "System::String", false ) != nullptr )
      {
         // Displays the string in a message box.
         MessageBox::Show( myDataObject->GetData( "System::String", false ) + ".", "Message #1" );
      }
      else
            MessageBox::Show( "Could not find data of the specified format.", "Message #1" );

      // Displays a not found message in a message box.
      // Displays the string in a text box with autoConvert equal to true.
      String^ myData = "The data is " + myDataObject->GetData( "System::String", true ) + ".";
      MessageBox::Show( myData, "Message #2" );
   }