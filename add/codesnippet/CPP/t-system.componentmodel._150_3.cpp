         using namespace System::ComponentModel;
         AttributeCollection^ attributes = TypeDescriptor::GetAttributes( MyProperty );
         if ( attributes[ BindableAttribute::typeid ]->Equals( BindableAttribute::Yes ) )
         {
            // Insert code here.
         }