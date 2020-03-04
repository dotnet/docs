

//<Snippet1>
#using <System.Windows.Forms.dll>
#using <System.Drawing.dll>
#using <System.dll>

using namespace System;
using namespace System::ComponentModel;
using namespace System::ComponentModel::Design;
using namespace System::Collections;
using namespace System::Drawing;
using namespace System::IO;
using namespace System::Reflection;
using namespace System::Runtime::Serialization;
using namespace System::Runtime::Serialization::Formatters::Binary;
using namespace System::Windows::Forms;
using namespace System::Windows::Forms::Design;

ref class TypeEventsTab;

// This component adds a TypeEventsTab to the Properties Window.

[PropertyTabAttribute(TypeEventsTab::typeid,PropertyTabScope::Document)]
public ref class TypeEventsTabComponent: public Component
{
public:
   TypeEventsTabComponent(){}

};


// This example events tab lists events by their delegate type.
[System::Security::Permissions::PermissionSetAttribute
      (System::Security::Permissions::SecurityAction::InheritanceDemand, Name="FullTrust")]
[System::Security::Permissions::PermissionSetAttribute
      (System::Security::Permissions::SecurityAction::Demand, Name="FullTrust")]
public ref class TypeEventsTab: public System::Windows::Forms::Design::EventsTab
{
private:

   // This string contains a Base-64 encoded and serialized example 
   // property tab image.

   [BrowsableAttribute(true)]
   String^ img;
   IServiceProvider^ sp;

public:
   TypeEventsTab( IServiceProvider^ sp )
      : EventsTab( sp )
   {
      this->sp = sp;
      String^ s = "AAEAAAD/////AQAAAAAAAAAMAgAAAFRTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0xLjAuMzMwMC4w"
      "LCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJhd2luZy5CaXRt"
      "YXABAAAABERhdGEHAgIAAAAJAwAAAA8DAAAAtgIAAAJCTbYCAAAAAAAANgAAACgAAAANAAAAEAAAAAEAGAAAAAAAAAAAAMQOAADED"
      "gAAAAAAAAAAAADO1tnO1tnO1tnO1tnO1tnO1tnO1tnO1tnO1tnO1tnO1tnO1tnO1tn/ztbZztbZHh4eHh4eztbZztbZztbZztbZztb"
      "ZztbZztbZztbZztbZ/87W2c7W2QDBAB4eHh4eHs7W2c7W2c7W2c7W2c7W2c7W2c7W2c7W2f/O1tnO1tnO1tkAwQAeHh4eHh7O1tnO1"
      "tnO1tnO1tnO1tnO1tnO1tn/ztbZztbZlJSU////AMEAHh4eHh4eztbZztbZztbZztbZztbZztbZ/87W2c7W2c7W2ZSUlP///wDBAB4"
      "eHh4eHs7W2c7W2c7W2c7W2c7W2f/O1tnO1tnO1tnO1tmUlJT///8AwQAeHh4eHh7O1tnO1tnO1tnO1tn/ztbZHh4eHh4eHh4eHh4eH"
      "h4e////AIAAHh4eHh4eztbZztbZztbZ/87W2ZSUlP///wDBAADBAADBAADBAADBAACAAB4eHh4eHs7W2c7W2f/O1tnO1tmUlJT///8"
      "AwQAAgAAeHh4eHh7O1tnO1tnO1tnO1tnO1tn/ztbZztbZztbZlJSU////AMEAAIAAHh4eHh4eztbZztbZztbZztbZ/87W2c7W2c7W2"
      "c7W2ZSUlP///wDBAACAAB4eHh4eHs7W2c7W2c7W2f/O1tnO1tnO1tnO1tnO1tmUlJT///8AwQAAgAAeHh4eHh7O1tnO1tn/ztbZztb"
      "ZztbZztbZztbZztbZlJSU////AMEAAIAAHh4eHh4eztbZ/87W2c7W2c7W2c7W2c7W2c7W2c7W2ZSUlP///wDBAACAAB4eHs7W2f/O1"
      "tnO1tnO1tnO1tnO1tnO1tnO1tnO1tnO1tnO1tnO1tnO1tnO1tn/Cw==";
      img = s;
   }

   // Returns the properties of the specified component extended with a 
   // CategoryAttribute reflecting the name of the type of the property.
   virtual System::ComponentModel::PropertyDescriptorCollection^ GetProperties( ITypeDescriptorContext^ /*context*/, Object^ component, array<System::Attribute^>^attributes ) override
   {
      // Obtain an instance of the IEventBindingService.
      IEventBindingService^ eventPropertySvc = dynamic_cast<IEventBindingService^>(sp->GetService( IEventBindingService::typeid ));
      
      // Return if an IEventBindingService could not be obtained.
      if ( eventPropertySvc == nullptr )
            return gcnew PropertyDescriptorCollection( nullptr );

      // Obtain the events on the component.
      EventDescriptorCollection^ events = TypeDescriptor::GetEvents( component, attributes );

      // Create an array of the events, where each event is assigned 
      // a category matching its type.
      array<EventDescriptor^>^newEvents = gcnew array<EventDescriptor^>(events->Count);
      for ( int i = 0; i < events->Count; i++ )
      {
         array<Attribute^>^temp = {gcnew CategoryAttribute( events[ i ]->EventType->FullName )};
         newEvents[ i ] = TypeDescriptor::CreateEvent( events[ i ]->ComponentType, events[ i ], temp );
      }
      events = gcnew EventDescriptorCollection( newEvents );

      // Return event properties for the event descriptors.
      return eventPropertySvc->GetEventProperties( events );
   }

   property String^ TabName 
   {
      // Provides the name for the event property tab.
      virtual String^ get() override
      {
         return "Events by Type";
      }
   }

   property System::Drawing::Bitmap^ Bitmap 
   {
      // Provides an image for the event property tab.
      virtual System::Drawing::Bitmap^ get() override
      {
         System::Drawing::Bitmap^ bmp = gcnew System::Drawing::Bitmap( DeserializeFromBase64Text( img ) );
         return bmp;
      }
   }

private:

   // This method can be used to retrieve an Image from a block of 
   // Base64-encoded text.
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
//</Snippet1>
