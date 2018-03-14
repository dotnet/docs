// REDMOND\glennha
// <Snippet1>
using namespace System;
using namespace System::Collections::Generic;

public ref class ReverseComparer: IComparer<String^>
{
public:
    virtual int Compare(String^ x, String^ y)
    {
        // Compare y and x in reverse order.
        return y->CompareTo(x);
    }
};

void main()
{
    array<String^>^ dinosaurs = {
            "Seismosaurus", 
            "Chasmosaurus", 
            "Coelophysis", 
            "Mamenchisaurus", 
            "Caudipteryx", 
            "Cetiosaurus"  };

    array<int>^ dinosaurSizes = { 40, 5, 3, 22, 1, 18 };

    Console::WriteLine();
    for (int i = 0; i < dinosaurs->Length; i++)
    {
        Console::WriteLine("{0}: up to {1} meters long.", 
            dinosaurs[i], dinosaurSizes[i]);
    }

    Console::WriteLine("\nSort(dinosaurs, dinosaurSizes)");
    Array::Sort(dinosaurs, dinosaurSizes);

    Console::WriteLine();
    for (int i = 0; i < dinosaurs->Length; i++)
    {
        Console::WriteLine("{0}: up to {1} meters long.", 
            dinosaurs[i], dinosaurSizes[i]);
    }

    ReverseComparer^ rc = gcnew ReverseComparer();

    Console::WriteLine("\nSort(dinosaurs, dinosaurSizes, rc)");
    Array::Sort(dinosaurs, dinosaurSizes, rc);

    Console::WriteLine();
    for (int i = 0; i < dinosaurs->Length; i++)
    {
        Console::WriteLine("{0}: up to {1} meters long.", 
            dinosaurs[i], dinosaurSizes[i]);
    }

    Console::WriteLine("\nSort(dinosaurs, dinosaurSizes, 3, 3)");
    Array::Sort(dinosaurs, dinosaurSizes, 3, 3);

    Console::WriteLine();
    for (int i = 0; i < dinosaurs->Length; i++)
    {
        Console::WriteLine("{0}: up to {1} meters long.", 
            dinosaurs[i], dinosaurSizes[i]);
    }

    Console::WriteLine("\nSort(dinosaurs, dinosaurSizes, 3, 3, rc)");
    Array::Sort(dinosaurs, dinosaurSizes, 3, 3, rc);

    Console::WriteLine();
    for (int i = 0; i < dinosaurs->Length; i++)
    {
        Console::WriteLine("{0}: up to {1} meters long.", 
            dinosaurs[i], dinosaurSizes[i]);
    }
}

/* This code example produces the following output:

Seismosaurus: up to 40 meters long.
Chasmosaurus: up to 5 meters long.
Coelophysis: up to 3 meters long.
Mamenchisaurus: up to 22 meters long.
Caudipteryx: up to 1 meters long.
Cetiosaurus: up to 18 meters long.

Sort(dinosaurs, dinosaurSizes)

Caudipteryx: up to 1 meters long.
Cetiosaurus: up to 18 meters long.
Chasmosaurus: up to 5 meters long.
Coelophysis: up to 3 meters long.
Mamenchisaurus: up to 22 meters long.
Seismosaurus: up to 40 meters long.

Sort(dinosaurs, dinosaurSizes, rc)

Seismosaurus: up to 40 meters long.
Mamenchisaurus: up to 22 meters long.
Coelophysis: up to 3 meters long.
Chasmosaurus: up to 5 meters long.
Cetiosaurus: up to 18 meters long.
Caudipteryx: up to 1 meters long.

Sort(dinosaurs, dinosaurSizes, 3, 3)

Seismosaurus: up to 40 meters long.
Mamenchisaurus: up to 22 meters long.
Coelophysis: up to 3 meters long.
Caudipteryx: up to 1 meters long.
Cetiosaurus: up to 18 meters long.
Chasmosaurus: up to 5 meters long.

Sort(dinosaurs, dinosaurSizes, 3, 3, rc)

Seismosaurus: up to 40 meters long.
Mamenchisaurus: up to 22 meters long.
Coelophysis: up to 3 meters long.
Chasmosaurus: up to 5 meters long.
Cetiosaurus: up to 18 meters long.
Caudipteryx: up to 1 meters long.
 */
// </Snippet1>


