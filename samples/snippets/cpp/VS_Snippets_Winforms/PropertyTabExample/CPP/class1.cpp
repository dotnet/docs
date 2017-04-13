//<Snippet1>
#using <System.Windows.Forms.dll>
#using <System.Drawing.dll>
#using <System.dll>

using namespace System;
using namespace System::ComponentModel;
using namespace System::ComponentModel::Design;
using namespace System::Drawing;
using namespace System::IO;
using namespace System::Reflection;
using namespace System::Runtime::Serialization;
using namespace System::Runtime::Serialization::Formatters::Binary;
using namespace System::Windows::Forms;
using namespace System::Windows::Forms::Design;
using namespace System::Security::Permissions;

namespace TypeCategoryTabExample
{
   ref class TypeCategoryTab;

   // forward declaration.
   // This component adds a TypeCategoryTab to the propery browser
   // that is available for any components in the current design mode document.

   [PropertyTabAttribute(TypeCategoryTabExample::TypeCategoryTab::typeid,PropertyTabScope::Document)]
   public ref class TypeCategoryTabComponent: public System::ComponentModel::Component
   {
   public:
      TypeCategoryTabComponent(){}
   };

   // A TypeCategoryTab property tab lists properties by the
   // category of the type of each property.
   public ref class TypeCategoryTab: public PropertyTab
   {
   private:

      // This String^ contains a Base-64 encoded and serialized example property tab image.

      [BrowsableAttribute(true)]
      String^ img;

   public:
      TypeCategoryTab()
      {
         img = "AAEAAAD/////AQAAAAAAAAAMAgAAAFRTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0xLjAuMzMwMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJhd2luZy5CaXRtYXABAAAABERhdGEHAgIAAAAJAwAAAA8DAAAA9gAAAAJCTfYAAAAAAAAANgAAACgAAAAIAAAACAAAAAEAGAAAAAAAAAAAAMQOAADEDgAAAAAAAAAAAAD///////////////////////////////////9ZgABZgADzPz/zPz/zPz9AgP//////////gAD/gAD/AAD/AAD/AACKyub///////+AAACAAAAAAP8AAP8AAP9AgP////////9ZgABZgABz13hz13hz13hAgP//////////gAD/gACA/wCA/wCA/wAA//////////+AAACAAAAAAP8AAP8AAP9AgP////////////////////////////////////8L";
      }

	  //<Snippet2>
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
	  //</Snippet2>

      property String^ TabName 
      {
         // Provides the name for the property tab.
         virtual String^ get() override
         {
            return "Properties by Type";
         }
      }

      property System::Drawing::Bitmap^ Bitmap 
      {
         // Provides an image for the property tab.
         virtual System::Drawing::Bitmap^ get() override
         {
            System::Drawing::Bitmap^ bmp = gcnew System::Drawing::Bitmap( DeserializeFromBase64Text( img ) );
            return bmp;
         }
      }

   private:

      // This method can be used to retrieve an Image from a block of Base64-encoded text.
      Image^ DeserializeFromBase64Text( String^ text )
      {
         Image^ img = nullptr;
         array<Byte>^memBytes = Convert::FromBase64String( text );
         IFormatter^ formatter = gcnew BinaryFormatter;
         MemoryStream^ stream = gcnew MemoryStream( memBytes );
         img = dynamic_cast<Image^>(formatter->Deserialize( stream ));
         stream->Close();
         return img;
      }
   };
}
//</Snippet1>
