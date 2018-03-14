// REDMOND\glennha
// <Snippet1>
using namespace System;

// Search predicate returns true if a string ends in "saurus".
bool EndsWithSaurus(String^ s)
{
    if ((s->Length > 5) && 
        (s->Substring(s->Length - 6)->ToLower() == "saurus"))
    {
        return true;
    }
    else
    {
        return false;
    }
};

void main()
{
    array<String^>^ dinosaurs = { "Compsognathus", 
        "Amargasaurus",   "Oviraptor",      "Velociraptor", 
        "Deinonychus",    "Dilophosaurus",  "Gallimimus", 
        "Triceratops" };

    Console::WriteLine();
    for each(String^ dinosaur in dinosaurs )
    {
        Console::WriteLine(dinosaur);
    }

    Console::WriteLine("\nArray::FindLastIndex(dinosaurs, EndsWithSaurus): {0}", 
        Array::FindLastIndex(dinosaurs, gcnew Predicate<String^>(EndsWithSaurus)));

    Console::WriteLine("\nArray::FindLastIndex(dinosaurs, 4, EndsWithSaurus): {0}",
        Array::FindLastIndex(dinosaurs, 4, gcnew Predicate<String^>(EndsWithSaurus)));

    Console::WriteLine("\nArray::FindLastIndex(dinosaurs, 4, 3, EndsWithSaurus): {0}",
        Array::FindLastIndex(dinosaurs, 4, 3, gcnew Predicate<String^>(EndsWithSaurus)));
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

Array::FindLastIndex(dinosaurs, EndsWithSaurus): 5

Array::FindLastIndex(dinosaurs, 4, EndsWithSaurus): 1

Array::FindLastIndex(dinosaurs, 4, 3, EndsWithSaurus): -1
 */
// </Snippet1>


