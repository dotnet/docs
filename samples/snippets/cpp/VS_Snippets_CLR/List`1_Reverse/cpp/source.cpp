// REDMOND\glennha
// <Snippet1>
using namespace System;
using namespace System::Collections::Generic;

void main()
{
    List<String^>^ dinosaurs = gcnew List<String^>();

    dinosaurs->Add("Pachycephalosaurus");
    dinosaurs->Add("Parasauralophus");
    dinosaurs->Add("Mamenchisaurus");
    dinosaurs->Add("Amargasaurus");
    dinosaurs->Add("Coelophysis");
    dinosaurs->Add("Oviraptor");

    Console::WriteLine();
    for each(String^ dinosaur in dinosaurs)
    {
        Console::WriteLine(dinosaur);
    }

    dinosaurs->Reverse();

    Console::WriteLine();
    for each(String^ dinosaur in dinosaurs)
    {
        Console::WriteLine(dinosaur);
    }

    dinosaurs->Reverse(1, 4);

    Console::WriteLine();
    for each(String^ dinosaur in dinosaurs)
    {
        Console::WriteLine(dinosaur);
    }
}

/* This code example produces the following output:

Pachycephalosaurus
Parasauralophus
Mamenchisaurus
Amargasaurus
Coelophysis
Oviraptor

Oviraptor
Coelophysis
Amargasaurus
Mamenchisaurus
Parasauralophus
Pachycephalosaurus

Oviraptor
Parasauralophus
Mamenchisaurus
Amargasaurus
Coelophysis
Pachycephalosaurus
 */
// </Snippet1>


