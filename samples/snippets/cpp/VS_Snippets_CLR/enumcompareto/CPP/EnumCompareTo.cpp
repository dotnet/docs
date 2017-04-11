
//<snippet1>
using namespace System;

public enum class VehicleDoors
{
   Motorbike = 0,
   Sportscar = 2,
   Sedan = 4,
   Hatchback = 5
};

int main()
{
   VehicleDoors myVeh = VehicleDoors::Sportscar;
   VehicleDoors yourVeh = VehicleDoors::Motorbike;
   VehicleDoors otherVeh = VehicleDoors::Sedan;
   Console::WriteLine(  "Does a {0} have more doors than a {1}?", myVeh, yourVeh );
   Int32 iRes = myVeh.CompareTo( yourVeh );
   Console::WriteLine(  "{0}{1}", iRes > 0 ? (String^)"Yes" : "No", Environment::NewLine );
   Console::WriteLine(  "Does a {0} have more doors than a {1}?", myVeh, otherVeh );
   iRes = myVeh.CompareTo( otherVeh );
   Console::WriteLine(  "{0}", iRes > 0 ? (String^)"Yes" : "No" );
}
// The example displays the following output:
//       Does a Sportscar have more doors than a Motorbike?
//       Yes
//       
//       Does a Sportscar have more doors than a Sedan?
//       No
//</snippet1>
