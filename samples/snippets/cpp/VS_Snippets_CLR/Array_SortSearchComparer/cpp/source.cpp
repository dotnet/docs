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

generic<typename T> void ShowWhere(array<T>^ arr, int index)
{
    if (index<0)
    {
        // If the index is negative, it represents the bitwise
        // complement of the next larger element in the array.
        //
        index = ~index;

        Console::Write("Not found. Sorts between: ");

        if (index == 0)
            Console::Write("beginning of array and ");
        else
            Console::Write("{0} and ", arr[index-1]);

        if (index == arr->Length)
            Console::WriteLine("end of array.");
        else
            Console::WriteLine("{0}.", arr[index]);
    }
    else
    {
        Console::WriteLine("Found at index {0}.", index);
    }
};

void main()
{
    array<String^>^ dinosaurs = {"Pachycephalosaurus", 
                                 "Amargasaurus", 
                                 "Tyrannosaurus", 
                                 "Mamenchisaurus", 
                                 "Deinonychus", 
                                 "Edmontosaurus"};

    Console::WriteLine();
    for each(String^ dinosaur in dinosaurs)
    {
        Console::WriteLine(dinosaur);
    }

    ReverseComparer^ rc = gcnew ReverseComparer();

    Console::WriteLine("\nSort");
    Array::Sort(dinosaurs, rc);

    Console::WriteLine();
    for each(String^ dinosaur in dinosaurs)
    {
        Console::WriteLine(dinosaur);
    }

    Console::WriteLine("\nBinarySearch for 'Coelophysis':");
    int index = Array::BinarySearch(dinosaurs, "Coelophysis", rc);
    ShowWhere(dinosaurs, index);

    Console::WriteLine("\nBinarySearch for 'Tyrannosaurus':");
    index = Array::BinarySearch(dinosaurs, "Tyrannosaurus", rc);
    ShowWhere(dinosaurs, index);
}

/* This code example produces the following output:

Pachycephalosaurus
Amargasaurus
Tyrannosaurus
Mamenchisaurus
Deinonychus
Edmontosaurus

Sort

Tyrannosaurus
Pachycephalosaurus
Mamenchisaurus
Edmontosaurus
Deinonychus
Amargasaurus

BinarySearch for 'Coelophysis':
Not found. Sorts between: Deinonychus and Amargasaurus.

BinarySearch for 'Tyrannosaurus':
Found at index 0.
 */
// </Snippet1>


