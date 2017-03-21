      // Gets the attributes for the property.
      AttributeCollection^ attributes = TypeDescriptor::GetProperties( this )[ "MyProperty" ]->Attributes;
      
      // Checks to see if the property is bindable.
      BindableAttribute^ myAttribute = dynamic_cast<BindableAttribute^>(attributes[ BindableAttribute::typeid ]);
      if ( myAttribute->Bindable )
      {
         // Insert code here.
      }