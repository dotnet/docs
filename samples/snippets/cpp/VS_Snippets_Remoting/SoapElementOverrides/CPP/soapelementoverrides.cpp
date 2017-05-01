

//<Snippet1>
#using <System.Xml.dll>
#using <System.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml::Serialization;
using namespace System::Collections;
using namespace System::Xml;
using namespace System::Text;
public ref class Thing
{
public:

   [SoapElement(IsNullable=true)]
   String^ ThingName;
};

public ref class Transportation
{
public:

   // The SoapElementAttribute specifies that the
   // generated XML element name will be S"Wheels"
   // instead of S"Vehicle".

   [SoapElement("Wheels")]
   String^ Vehicle;

   [SoapElement(DataType="dateTime")]
   DateTime CreationDate;

   [SoapElement(IsNullable=true)]
   Thing^ thing;
};

public ref class Test
{
public:

   // Return an XmlSerializer used for overriding.
   XmlSerializer^ CreateSoapOverrider()
   {
      // Create the SoapAttributes and SoapAttributeOverrides objects.
      SoapAttributes^ soapAttrs = gcnew SoapAttributes;
      SoapAttributeOverrides^ soapOverrides = gcnew SoapAttributeOverrides;

      // Create an SoapElementAttribute to the Vehicles property.
      SoapElementAttribute^ soapElement1 = gcnew SoapElementAttribute( "Truck" );

      // Set the SoapElement to the Object*.
      soapAttrs->SoapElement = soapElement1;

      // Add the SoapAttributes to the SoapAttributeOverrides,specifying the member to.
      soapOverrides->Add( Transportation::typeid, "Vehicle", soapAttrs );

      // Create the XmlSerializer, and return it.
      XmlTypeMapping^ myTypeMapping = (gcnew SoapReflectionImporter( soapOverrides ))->ImportTypeMapping( Transportation::typeid );
      return gcnew XmlSerializer( myTypeMapping );
   }

   void SerializeOverride( String^ filename )
   {
      // Create an XmlSerializer instance.
      XmlSerializer^ ser = CreateSoapOverrider();

      // Create the Object* and serialize it.
      Transportation^ myTransportation = gcnew Transportation;
      myTransportation->Vehicle = "MyCar";
      myTransportation->CreationDate = DateTime::Now;
      myTransportation->thing = gcnew Thing;
      XmlTextWriter^ writer = gcnew XmlTextWriter( filename,Encoding::UTF8 );
      writer->Formatting = Formatting::Indented;
      writer->WriteStartElement( "wrapper" );
      ser->Serialize( writer, myTransportation );
      writer->WriteEndElement();
      writer->Close();
   }

   void SerializeObject( String^ filename )
   {
      // Create an XmlSerializer instance.
      XmlSerializer^ ser = gcnew XmlSerializer( Transportation::typeid );
      Transportation^ myTransportation = gcnew Transportation;
      myTransportation->Vehicle = "MyCar";
      myTransportation->CreationDate = DateTime::Now;
      myTransportation->thing = gcnew Thing;
      XmlTextWriter^ writer = gcnew XmlTextWriter( filename,Encoding::UTF8 );
      writer->Formatting = Formatting::Indented;
      writer->WriteStartElement( "wrapper" );
      ser->Serialize( writer, myTransportation );
      writer->WriteEndElement();
      writer->Close();
   }
};

int main()
{
   Test^ t = gcnew Test;
   t->SerializeObject( "SoapElementOriginal.xml" );
   t->SerializeOverride( "SoapElementOverride.xml" );
   Console::WriteLine( "Finished writing two XML files." );
}
//</Snippet1>
