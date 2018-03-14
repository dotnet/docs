// REDMOND\glennha
// <Snippet1>
using namespace System;
using namespace System::Collections::Generic;

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

    Console::WriteLine("\nSort");
    Array::Sort(dinosaurs);

    Console::WriteLine();
    for each(String^ dinosaur in dinosaurs)
    {
        Console::WriteLine(dinosaur);
    }

    Console::WriteLine("\nBinarySearch for 'Coelophysis':");
    int index = Array::BinarySearch(dinosaurs, "Coelophysis");
    ShowWhere(dinosaurs, index);

    Console::WriteLine("\nBinarySearch for 'Tyrannosaurus':");
    index = Array::BinarySearch(dinosaurs, "Tyrannosaurus");
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

Amargasaurus
Deinonychus
Edmontosaurus
Mamenchisaurus
Pachycephalosaurus
Tyrannosaurus

BinarySearch for 'Coelophysis':
Not found. Sorts between: Amargasaurus and Deinonychus.

BinarySearch for 'Tyrannosaurus':
Found at index 5.
 */
// </Snippet1>


