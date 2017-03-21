private:
   void CreateTextDataObject()
   {
      // Creates a new data object using a string.
      String^ myString = "My text string";
      DataObject^ myDataObject = gcnew DataObject( myString );
      
      // Prints the string in a text box.
      textBox1->Text = myDataObject->GetData( DataFormats::Text )->ToString();
   }