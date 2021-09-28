

#using <System.Xml.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
using namespace System::Xml::Serialization;
public ref class Vehicle{};

public ref class Car: public Vehicle{};

// <Snippet1>
public ref class Transportation
{
public:

   // Sets the Namespace property.

   [XmlArrayItem(Car::typeid,Namespace="http://www.cpandl.com")]
   array<Vehicle^>^MyVehicles;
};
// </Snippet1>
