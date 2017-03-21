      AttributeCollection^ attributes = TypeDescriptor::GetAttributes( MyProperty );
      if ( attributes[ ReadOnlyAttribute::typeid ]->Equals( ReadOnlyAttribute::Yes ) )
      {
         // Insert code here.
      }