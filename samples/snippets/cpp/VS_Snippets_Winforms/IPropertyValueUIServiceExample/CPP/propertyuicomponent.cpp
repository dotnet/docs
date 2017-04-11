

//<Snippet1>
#using <System.Windows.Forms.dll>
#using <System.Drawing.dll>
#using <System.dll>

using namespace System;
using namespace System::Collections;
using namespace System::ComponentModel;
using namespace System::ComponentModel::Design;
using namespace System::Drawing;
using namespace System::Drawing::Design;
using namespace System::IO;
using namespace System::Runtime::Serialization;
using namespace System::Runtime::Serialization::Formatters::Binary;
using namespace System::Windows::Forms;
using namespace System::Windows::Forms::Design;

namespace PropertyValueUIServiceExample
{

   // This component obtains the IPropertyValueUIService and adds a
   // PropertyValueUIHandler that provides PropertyValueUIItem objects
   // which provide an image, ToolTip, and invoke event handler to
   // any properties named horizontalMargin and verticalMargin,
   // such as the example integer properties on this component.
   public ref class PropertyUIComponent: public System::ComponentModel::Component
   {
   public:

      property int horizontalMargin 
      {
         // Example property for which to provide a PropertyValueUIItem.
         int get()
         {
            return hMargin;
         }

         void set( int value )
         {
            hMargin = value;
         }

      }

      property int verticalMargin 
      {
         // Example property for which to provide a PropertyValueUIItem.
         int get()
         {
            return vMargin;
         }

         void set( int value )
         {
            vMargin = value;
         }

      }

   private:

      // Field storing the value of the horizontalMargin property.
      int hMargin;

      // Field storing the value of the verticalMargin property.
      int vMargin;

      // Base64-encoded serialized image data for image icon.
      String^ imageBlob1;

   public:

      // Constructor.
      PropertyUIComponent( System::ComponentModel::IContainer^ container )
      {
         imageBlob1 = "AAEAAAD/////AQAAAAAAAAAMAgAAAFRTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0xLjAuMzMwMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJhd2luZy5CaXRtYXABAAAABERhdGEHAgIAAAAJAwAAAA8DAAAA9gAAAAJCTfYAAAAAAAAANgAAACgAAAAIAAAACAAAAAEAGAAAAAAAAAAAAMQOAADEDgAAAAAAAAAAAAD///////////////////////////////////8AAAD///////////////8AAAD///////8AAAD///////////////8AAAD///////8AAAD///8AAAAAAAD///8AAAD///////8AAAD///8AAAAAAAD///8AAAD///////8AAAD///////////////8AAAD///////8AAAD///////////////8AAAD///////////////////////////////////8L";
         if ( container != nullptr )
                  container->Add( this );

         hMargin = 0;
         vMargin = 0;
      }


      // Default component constructor that specifies no container.
      PropertyUIComponent()
      {
         imageBlob1 = "AAEAAAD/////AQAAAAAAAAAMAgAAAFRTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0xLjAuMzMwMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJhd2luZy5CaXRtYXABAAAABERhdGEHAgIAAAAJAwAAAA8DAAAA9gAAAAJCTfYAAAAAAAAANgAAACgAAAAIAAAACAAAAAEAGAAAAAAAAAAAAMQOAADEDgAAAAAAAAAAAAD///////////////////////////////////8AAAD///////////////8AAAD///////8AAAD///////////////8AAAD///////8AAAD///8AAAAAAAD///8AAAD///////8AAAD///8AAAAAAAD///8AAAD///////8AAAD///////////////8AAAD///////8AAAD///////////////8AAAD///////////////////////////////////8L";
         hMargin = 0;
         vMargin = 0;
      }


   private:

      //<Snippet2>
      // PropertyValueUIHandler delegate that provides PropertyValueUIItem
      // objects to any properties named horizontalMargin or verticalMargin.
      void marginPropertyValueUIHandler( System::ComponentModel::ITypeDescriptorContext^ /*context*/, System::ComponentModel::PropertyDescriptor^ propDesc, ArrayList^ itemList )
      {
         // A PropertyValueUIHandler added to the IPropertyValueUIService
         // is queried once for each property of a component and passed
         // a PropertyDescriptor that represents the characteristics of
         // the property when the Properties window is set to a new
         // component. A PropertyValueUIHandler can determine whether
         // to add a PropertyValueUIItem for the object to its ValueUIItem
         // list depending on the values of the PropertyDescriptor.
         if ( propDesc->DisplayName->Equals( "horizontalMargin" ) )
         {
            Image^ img = DeserializeFromBase64Text( imageBlob1 );
            itemList->Add( gcnew PropertyValueUIItem( img,gcnew PropertyValueUIItemInvokeHandler( this, &PropertyUIComponent::marginInvoke ),"Test ToolTip" ) );
         }

         if ( propDesc->DisplayName->Equals( "verticalMargin" ) )
         {
            Image^ img = DeserializeFromBase64Text( imageBlob1 );
            img->RotateFlip( RotateFlipType::Rotate90FlipNone );
            itemList->Add( gcnew PropertyValueUIItem( img,gcnew PropertyValueUIItemInvokeHandler( this, &PropertyUIComponent::marginInvoke ),"Test ToolTip" ) );
         }
      }
      //</Snippet2>

      // Invoke handler associated with the PropertyValueUIItem objects
      // provided by the marginPropertyValueUIHandler.
      void marginInvoke( System::ComponentModel::ITypeDescriptorContext^ /*context*/, System::ComponentModel::PropertyDescriptor^ /*propDesc*/, PropertyValueUIItem^ /*item*/ )
      {
         MessageBox::Show( "Test invoke message box" );
      }

   public:

      property System::ComponentModel::ISite^ Site 
      {
         // Component::Site  to add the marginPropertyValueUIHandler
         // when the component is sited, and to remove it when the site is
         // set to 0.
         virtual System::ComponentModel::ISite^ get() override
         {
            return __super::Site;
         }

         virtual void set( System::ComponentModel::ISite^ value ) override
         {
            if ( value != nullptr )
            {
               __super::Site = value;
               IPropertyValueUIService^ uiService = dynamic_cast<IPropertyValueUIService^>(this->GetService( IPropertyValueUIService::typeid ));
               if ( uiService != nullptr )
                              uiService->AddPropertyValueUIHandler( gcnew PropertyValueUIHandler( this, &PropertyUIComponent::marginPropertyValueUIHandler ) );
            }
            else
            {
               IPropertyValueUIService^ uiService = dynamic_cast<IPropertyValueUIService^>(this->GetService( IPropertyValueUIService::typeid ));
               if ( uiService != nullptr )
                              uiService->RemovePropertyValueUIHandler( gcnew PropertyValueUIHandler( this, &PropertyUIComponent::marginPropertyValueUIHandler ) );
               __super::Site = value;
            }
         }
      }

   private:

      // This method can be used to retrieve an Image from a block
      // of Base64-encoded text.
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
