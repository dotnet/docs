         using namespace System::ComponentModel;

         // Gets the attributes for the property.
         AttributeCollection^ attributes = TypeDescriptor::GetProperties( this )[ "MyProperty" ]->Attributes;

         // Checks to see if the value of the BindableAttribute is Yes.
         if ( attributes[ BindableAttribute::typeid ]->Equals( BindableAttribute::Yes ) )
         {
            // Insert code here.
         }

         // This is another way to see whether the property is bindable.
         BindableAttribute^ myAttribute = static_cast<BindableAttribute^>(attributes[ BindableAttribute::typeid ]);
         if ( myAttribute->Bindable )
         {
            // Insert code here.
         }

         // Yet another way to see whether the property is bindable.
         if ( attributes->Contains( BindableAttribute::Yes ) )
         {
            // Insert code here.
         }