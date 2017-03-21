private:
   void FindProperty()
   {
      // Creates a new collection and assign it the properties for button1.
      PropertyDescriptorCollection^ properties = TypeDescriptor::GetProperties( button1 );
      
      // Sets a PropertyDescriptor to the specific property.
      PropertyDescriptor^ myProperty = properties->Find( "Opacity", false );
      
      // Prints the property and the property description.
      textBox1->Text = myProperty->DisplayName + "\n" + myProperty->Description;
   }