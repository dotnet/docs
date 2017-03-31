// REDMOND\glennha
// <Snippet1>
using namespace System;
using namespace System::Collections::Generic;

public ref class ReverseComparer: IComparer<String^>
{
public:
    virtual int Compare(String^ x, String^ y)
    {
        // Compare y and x in reverse order.
        return y->CompareTo(x);
    }
};

void main()
{
    array<String^>^ dinosaurs = {"Pachycephalosaurus", 
                                 "Amargasaurus", 
                                 "Mamenchisaurus",
                                 "Tarbosaurus",
                                 "Tyrannosaurus", 
                                 "Albertasaurus"};

    Console::WriteLine();
    for each(String^ dinosaur in dinosaurs)
    {
        Console::WriteLine(dinosaur);
    }

    Console::WriteLine("\nSort(dinosaurs, 3, 3)");
    Array::Sort(dinosaurs, 3, 3);

    Console::WriteLine();
    for each(String^ dinosaur in dinosaurs)
    {
        Console::WriteLine(dinosaur);
    }

    ReverseComparer^ rc = gcnew ReverseComparer();

    Console::WriteLine("\nSort(dinosaurs, 3, 3, rc)");
    Array::Sort(dinosaurs, 3, 3, rc);

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
Tarbosaurus
Tyrannosaurus
Albertasaurus

Sort(dinosaurs, 3, 3)

Pachycephalosaurus
Amargasaurus
Mamenchisaurus
Albertasaurus
Tarbosaurus
Tyrannosaurus

Sort(dinosaurs, 3, 3, rc)

Pachycephalosaurus
Amargasaurus
Mamenchisaurus
Tyrannosaurus
Tarbosaurus
Albertasaurus
 */
// </Snippet1>


