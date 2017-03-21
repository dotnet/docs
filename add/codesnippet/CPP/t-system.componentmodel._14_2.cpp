      // Gets the attributes for the property.
      AttributeCollection^ attributes = TypeDescriptor::GetProperties( this )[ "MyProperty" ]->Attributes;

      // Checks to see if the value of the RecommendedAsConfigurableAttribute is Yes.
      if ( attributes[ RecommendedAsConfigurableAttribute::typeid ]->Equals( RecommendedAsConfigurableAttribute::Yes ) )
      {
         // Insert code here.
      }

      // This is another way to see if the property is recommended as configurable.
      RecommendedAsConfigurableAttribute^ myAttribute = dynamic_cast<RecommendedAsConfigurableAttribute^>(attributes[ RecommendedAsConfigurableAttribute::typeid ]);
      if ( myAttribute->RecommendedAsConfigurable )
      {
         // Insert code here.
      }