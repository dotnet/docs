

#using <System.Xml.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
using namespace System::Xml::Schema;
using namespace System::Xml::Serialization;

// <Snippet1>
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

   // Specifies the Form property value.

   [XmlArray("Vehicles")]
   [XmlArrayItem(Vehicle::typeid,
   Form=XmlSchemaForm::Unqualified),
   XmlArrayItem(Car::typeid,
   Form=XmlSchemaForm::Qualified)]
   array<Vehicle^>^MyVehicles;
};
// </Snippet1>
