

//<Snippet1>
#using <System.dll>
#using <System.Xml.dll>

using namespace System;
using namespace System::IO;
using namespace System::Text;
using namespace System::Xml;
using namespace System::Xml::Serialization;
using namespace System::Xml::Schema;

//using namespace System::Runtime::Remoting::Metadata;
public ref class Vehicle
{
public:
   String^ licenseNumber;
};


[SoapInclude(Vehicle::typeid)]
public ref class Group
{
public:

   [SoapAttributeAttribute(Namespace="http://www.cpandl.com")]
   String^ GroupName;

   [SoapAttributeAttribute(DataType="base64Binary")]
   array<Byte>^GroupNumber;

   [SoapAttributeAttribute(DataType="date",AttributeName="CreationDate")]
   DateTime Today;

   [SoapElement(DataType="nonNegativeInteger",ElementName="PosInt")]
   String^ PostitiveInt;
   Vehicle^ GroupVehicle;
};

public ref class Run
{
public:
   void SerializeObject( String^ filename )
   {
      // Create an instance of the XmlSerializer class that
      // can generate encoded SOAP messages.
      XmlSerializer^ mySerializer = ReturnSOAPSerializer();
      Group^ myGroup = MakeGroup();

      // Writing the file requires a TextWriter.
      XmlTextWriter^ writer = gcnew XmlTextWriter( filename,Encoding::UTF8 );
      writer->Formatting = Formatting::Indented;
      writer->WriteStartElement( "wrapper" );

      // Serialize the class, and close the TextWriter.
      mySerializer->Serialize( writer, myGroup );
      writer->WriteEndElement();
      writer->Close();
   }


private:
   Group^ MakeGroup()
   {
      // Create an instance of the class that will be serialized.
      Group^ myGroup = gcnew Group;

      // Set the Object* properties.
      myGroup->GroupName = ".NET";
      array<Byte>^hexByte = {Convert::ToByte( 100 ),Convert::ToByte( 50 )};
      myGroup->GroupNumber = hexByte;
      DateTime myDate = DateTime(2002,5,2);
      myGroup->Today = myDate;
      myGroup->PostitiveInt = "10000";
      myGroup->GroupVehicle = gcnew Vehicle;
      myGroup->GroupVehicle->licenseNumber = "1234";
      return myGroup;
   }

public:
   void DeserializeObject( String^ filename )
   {
      // Create an instance of the XmlSerializer class that
      // can generate encoded SOAP messages.
      XmlSerializer^ mySerializer = ReturnSOAPSerializer();

      // Reading the file requires an  XmlTextReader.
      XmlTextReader^ reader = gcnew XmlTextReader( filename );
      reader->ReadStartElement( "wrapper" );

      // Deserialize and cast the Object*.
      Group^ myGroup;
      myGroup = safe_cast<Group^>(mySerializer->Deserialize( reader ));
      reader->ReadEndElement();
      reader->Close();
   }

private:
   XmlSerializer^ ReturnSOAPSerializer()
   {
      
      // Create an instance of the XmlSerializer class.
      XmlTypeMapping^ myMapping = (gcnew SoapReflectionImporter)->ImportTypeMapping( Group::typeid );
      return gcnew XmlSerializer( myMapping );
   }
};

int main()
{
   Run^ test = gcnew Run;
   test->SerializeObject( "SoapAtts.xml" );
   test->DeserializeObject( "SoapAtts.xml" );
}
//</Snippet1>
