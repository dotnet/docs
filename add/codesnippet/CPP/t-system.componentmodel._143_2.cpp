      // Gets the attributes for the property.
      AttributeCollection^ attributes = TypeDescriptor::GetProperties( this )[ "MyProperty" ]->Attributes;

      /* Prints the default value by retrieving the DefaultValueAttribute 
            * from the AttributeCollection. */
      DefaultValueAttribute^ myAttribute = dynamic_cast<DefaultValueAttribute^>(attributes[ DefaultValueAttribute::typeid ]);
      Console::WriteLine( "The default value is: {0}", myAttribute->Value );