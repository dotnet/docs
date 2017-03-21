private:
   void MyEnumerator()
   {
      // Creates a new collection and assigns it the attributes for button1.
      AttributeCollection^ attributes;
      attributes = TypeDescriptor::GetAttributes( button1 );
      
      // Creates an enumerator for the collection.
      System::Collections::IEnumerator^ ie = attributes->GetEnumerator();
      
      // Prints the type of each attribute in the collection.
      Object^ myAttribute;
      System::Text::StringBuilder^ text = gcnew System::Text::StringBuilder;
      while ( ie->MoveNext() == true )
      {
         myAttribute = ie->Current;
         text->Append( myAttribute );
         text->Append( '\n' );
      }
      textBox1->Text = text->ToString();
   }