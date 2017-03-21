private:
   void GetData1()
   {
      // Creates a new data object using a string and the text format.
      String^ myString = "My text string";
      DataObject^ myDataObject = gcnew DataObject( DataFormats::Text,myString );

      // Displays the string in a text box.
      textBox1->Text = myDataObject->GetData( DataFormats::Text )->ToString();
   }