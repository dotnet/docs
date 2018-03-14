

//<Snippet1>
#using <System.Xml.dll>
#using <System.dll>

using namespace System;
using namespace System::IO;
using namespace System::Text;
using namespace System::Xml;
using namespace System::Xml::Serialization;
using namespace System::Xml::Schema;

ref class Vehicle;

[SoapInclude(Vehicle::typeid)]
public ref class Vehicle
{
public:
   String^ licenseNumber;
};


// You must use the SoapIncludeAttribute to inform the XmlSerializer
// that the Vehicle type should be recognized when deserializing.

[SoapInclude(Vehicle::typeid)]
public ref class Group
{
public:
   String^ GroupName;
   Vehicle^ GroupVehicle;
};

public ref class Run
{
public:
   void DeserializeObject( String^ filename )
   {
      // Create an instance of the XmlSerializer class.
      XmlTypeMapping^ myMapping = ((gcnew SoapReflectionImporter)->ImportTypeMapping( Group::typeid ));
      XmlSerializer^ mySerializer = gcnew XmlSerializer( myMapping );
      mySerializer->UnreferencedObject += gcnew UnreferencedObjectEventHandler( this, &Run::Serializer_UnreferencedObject );
      
      // Reading the file requires an  XmlTextReader.
      XmlTextReader^ reader = gcnew XmlTextReader( filename );
      reader->ReadStartElement();
      
      // Deserialize and cast the object.
      Group^ myGroup;
      myGroup = dynamic_cast<Group^>(mySerializer->Deserialize( reader ));
      reader->ReadEndElement();
      reader->Close();
   }

private:
   void Serializer_UnreferencedObject( Object^ /*sender*/, UnreferencedObjectEventArgs^ e )
   {
      Console::WriteLine( "UnreferencedObject:" );
      Console::WriteLine( "ID: {0}", e->UnreferencedId );
      Console::WriteLine( "UnreferencedObject: {0}", e->UnreferencedObject );
      Vehicle^ myVehicle = dynamic_cast<Vehicle^>(e->UnreferencedObject);
      Console::WriteLine( "License: {0}", myVehicle->licenseNumber );
   }
};

int main()
{
   Run^ test = gcnew Run;
   test->DeserializeObject( "UnrefObj.xml" );
}

// The file named S"UnrefObj.xml" should contain this XML:
// <wrapper>
//  <Group xmlns:xsi=S"http://www.w3.org/2001/XMLSchema-instance" 
//xmlns:xsd=S"http://www.w3.org/2001/XMLSchema" id=S"id1" 
//n1:GroupName=S".NET" xmlns:n1=S"http://www.cpandl.com">
//   </Group>
//<Vehicle id=S"id2" n1:type=S"Vehicle" 
//xmlns:n1=S"http://www.w3.org/2001/XMLSchema-instance">
//   <licenseNumber xmlns:q1=S"http://www.w3.org/2001/XMLSchema" 
//n1:type=S"q1:String*">ABCD</licenseNumber>
//   </Vehicle>
//<Vehicle id=S"id3" n1:type=S"Vehicle" 
//xmlns:n1=S"http://www.w3.org/2001/XMLSchema-instance">
//    <licenseNumber xmlns:q1=S"http://www.w3.org/2001/XMLSchema" 
//n1:type=S"q1:String*">1234</licenseNumber>
//  </Vehicle>
//</wrapper>
//</Snippet1>
