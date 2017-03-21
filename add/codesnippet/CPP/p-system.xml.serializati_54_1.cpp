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