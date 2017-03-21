private:
   void AddMyData3()
   {
      // Creates a component to store in the data object.
      Component^ myComponent = gcnew Component;
      
      // Creates a new data object.
      DataObject^ myDataObject = gcnew DataObject;
      
      // Adds the component to the DataObject.
      myDataObject->SetData( myComponent );
      
      // Prints whether data of the specified type is in the DataObject.
      Type^ myType = myComponent->GetType();
      if ( myDataObject->GetDataPresent( myType ) )
      {
         textBox1->Text = String::Concat( "Data of type ", myType->Name,
           " is present in the DataObject" );
      }
      else
      {
         textBox1->Text = String::Concat( "Data of type ", myType->Name,
           " is not present in the DataObject" );
      }
   }