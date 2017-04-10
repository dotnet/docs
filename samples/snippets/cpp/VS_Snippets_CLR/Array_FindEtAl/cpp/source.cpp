// REDMOND\glennha
// <Snippet1>
using namespace System;

public ref class DinoDiscoverySet
{
public:
    static void Main()
    {
        array<String^>^ dinosaurs =
        {
            "Compsognathus", "Amargasaurus", "Oviraptor",
            "Velociraptor",  "Deinonychus",  "Dilophosaurus",
            "Gallimimus",    "Triceratops"
        };

        DinoDiscoverySet^ GoMesozoic = gcnew DinoDiscoverySet(dinosaurs);

        GoMesozoic->DiscoverAll();
        GoMesozoic->DiscoverByEnding("saurus");
    }

    DinoDiscoverySet(array<String^>^ items)
    {
        dinosaurs = items;
    }

    void DiscoverAll()
    {
        Console::WriteLine();
        for each(String^ dinosaur in dinosaurs)
        {
            Console::WriteLine(dinosaur);
        }
    }

    void DiscoverByEnding(String^ Ending)
    {
        Predicate<String^>^ dinoType;

        if (Ending->ToLower() == "raptor")
        {
            dinoType =
                gcnew Predicate<String^>(&DinoDiscoverySet::EndsWithRaptor);
        }
        else if (Ending->ToLower() == "tops")
        {
            dinoType =
                gcnew Predicate<String^>(&DinoDiscoverySet::EndsWithTops);
        }
        else if (Ending->ToLower() == "saurus")
        {
            dinoType =
                gcnew Predicate<String^>(&DinoDiscoverySet::EndsWithSaurus);
        }
        else
        {
            dinoType =
                gcnew Predicate<String^>(&DinoDiscoverySet::EndsWithSaurus);
        }

        Console::WriteLine(
            "\nArray::Exists(dinosaurs, \"{0}\"): {1}",
            Ending,
            Array::Exists(dinosaurs, dinoType));

        Console::WriteLine(
            "\nArray::TrueForAll(dinosaurs, \"{0}\"): {1}",
            Ending,
            Array::TrueForAll(dinosaurs, dinoType));

        Console::WriteLine(
            "\nArray::Find(dinosaurs, \"{0}\"): {1}",
            Ending,
            Array::Find(dinosaurs, dinoType));

        Console::WriteLine(
            "\nArray::FindLast(dinosaurs, \"{0}\"): {1}",
            Ending,
            Array::FindLast(dinosaurs, dinoType));

        Console::WriteLine(
            "\nArray::FindAll(dinosaurs, \"{0}\"):", Ending);

        array<String^>^ subArray =
            Array::FindAll(dinosaurs, dinoType);

        for each(String^ dinosaur in subArray)
        {
            Console::WriteLine(dinosaur);
        }
    }

private:
    array<String^>^ dinosaurs;

    // Search predicate returns true if a string ends in "saurus".
    static bool EndsWithSaurus(String^ s)
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
    }

    // Search predicate returns true if a string ends in "raptor".
    static bool EndsWithRaptor(String^ s)
    {
        if ((s->Length > 5) &&
            (s->Substring(s->Length - 6)->ToLower() == "raptor"))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    // Search predicate returns true if a string ends in "tops".
    static bool EndsWithTops(String^ s)
    {
        if ((s->Length > 3) &&
            (s->Substring(s->Length - 4)->ToLower() == "tops"))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
};

int main()
{
    DinoDiscoverySet::Main();
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

Array.Exists(dinosaurs, "saurus"): True

Array.TrueForAll(dinosaurs, "saurus"): False

Array.Find(dinosaurs, "saurus"): Amargasaurus

Array.FindLast(dinosaurs, "saurus"): Dilophosaurus

Array.FindAll(dinosaurs, "saurus"):
Amargasaurus
Dilophosaurus
*/
// </Snippet1>


