private:
   void GetIfPresent2()
   {
      // Creates a component to store in the data object.
      Component^ myComponent = gcnew Component;
      
      // Creates a new data object and assigns it the component.
      DataObject^ myDataObject = gcnew DataObject( myComponent );
      
      // Creates a type to store the type of data.
      Type^ myType = myComponent->GetType();
      
      // Determines if the DataObject has data of the Type format.
      textBox1->Text = String::Concat( "Is the specified data type available ",
         "in the DataObject? ", myDataObject->GetDataPresent( myType ), "\n" );
      
      // Retrieves the data using its type format, and displays the type.
      Object^ myObject = myDataObject->GetData( myType );
      textBox1->Text = String::Concat( textBox1->Text, "The data type stored ",
         "in the DataObject is: ", myObject->GetType()->Name );
   }