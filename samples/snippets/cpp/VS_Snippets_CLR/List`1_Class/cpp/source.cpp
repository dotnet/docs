// REDMOND\glennha
// <Snippet1>
using namespace System;
using namespace System::Collections::Generic;

void main()
{
    List<String^>^ dinosaurs = gcnew List<String^>();

    Console::WriteLine("\nCapacity: {0}", dinosaurs->Capacity);

    dinosaurs->Add("Tyrannosaurus");
    dinosaurs->Add("Amargasaurus");
    dinosaurs->Add("Mamenchisaurus");
    dinosaurs->Add("Deinonychus");
    dinosaurs->Add("Compsognathus");

    Console::WriteLine();
    for each(String^ dinosaur in dinosaurs )
    {
        Console::WriteLine(dinosaur);
    }

    Console::WriteLine("\nCapacity: {0}", dinosaurs->Capacity);
    Console::WriteLine("Count: {0}", dinosaurs->Count);

    Console::WriteLine("\nContains(\"Deinonychus\"): {0}",
        dinosaurs->Contains("Deinonychus"));

    Console::WriteLine("\nInsert(2, \"Compsognathus\")");
    dinosaurs->Insert(2, "Compsognathus");

    Console::WriteLine();
    for each(String^ dinosaur in dinosaurs )
    {
        Console::WriteLine(dinosaur);
    }

    Console::WriteLine("\ndinosaurs[3]: {0}", dinosaurs[3]);

    Console::WriteLine("\nRemove(\"Compsognathus\")");
    dinosaurs->Remove("Compsognathus");

    Console::WriteLine();
    for each(String^ dinosaur in dinosaurs )
    {
        Console::WriteLine(dinosaur);
    }

    dinosaurs->TrimExcess();
    Console::WriteLine("\nTrimExcess()");
    Console::WriteLine("Capacity: {0}", dinosaurs->Capacity);
    Console::WriteLine("Count: {0}", dinosaurs->Count);

    dinosaurs->Clear();
    Console::WriteLine("\nClear()");
    Console::WriteLine("Capacity: {0}", dinosaurs->Capacity);
    Console::WriteLine("Count: {0}", dinosaurs->Count);
}

/* This code example produces the following output:

Capacity: 0

Tyrannosaurus
Amargasaurus
Mamenchisaurus
Deinonychus
Compsognathus

Capacity: 8
Count: 5

Contains("Deinonychus"): True

Insert(2, "Compsognathus")

Tyrannosaurus
Amargasaurus
Compsognathus
Mamenchisaurus
Deinonychus
Compsognathus

dinosaurs[3]: Mamenchisaurus

Remove("Compsognathus")

Tyrannosaurus
Amargasaurus
Mamenchisaurus
Deinonychus
Compsognathus

TrimExcess()
Capacity: 5
Count: 5

Clear()
Capacity: 5
Count: 0
 */
// </Snippet1>


