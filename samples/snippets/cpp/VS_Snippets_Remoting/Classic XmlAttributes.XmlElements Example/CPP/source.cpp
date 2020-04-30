

// <Snippet1>
#using <System.Xml.dll>
#using <System.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml::Serialization;
using namespace System::Collections;
using namespace System::Xml;

public ref class Car
{
public:
   String^ Name;
};

public ref class Plane
{
public:
   String^ Name;
};

public ref class Truck
{
public:
   String^ Name;
};

public ref class Train
{
public:
   String^ Name;
};

public ref class Transportation
{
public:

   // Subsequent code overrides these two XmlElementAttributes.

   [XmlElement(Car::typeid),
   XmlElement(Plane::typeid)]
   ArrayList^ Vehicles;
};

// Return an XmlSerializer used for overriding.
XmlSerializer^ CreateOverrider()
{
   // Create the XmlAttributes and XmlAttributeOverrides objects.
   XmlAttributes^ attrs = gcnew XmlAttributes;
   XmlAttributeOverrides^ xOver = gcnew XmlAttributeOverrides;

   /* Create an XmlElementAttribute to override 
      the Vehicles property. */
   XmlElementAttribute^ xElement1 = gcnew XmlElementAttribute( Truck::typeid );

   // Add the XmlElementAttribute to the collection.
   attrs->XmlElements->Add( xElement1 );

   /* Create a second XmlElementAttribute, and 
      add it to the collection. */
   XmlElementAttribute^ xElement2 = gcnew XmlElementAttribute( Train::typeid );
   attrs->XmlElements->Add( xElement2 );

   /* Add the XmlAttributes to the XmlAttributeOverrides,
      specifying the member to override. */
   xOver->Add( Transportation::typeid, "Vehicles", attrs );

   // Create the XmlSerializer, and return it.
   XmlSerializer^ xSer = gcnew XmlSerializer( Transportation::typeid,xOver );
   return xSer;
}

void SerializeObject( String^ filename )
{
   // Create an XmlSerializer instance.
   XmlSerializer^ xSer = CreateOverrider();

   // Create the object and serialize it.
   Transportation^ myTransportation = gcnew Transportation;

   /* Create two new override objects that can be
      inserted into the array. */
   myTransportation->Vehicles = gcnew ArrayList;
   Truck^ myTruck = gcnew Truck;
   myTruck->Name = "MyTruck";
   Train^ myTrain = gcnew Train;
   myTrain->Name = "MyTrain";
   myTransportation->Vehicles->Add( myTruck );
   myTransportation->Vehicles->Add( myTrain );
   TextWriter^ writer = gcnew StreamWriter( filename );
   xSer->Serialize( writer, myTransportation );
}

int main()
{
   SerializeObject( "OverrideElement.xml" );
}
// </Snippet1>
