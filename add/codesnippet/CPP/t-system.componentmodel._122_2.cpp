      // Gets the attributes for the property.
      AttributeCollection^ attributes = TypeDescriptor::GetProperties( this )[ "MyImage" ]->Attributes;
      
      /* Prints the description by retrieving the DescriptionAttribute 
            * from the AttributeCollection. */
      DescriptionAttribute^ myAttribute = dynamic_cast<DescriptionAttribute^>(attributes[ DescriptionAttribute::typeid ]);
      Console::WriteLine( myAttribute->Description );