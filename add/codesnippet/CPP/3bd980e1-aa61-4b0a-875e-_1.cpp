private:
   void MyEnumerator()
   {
      // Creates a new collection and assigns it the properties for button1.
      PropertyDescriptorCollection^ properties = TypeDescriptor::GetProperties( button1 );
      
      // Creates an enumerator.
      IEnumerator^ ie = properties->GetEnumerator();
      
      // Prints the name of each property in the collection.
      Object^ myProperty;
      while ( ie->MoveNext() == true )
      {
         myProperty = ie->Current;
         textBox1->Text = textBox1->Text + myProperty + "\n";
      }
   }