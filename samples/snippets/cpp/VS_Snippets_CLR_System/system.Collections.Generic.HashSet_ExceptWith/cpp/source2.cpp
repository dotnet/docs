//<snippet03>
#using <System.Core.dll>

using namespace System;
using namespace System::Collections::Generic;

ref class SameVehicleComparer : public EqualityComparer<String^>
{
public:
    virtual bool Equals(String^ s1, String^ s2) override
    {
        return s1->Equals(s2, StringComparison::CurrentCultureIgnoreCase);
    }


    virtual int GetHashCode(String^ s) override
    {
        return this->GetHashCode();
    }
};

ref class Program
{
public:
    static void Main()
    {
        SameVehicleComparer^ compareVehicles = gcnew SameVehicleComparer();
        HashSet<String^> ^allVehicles = gcnew HashSet<String^>(compareVehicles);
        List<String^>^ someVehicles = gcnew List<String^>();

        someVehicles->Add("Planes");
        someVehicles->Add("Trains");
        someVehicles->Add("Automobiles");

        // Add in the vehicles contained in the someVehicles list.
        allVehicles->UnionWith(someVehicles);

        Console::WriteLine("The current HashSet contains:\n");
        for each (String^ vehicle in allVehicles)
        {
            Console::WriteLine(vehicle);
        }

        allVehicles->Add("Ships");
        allVehicles->Add("Motorcycles");
        allVehicles->Add("Rockets");
        allVehicles->Add("Helicopters");
        allVehicles->Add("Submarines");

        Console::WriteLine("\nThe updated HashSet contains:\n");
        for each (String^ vehicle in allVehicles)
        {
            Console::WriteLine(vehicle);
        }

        // Verify that the 'All Vehicles' set contains at least the vehicles in
        // the 'Some Vehicles' list.
        if (allVehicles->IsSupersetOf(someVehicles))
        {
            Console::Write("\nThe 'All' vehicles set contains everything in ");
            Console::WriteLine("'Some' vechicles list.");
        }

        // Check for Rockets. Here the SameVehicleComparer will compare
        // true for the mixed-case vehicle type.
        if (allVehicles->Contains("roCKeTs"))
        {
            Console::WriteLine("\nThe 'All' vehicles set contains 'roCKeTs'");
        }

        allVehicles->ExceptWith(someVehicles);
        Console::WriteLine("\nThe excepted HashSet contains:\n");
        for each (String^ vehicle in allVehicles)
        {
            Console::WriteLine(vehicle);
        }

        // Remove all the vehicles that are not 'super cool'.
        allVehicles->RemoveWhere(gcnew Predicate<String^>(&isNotSuperCool));

        Console::WriteLine("\nThe super cool vehicles are:\n");
        for each (String^ vehicle in allVehicles)
        {
            Console::WriteLine(vehicle);
        }
    }

private:
    // Predicate to determine vehicle 'coolness'.
    static bool isNotSuperCool(String^ vehicle)
    {
        bool superCool = (vehicle == "Helicopters") || (vehicle == "Motorcycles");

        return !superCool;
    }
};

int main()
{
    Program::Main();
}

// The program writes the following output to the console::
//
// The current HashSet contains:
//
// Planes
// Trains
// Automobiles
//
// The updated HashSet contains:
//
// Planes
// Trains
// Automobiles
// Ships
// Motorcycles
// Rockets
// Helicopters
// Submarines
//
// The 'All' vehicles set contains everything in 'Some' vechicles list.
//
// The 'All' vehicles set contains 'roCKeTs'
//
// The excepted HashSet contains:
//
// Ships
// Motorcycles
// Rockets
// Helicopters
// Submarines
//
// The super cool vehicles are:
//
// Motorcycles
// Helicopters
//</snippet03>
