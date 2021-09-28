

#using <System.Xml.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
using namespace System::Xml::Serialization;

// <Snippet1>
// By default, this class results in XML elements named "Vehicle". 
public ref class Vehicle
{
public:
   String^ id;
};

// By default, this class results in XML elements named "Car". 
public ref class Car: public Vehicle
{
public:
   String^ Maker;
};

public ref class Transportation
{
public:

   /* Specifies acceptable types and the ElementName generated 
         for each object type. */

   [XmlArray("Vehicles")]
   [XmlArrayItem(Vehicle::typeid,ElementName="Transport"),
   XmlArrayItem(Car::typeid,ElementName="Automobile")]
   array<Vehicle^>^MyVehicles;
};
// </Snippet1>
