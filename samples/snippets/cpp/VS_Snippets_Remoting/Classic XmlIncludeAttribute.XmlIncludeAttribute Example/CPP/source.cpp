

#using <System.EnterpriseServices.dll>
#using <System.Xml.dll>
#using <System.Web.Services.dll>

using namespace System;
using namespace System::Web::Services;
using namespace System::Xml;
using namespace System::Xml::Serialization;

// <Snippet1>
public ref class Vehicle{};

public ref class Car: public Vehicle{};

public ref class Truck: public Vehicle{};

public ref class Sample
{
public:

   [WebMethodAttribute]
   [XmlInclude(Car::typeid)]
   [XmlInclude(Truck::typeid)]
   Vehicle^ ReturnVehicle( int i )
   {
      if ( i == 0 )
            return gcnew Car;
      else
            return gcnew Truck;
   }
};
// </Snippet1>
