      // Returns the properties of the specified component extended with
      // a CategoryAttribute reflecting the name of the type of the property.
      [ReflectionPermission(SecurityAction::Demand, Flags=ReflectionPermissionFlag::MemberAccess)]
      virtual System::ComponentModel::PropertyDescriptorCollection^ GetProperties( Object^ component, array<System::Attribute^>^attributes ) override
      {
         PropertyDescriptorCollection^ props;
         if ( attributes == nullptr )
                  props = TypeDescriptor::GetProperties( component );
         else
                  props = TypeDescriptor::GetProperties( component, attributes );

         array<PropertyDescriptor^>^propArray = gcnew array<PropertyDescriptor^>(props->Count);
         for ( int i = 0; i < props->Count; i++ )
         {
            // Create a new PropertyDescriptor from the old one, with
            // a CategoryAttribute matching the name of the type.
            array<Attribute^>^temp0 = {gcnew CategoryAttribute( props[ i ]->PropertyType->Name )};
            propArray[ i ] = TypeDescriptor::CreateProperty( props[ i ]->ComponentType, props[ i ], temp0 );

         }
         return gcnew PropertyDescriptorCollection( propArray );
      }

      virtual System::ComponentModel::PropertyDescriptorCollection^ GetProperties( Object^ component ) override
      {
         return this->GetProperties( component, nullptr );
      }