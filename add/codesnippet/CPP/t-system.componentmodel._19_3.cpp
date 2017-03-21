         AttributeCollection^ attributes = TypeDescriptor::GetAttributes( MyProperty );
         if ( attributes[ BrowsableAttribute::typeid ]->Equals( BrowsableAttribute::Yes ) )
         {
            // Insert code here.
         }