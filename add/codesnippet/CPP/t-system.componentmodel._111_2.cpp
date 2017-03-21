      // Gets the attributes for the property.
      AttributeCollection^ attributes = TypeDescriptor::GetProperties( this )[ "MyImage" ]->Attributes;

      // Prints the description by retrieving the CategoryAttribute.
      // from the AttributeCollection.
      CategoryAttribute^ myAttribute = static_cast<CategoryAttribute^>(attributes[ CategoryAttribute::typeid ]);
      Console::WriteLine( myAttribute->Category );