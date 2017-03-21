         AttributeCollection^ attributes = TypeDescriptor::GetAttributes( MyProperty );
         if ( attributes[ MergablePropertyAttribute::typeid ]->Equals( MergablePropertyAttribute::Yes ) )
         {
            // Insert code here.
         }