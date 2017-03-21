public ref class Transportation
{
public:

   // Sets the Namespace property.

   [XmlArrayItem(Car::typeid,Namespace="http://www.cpandl.com")]
   array<Vehicle^>^MyVehicles;
};