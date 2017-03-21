         // Gets the attributes for the property.
         AttributeCollection^ attributes = TypeDescriptor::GetProperties( this )[ "GetLanguage" ]->Attributes;

         /* Prints whether the property is marked as DesignOnly 
		 by retrieving the DesignOnlyAttribute from the AttributeCollection. */
         DesignOnlyAttribute^ myAttribute = dynamic_cast<DesignOnlyAttribute^>(attributes[ DesignOnlyAttribute::typeid ]);
         Console::WriteLine( "This property is design only :{0}", myAttribute->IsDesignOnly );