// REDMOND\glennha
// <Snippet1>
using namespace System;

void main()
{
    array<String^>^ dinosaurs = { "Tyrannosaurus", 
        "Amargasaurus",
        "Mamenchisaurus",
        "Brachiosaurus",
        "Deinonychus",
        "Tyrannosaurus",
        "Compsognathus" };

    Console::WriteLine();
    for each(String^ dinosaur in dinosaurs )
    {
        Console::WriteLine(dinosaur);
    }

    Console::WriteLine("\nArray.IndexOf(dinosaurs, \"Tyrannosaurus\"): {0}", 
        Array::IndexOf(dinosaurs, "Tyrannosaurus"));

    Console::WriteLine("\nArray.IndexOf(dinosaurs, \"Tyrannosaurus\", 3): {0}", 
        Array::IndexOf(dinosaurs, "Tyrannosaurus", 3));

    Console::WriteLine("\nArray.IndexOf(dinosaurs, \"Tyrannosaurus\", 2, 2): {0}", 
        Array::IndexOf(dinosaurs, "Tyrannosaurus", 2, 2));
}

/* This code example produces the following output:

Tyrannosaurus
Amargasaurus
Mamenchisaurus
Brachiosaurus
Deinonychus
Tyrannosaurus
Compsognathus

Array.IndexOf(dinosaurs, "Tyrannosaurus"): 0

Array.IndexOf(dinosaurs, "Tyrannosaurus", 3): 5

Array.IndexOf(dinosaurs, "Tyrannosaurus", 2, 2): -1
 */
// </Snippet1>


