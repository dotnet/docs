private:
   void CreateTextDataObject2()
   {
      // Creates a new data object using a string.
      String^ myString = "My next text string";
      DataObject^ myDataObject = gcnew DataObject( "System.String",myString );
      
      // Prints the string in a text box.
      textBox1->Text = myDataObject->GetData( DataFormats::Text )->ToString();
   }