// REDMOND\glennha
//<Snippet1>
using namespace System;
using namespace System::Collections::Generic;
using namespace System::Collections::ObjectModel;

public ref class Demo
{
public:
    static void Main()
    {
        Collection<String^>^ dinosaurs = gcnew Collection<String^>();

        dinosaurs->Add("Psitticosaurus");
        dinosaurs->Add("Caudipteryx");
        dinosaurs->Add("Compsognathus");
        dinosaurs->Add("Muttaburrasaurus");

        Console::WriteLine("{0} dinosaurs:", dinosaurs->Count);
        Display(dinosaurs);

        Console::WriteLine("\nIndexOf(\"Muttaburrasaurus\"): {0}",
            dinosaurs->IndexOf("Muttaburrasaurus"));

        Console::WriteLine("\nContains(\"Caudipteryx\"): {0}",
            dinosaurs->Contains("Caudipteryx"));

        Console::WriteLine("\nInsert(2, \"Nanotyrannus\")");
        dinosaurs->Insert(2, "Nanotyrannus");
        Display(dinosaurs);

        Console::WriteLine("\ndinosaurs[2]: {0}", dinosaurs[2]);

        Console::WriteLine("\ndinosaurs[2] = \"Microraptor\"");
        dinosaurs[2] = "Microraptor";
        Display(dinosaurs);

        Console::WriteLine("\nRemove(\"Microraptor\")");
        dinosaurs->Remove("Microraptor");
        Display(dinosaurs);

        Console::WriteLine("\nRemoveAt(0)");
        dinosaurs->RemoveAt(0);
        Display(dinosaurs);

        Console::WriteLine("\ndinosaurs.Clear()");
        dinosaurs->Clear();
        Console::WriteLine("Count: {0}", dinosaurs->Count);
    }

private:
    static void Display(Collection<String^>^ cs)
    {
        Console::WriteLine();
        for each( String^ item in cs )
        {
            Console::WriteLine(item);
        }
    }
};

int main()
{
    Demo::Main();
}

/* This code example produces the following output:

4 dinosaurs:

Psitticosaurus
Caudipteryx
Compsognathus
Muttaburrasaurus

IndexOf("Muttaburrasaurus"): 3

Contains("Caudipteryx"): True

Insert(2, "Nanotyrannus")

Psitticosaurus
Caudipteryx
Nanotyrannus
Compsognathus
Muttaburrasaurus

dinosaurs[2]: Nanotyrannus

dinosaurs[2] = "Microraptor"

Psitticosaurus
Caudipteryx
Microraptor
Compsognathus
Muttaburrasaurus

Remove("Microraptor")

Psitticosaurus
Caudipteryx
Compsognathus
Muttaburrasaurus

RemoveAt(0)

Caudipteryx
Compsognathus
Muttaburrasaurus

dinosaurs.Clear()
Count: 0
 */
//</Snippet1>


