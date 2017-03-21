      // Gets the attributes for the property.
      AttributeCollection^ attributes = TypeDescriptor::GetProperties( this )[ "MyProperty" ]->Attributes;

      // Checks to see whether the property is read-only.
      ReadOnlyAttribute^ myAttribute = dynamic_cast<ReadOnlyAttribute^>(attributes[ ReadOnlyAttribute::typeid ]);
      if ( myAttribute->IsReadOnly )
      {
         // Insert code here.
      }