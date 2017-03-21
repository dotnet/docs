      // Gets the attributes for the property.
      AttributeCollection^ attributes = TypeDescriptor::GetProperties( this )[ "MyProperty" ]->Attributes;

      // Checks to see if the property needs to be localized.
      LocalizableAttribute^ myAttribute = dynamic_cast<LocalizableAttribute^>(attributes[ LocalizableAttribute::typeid ]);
      if ( myAttribute->IsLocalizable )
      {
         // Insert code here.
      }