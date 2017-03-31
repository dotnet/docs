// REDMOND\glennha
// <Snippet1>
using namespace System;
using namespace System::Collections::Generic;

// Search predicate returns true if a string ends in "saurus".
bool EndsWithSaurus(String^ s)
{
    return s->ToLower()->EndsWith("saurus");
};

void main()
{
    List<String^>^ dinosaurs = gcnew List<String^>();

    dinosaurs->Add("Compsognathus");
    dinosaurs->Add("Amargasaurus");
    dinosaurs->Add("Oviraptor");
    dinosaurs->Add("Velociraptor");
    dinosaurs->Add("Deinonychus");
    dinosaurs->Add("Dilophosaurus");
    dinosaurs->Add("Gallimimus");
    dinosaurs->Add("Triceratops");

    Console::WriteLine();
    for each(String^ dinosaur in dinosaurs )
    {
        Console::WriteLine(dinosaur);
    }

    Console::WriteLine("\nTrueForAll(EndsWithSaurus): {0}",
        dinosaurs->TrueForAll(gcnew Predicate<String^>(EndsWithSaurus)));

    Console::WriteLine("\nFind(EndsWithSaurus): {0}", 
        dinosaurs->Find(gcnew Predicate<String^>(EndsWithSaurus)));

    Console::WriteLine("\nFindLast(EndsWithSaurus): {0}",
        dinosaurs->FindLast(gcnew Predicate<String^>(EndsWithSaurus)));

    Console::WriteLine("\nFindAll(EndsWithSaurus):");
    List<String^>^ sublist = 
        dinosaurs->FindAll(gcnew Predicate<String^>(EndsWithSaurus));

    for each(String^ dinosaur in sublist)
    {
        Console::WriteLine(dinosaur);
    }

    Console::WriteLine(
        "\n{0} elements removed by RemoveAll(EndsWithSaurus).", 
        dinosaurs->RemoveAll(gcnew Predicate<String^>(EndsWithSaurus)));

    Console::WriteLine("\nList now contains:");
    for each(String^ dinosaur in dinosaurs)
    {
        Console::WriteLine(dinosaur);
    }

    Console::WriteLine("\nExists(EndsWithSaurus): {0}", 
        dinosaurs->Exists(gcnew Predicate<String^>(EndsWithSaurus)));
}

/* This code example produces the following output:

Compsognathus
Amargasaurus
Oviraptor
Velociraptor
Deinonychus
Dilophosaurus
Gallimimus
Triceratops

TrueForAll(EndsWithSaurus): False

Find(EndsWithSaurus): Amargasaurus

FindLast(EndsWithSaurus): Dilophosaurus

FindAll(EndsWithSaurus):
Amargasaurus
Dilophosaurus

2 elements removed by RemoveAll(EndsWithSaurus).

List now contains:
Compsognathus
Oviraptor
Velociraptor
Deinonychus
Gallimimus
Triceratops

Exists(EndsWithSaurus): False
 */
// </Snippet1>


