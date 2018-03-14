// REDMOND\glennha
// <Snippet1>
using namespace System;
using namespace System::Collections::Generic;

void main()
{
    List<String^>^ dinosaurs = gcnew List<String^>();

    dinosaurs->Add("Pachycephalosaurus");
    dinosaurs->Add("Amargasaurus");
    dinosaurs->Add("Mamenchisaurus");
    dinosaurs->Add("Deinonychus");

    Console::WriteLine();
    for each(String^ dinosaur in dinosaurs)
    {
        Console::WriteLine(dinosaur);
    }

    Console::WriteLine("\nSort");
    dinosaurs->Sort();

    Console::WriteLine();
    for each(String^ dinosaur in dinosaurs)
    {
        Console::WriteLine(dinosaur);
    }

    Console::WriteLine("\nBinarySearch and Insert \"Coelophysis\":");
    int index = dinosaurs->BinarySearch("Coelophysis");
    if (index < 0)
    {
        dinosaurs->Insert(~index, "Coelophysis");
    }

    Console::WriteLine();
    for each(String^ dinosaur in dinosaurs)
    {
        Console::WriteLine(dinosaur);
    }

    Console::WriteLine("\nBinarySearch and Insert \"Tyrannosaurus\":");
    index = dinosaurs->BinarySearch("Tyrannosaurus");
    if (index < 0)
    {
        dinosaurs->Insert(~index, "Tyrannosaurus");
    }

    Console::WriteLine();
    for each(String^ dinosaur in dinosaurs)
    {
        Console::WriteLine(dinosaur);
    }
}

/* This code example produces the following output:

Pachycephalosaurus
Amargasaurus
Mamenchisaurus
Deinonychus

Sort

Amargasaurus
Deinonychus
Mamenchisaurus
Pachycephalosaurus

BinarySearch and Insert "Coelophysis":

Amargasaurus
Coelophysis
Deinonychus
Mamenchisaurus
Pachycephalosaurus

BinarySearch and Insert "Tyrannosaurus":

Amargasaurus
Coelophysis
Deinonychus
Mamenchisaurus
Pachycephalosaurus
Tyrannosaurus
 */
// </Snippet1>


