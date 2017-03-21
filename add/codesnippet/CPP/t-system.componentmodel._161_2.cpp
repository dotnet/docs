         // Gets the attributes for the property.
         AttributeCollection^ attributes = TypeDescriptor::GetProperties( this )[ "MyProperty" ]->Attributes;

         // Checks to see if the value of the MergablePropertyAttribute is Yes.
         if ( attributes[ MergablePropertyAttribute::typeid ]->Equals( MergablePropertyAttribute::Yes ) )
         {
            // Insert code here.
         }

         // This is another way to see if the property is bindable.
         MergablePropertyAttribute^ myAttribute = dynamic_cast<MergablePropertyAttribute^>(attributes[ MergablePropertyAttribute::typeid ]);
         if ( myAttribute->AllowMerge )
         {
            // Insert code here.
         }