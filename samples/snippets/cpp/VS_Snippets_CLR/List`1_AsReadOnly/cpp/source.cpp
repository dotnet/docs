// REDMOND\glennha
// <Snippet1>
using namespace System;
using namespace System::Collections::Generic;

void main()
{
    List<String^>^ dinosaurs = gcnew List<String^>(4);

    Console::WriteLine("\nCapacity: {0}", dinosaurs->Capacity);

    dinosaurs->Add("Tyrannosaurus");
    dinosaurs->Add("Amargasaurus");
    dinosaurs->Add("Mamenchisaurus");
    dinosaurs->Add("Deinonychus");

    Console::WriteLine();
    for each(String^ dinosaur in dinosaurs)
    {
        Console::WriteLine(dinosaur);
    }

    Console::WriteLine("\nIList<String^>^ roDinosaurs = dinosaurs->AsReadOnly()");
    IList<String^>^ roDinosaurs = dinosaurs->AsReadOnly();

    Console::WriteLine("\nElements in the read-only IList:");
    for each(String^ dinosaur in roDinosaurs)
    {
        Console::WriteLine(dinosaur);
    }

    Console::WriteLine("\ndinosaurs[2] = \"Coelophysis\"");
    dinosaurs[2] = "Coelophysis";

    Console::WriteLine("\nElements in the read-only IList:");
    for each(String^ dinosaur in roDinosaurs)
    {
        Console::WriteLine(dinosaur);
    }
}

/* This code example produces the following output:

Capacity: 4

Tyrannosaurus
Amargasaurus
Mamenchisaurus
Deinonychus

IList<String^>^ roDinosaurs = dinosaurs->AsReadOnly()

Elements in the read-only IList:
Tyrannosaurus
Amargasaurus
Mamenchisaurus
Deinonychus

dinosaurs[2] = "Coelophysis"

Elements in the read-only IList:
Tyrannosaurus
Amargasaurus
Coelophysis
Deinonychus
 */
// </Snippet1>


