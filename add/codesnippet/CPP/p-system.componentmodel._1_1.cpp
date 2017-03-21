      // Gets the attributes for the property.
      AttributeCollection^ attributes = TypeDescriptor::GetProperties( this )[ "MyProperty" ]->Attributes;

      // Checks to see if the property is browsable.
      BrowsableAttribute^ myAttribute = dynamic_cast<BrowsableAttribute^>(attributes[ BrowsableAttribute::typeid ]);
      if ( myAttribute->Browsable )
      {
         // Insert code here.
      }