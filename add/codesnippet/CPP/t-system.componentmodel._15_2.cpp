         // Gets the attributes for the property.
         AttributeCollection^ attributes = TypeDescriptor::GetProperties( this )[ "MyProperty" ]->Attributes;
         
         // Checks to see if the value of the BrowsableAttribute is Yes.
         if ( attributes[ BrowsableAttribute::typeid ]->Equals( BrowsableAttribute::Yes ) )
         {
            
            // Insert code here.
         }

         // This is another way to see whether the property is browsable.
         BrowsableAttribute^ myAttribute = dynamic_cast<BrowsableAttribute^>(attributes[ BrowsableAttribute::typeid ]);
         if ( myAttribute->Browsable )
         {
            // Insert code here.
         }