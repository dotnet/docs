private:
   void button2_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      // Declares an IDataObject to hold the data returned from the clipboard.
      // Retrieves the data from the clipboard.
      IDataObject^ iData = Clipboard::GetDataObject();
      
      // Determines whether the data is in a format you can use.
      if ( iData->GetDataPresent( DataFormats::Text ) )
      {
         
         // Yes it is, so display it in a text box.
         textBox2->Text = (String^)(iData->GetData( DataFormats::Text ));
      }
      else
      {
         
         // No it is not.
         textBox2->Text = "Could not retrieve data off the clipboard.";
      }
   }