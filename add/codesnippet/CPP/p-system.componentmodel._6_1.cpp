      // Gets the attributes for the property.
      AttributeCollection^ attributes = TypeDescriptor::GetProperties( this )[ "MyPropertyProperty" ]->Attributes;

      // Checks to see if the property is bindable.
      MergablePropertyAttribute^ myAttribute = dynamic_cast<MergablePropertyAttribute^>(attributes[ MergablePropertyAttribute::typeid ]);
      if ( myAttribute->AllowMerge )
      {
         // Insert code here.
      }