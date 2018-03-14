// REDMOND\glennha
// <Snippet1>
using namespace System;
using namespace System::Collections::Generic;
using namespace System::Collections::ObjectModel;

void main()
{
    List<String^>^ dinosaurs = gcnew List<String^>();

    dinosaurs->Add("Tyrannosaurus");
    dinosaurs->Add("Amargasaurus");
    dinosaurs->Add("Deinonychus");
    dinosaurs->Add("Compsognathus");

    ReadOnlyCollection<String^>^ readOnlyDinosaurs = 
        gcnew ReadOnlyCollection<String^>(dinosaurs);

    Console::WriteLine();
    for each(String^ dinosaur in readOnlyDinosaurs )
    {
        Console::WriteLine(dinosaur);
    }

    Console::WriteLine("\nCount: {0}", readOnlyDinosaurs->Count);

    Console::WriteLine("\nContains(\"Deinonychus\"): {0}", 
        readOnlyDinosaurs->Contains("Deinonychus"));

    Console::WriteLine("\nreadOnlyDinosaurs[3]: {0}", 
        readOnlyDinosaurs[3]);

    Console::WriteLine("\nIndexOf(\"Compsognathus\"): {0}", 
        readOnlyDinosaurs->IndexOf("Compsognathus"));

    Console::WriteLine("\nInsert into the wrapped List:");
    Console::WriteLine("Insert(2, \"Oviraptor\")");
    dinosaurs->Insert(2, "Oviraptor");

    Console::WriteLine();
    for each( String^ dinosaur in readOnlyDinosaurs )
    {
        Console::WriteLine(dinosaur);
    }

    array<String^>^ dinoArray = 
        gcnew array<String^>(readOnlyDinosaurs->Count + 2);
    readOnlyDinosaurs->CopyTo(dinoArray, 1);

    Console::WriteLine("\nCopied array has {0} elements:", 
        dinoArray->Length);
    for each( String^ dinosaur in dinoArray )
    {
        Console::WriteLine("\"{0}\"", dinosaur);
    }
}

/* This code example produces the following output:

Tyrannosaurus
Amargasaurus
Deinonychus
Compsognathus

Count: 4

Contains("Deinonychus"): True

readOnlyDinosaurs[3]: Compsognathus

IndexOf("Compsognathus"): 3

Insert into the wrapped List:
Insert(2, "Oviraptor")

Tyrannosaurus
Amargasaurus
Oviraptor
Deinonychus
Compsognathus

Copied array has 7 elements:
""
"Tyrannosaurus"
"Amargasaurus"
"Oviraptor"
"Deinonychus"
"Compsognathus"
""
 */
// </Snippet1>


