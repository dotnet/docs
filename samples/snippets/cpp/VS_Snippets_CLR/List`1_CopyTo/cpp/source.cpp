// REDMOND\glennha
// <Snippet1>
using namespace System;
using namespace System::Collections::Generic;

void main()
{
    List<String^>^ dinosaurs = gcnew List<String^>();

    dinosaurs->Add("Tyrannosaurus");
    dinosaurs->Add("Amargasaurus");
    dinosaurs->Add("Mamenchisaurus");
    dinosaurs->Add("Brachiosaurus");
    dinosaurs->Add("Compsognathus");

    Console::WriteLine();
    for each(String^ dinosaurs in dinosaurs )
    {
        Console::WriteLine(dinosaurs);
    }

    // Create an array of 15 strings.
    array<String^>^ arr = gcnew array<String^>(15);

    dinosaurs->CopyTo(arr);
    dinosaurs->CopyTo(arr, 6);
    dinosaurs->CopyTo(2, arr, 12, 3);

    Console::WriteLine("\nContents of the array:");
    for each(String^ dinosaurs in arr )
    {
        Console::WriteLine(dinosaurs);
    }
}

/* This code example produces the following output:

Tyrannosaurus
Amargasaurus
Mamenchisaurus
Brachiosaurus
Deinonychus
Tyrannosaurus
Compsognathus

IndexOf("Tyrannosaurus"): 0

IndexOf("Tyrannosaurus", 3): 5

IndexOf("Tyrannosaurus", 2, 2): -1
 */
// </Snippet1>


