

#using <system.dll>
ref class C
{
public:

   // <Snippet1>
   property int MyProperty 
   {
      [System::ComponentModel::Bindable(true)]
      int get()
      {
         // Insert code here.
         return 0;
      }

      [System::ComponentModel::Bindable(true)]
      void set( int )
      {
         // Insert code here.
      }
   }
   // </Snippet1>

   property int MyProperty2 
   {
      int get()
      {
         // <Snippet2>
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
         // </Snippet2>
         return 0;
      }
   }

   property int MyProperty3 
   {
      int get()
      {
         // <Snippet3>
         using namespace System::ComponentModel;
         AttributeCollection^ attributes = TypeDescriptor::GetAttributes( MyProperty );
         if ( attributes[ BindableAttribute::typeid ]->Equals( BindableAttribute::Yes ) )
         {
            // Insert code here.
         }
         // </Snippet3>
         return 0;
      }
   }
};
