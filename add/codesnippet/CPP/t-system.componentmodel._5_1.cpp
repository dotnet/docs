      // Creates a new collection and assign it the properties for button1.
      PropertyDescriptorCollection^ properties = TypeDescriptor::GetProperties( button1 );

      // Sets an PropertyDescriptor to the specific property.
      System::ComponentModel::PropertyDescriptor^ myProperty = properties->Find( "Text", false );

      // Prints the property and the property description.
      textBox1->Text = String::Concat( myProperty->DisplayName, "\n" );
      textBox1->Text = String::Concat( textBox1->Text, myProperty->Description, "\n" );
      textBox1->Text = String::Concat( textBox1->Text, myProperty->Category, "\n" );