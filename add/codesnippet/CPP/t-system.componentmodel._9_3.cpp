      AttributeCollection^ attributes = TypeDescriptor::GetAttributes( MyProperty );
      if ( attributes[ RecommendedAsConfigurableAttribute::typeid ]->Equals( RecommendedAsConfigurableAttribute::Yes ) )
      {
         // Insert code here.
      }