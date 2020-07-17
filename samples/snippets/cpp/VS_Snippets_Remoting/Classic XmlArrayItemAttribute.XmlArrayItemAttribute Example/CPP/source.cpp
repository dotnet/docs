

// <Snippet1>
#using <System.Xml.dll>
#using <System.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
using namespace System::Xml::Serialization;

public ref class Vehicle
{
public:
   String^ id;
};

public ref class Car: public Vehicle
{
public:
   String^ Maker;
};

public ref class Transportation
{
public:

   [XmlArrayItem,
   XmlArrayItem(Car::typeid,ElementName="Automobile")]
   array<Vehicle^>^MyVehicles;
};

void SerializeObject( String^ filename )
{
   // Creates an XmlSerializer for the Transportation class. 
   XmlSerializer^ MySerializer = gcnew XmlSerializer( Transportation::typeid );

   // Writing the XML file to disk requires a TextWriter.
   TextWriter^ myTextWriter = gcnew StreamWriter( filename );

   // Creates the object to serialize.
   Transportation^ myTransportation = gcnew Transportation;

   // Creates objects to add to the array.
   Vehicle^ myVehicle = gcnew Vehicle;
   myVehicle->id = "A12345";
   Car^ myCar = gcnew Car;
   myCar->id = "Car 34";
   myCar->Maker = "FamousCarMaker";
   array<Vehicle^>^temp = {myVehicle,myCar};
   myTransportation->MyVehicles = temp;

   // Serializes the object, and closes the StreamWriter.
   MySerializer->Serialize( myTextWriter, myTransportation );
   myTextWriter->Close();
}

void DeserializeObject( String^ filename )
{
   // Creates an XmlSerializer instance.
   XmlSerializer^ mySerializer = gcnew XmlSerializer( Transportation::typeid );
   FileStream^ myFileStream = gcnew FileStream( filename,FileMode::Open );
   Transportation^ myTransportation = dynamic_cast<Transportation^>(mySerializer->Deserialize( myFileStream ));
   for ( int i = 0; i < myTransportation->MyVehicles->Length; i++ )
   {
      Console::WriteLine( myTransportation->MyVehicles[ i ]->id );
   }
}

int main()
{
   SerializeObject( "XmlArrayItem1.xml" );
   DeserializeObject( "XmlArrayItem1.xml" );
}
// </Snippet1>
