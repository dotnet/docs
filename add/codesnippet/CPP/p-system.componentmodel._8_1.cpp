      // Gets the attributes for the property.
      AttributeCollection^ attributes = TypeDescriptor::GetProperties( this )[ "MyProperty" ]->Attributes;

      // Checks to see if the value of the DesignerSerializationVisibilityAttribute is set to Content.
      if ( attributes[ DesignerSerializationVisibilityAttribute::typeid ]->Equals( DesignerSerializationVisibilityAttribute::Content ) )
      {
         // Insert code here.
      }

      
      // This is another way to see whether the property is marked as serializing content.
      DesignerSerializationVisibilityAttribute^ myAttribute = dynamic_cast<DesignerSerializationVisibilityAttribute^>(attributes[ DesignerSerializationVisibilityAttribute::typeid ]);
      if ( myAttribute->Visibility == DesignerSerializationVisibility::Content )
      {
         // Insert code here.
      }