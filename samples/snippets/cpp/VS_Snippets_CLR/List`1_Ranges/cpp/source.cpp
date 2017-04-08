// REDMOND\glennha
// <Snippet1>
using namespace System;
using namespace System::Collections::Generic;

void main()
{
    array<String^>^ input = { "Brachiosaurus", 
                              "Amargasaurus", 
                              "Mamenchisaurus" };

    List<String^>^ dinosaurs = 
        gcnew List<String^>((IEnumerable<String^>^) input);

    Console::WriteLine("\nCapacity: {0}", dinosaurs->Capacity);

    Console::WriteLine();
    for each(String^ dinosaur in dinosaurs )
    {
        Console::WriteLine(dinosaur);
    }

    Console::WriteLine("\nAddRange(dinosaurs)");
    dinosaurs->AddRange(dinosaurs);

    Console::WriteLine();
    for each(String^ dinosaur in dinosaurs )
    {
        Console::WriteLine(dinosaur);
    }

    Console::WriteLine("\nRemoveRange(2, 2)");
    dinosaurs->RemoveRange(2, 2);

    Console::WriteLine();
    for each(String^ dinosaur in dinosaurs )
    {
        Console::WriteLine(dinosaur);
    }

    input = gcnew array<String^> { "Tyrannosaurus", 
                                   "Deinonychus", 
                                   "Velociraptor"};

    Console::WriteLine("\nInsertRange(3, (IEnumerable<String^>^) input)");
    dinosaurs->InsertRange(3, (IEnumerable<String^>^) input);

    Console::WriteLine();
    for each(String^ dinosaur in dinosaurs )
    {
        Console::WriteLine(dinosaur);
    }

    Console::WriteLine("\noutput = dinosaurs->GetRange(2, 3)->ToArray()");
    array<String^>^ output = dinosaurs->GetRange(2, 3)->ToArray();
        
    Console::WriteLine();
    for each(String^ dinosaur in output )
    {
        Console::WriteLine(dinosaur);
    }
}

/* This code example produces the following output:

Capacity: 3

Brachiosaurus
Amargasaurus
Mamenchisaurus

AddRange(dinosaurs)

Brachiosaurus
Amargasaurus
Mamenchisaurus
Brachiosaurus
Amargasaurus
Mamenchisaurus

RemoveRange(2, 2)

Brachiosaurus
Amargasaurus
Amargasaurus
Mamenchisaurus

InsertRange(3, (IEnumerable<String^>^) input)

Brachiosaurus
Amargasaurus
Amargasaurus
Tyrannosaurus
Deinonychus
Velociraptor
Mamenchisaurus

output = dinosaurs->GetRange(2, 3)->ToArray()

Amargasaurus
Tyrannosaurus
Deinonychus
 */
// </Snippet1>


