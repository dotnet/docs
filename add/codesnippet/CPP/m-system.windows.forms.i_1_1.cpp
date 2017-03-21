private:
   void SetData1()
   {
      // Creates a component to store in the data object.
      Component^ myComponent = gcnew Component;
      
      // Creates a data object.
      DataObject^ myDataObject = gcnew DataObject;
      
      // Adds the component to the data object.
      myDataObject->SetData( myComponent );
      
      // Checks whether data of the specified type is in the data object.
      Type^ myType = myComponent->GetType();
      String^ myMessageText;
      if ( myDataObject->GetDataPresent( myType ) )
      {
         myMessageText = "Data of type " + myType->Name +
            " is present in the data object";
      }
      else
      {
         myMessageText = "Data of type " + myType->Name +
            " is not present in the data object";
      }
      
      // Displays the result in a message box.
      MessageBox::Show( myMessageText, "The Test Result" );
   }