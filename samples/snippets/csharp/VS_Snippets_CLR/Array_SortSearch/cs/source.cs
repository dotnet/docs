// REDMOND\glennha
// <Snippet1>
using System;
using System.Collections.Generic;

public class Example
{
    public static void Main()
    {
        string[] dinosaurs = {"Pachycephalosaurus", 
                              "Amargasaurus", 
                              "Tyrannosaurus", 
                              "Mamenchisaurus", 
                              "Deinonychus", 
                              "Edmontosaurus"};

        Console.WriteLine();
        foreach( string dinosaur in dinosaurs )
        {
            Console.WriteLine(dinosaur);
        }

        Console.WriteLine("\nSort");
        Array.Sort(dinosaurs);

        Console.WriteLine();
        foreach( string dinosaur in dinosaurs )
        {
            Console.WriteLine(dinosaur);
        }

        Console.WriteLine("\nBinarySearch for 'Coelophysis':");
        int index = Array.BinarySearch(dinosaurs, "Coelophysis");
        ShowWhere(dinosaurs, index);

        Console.WriteLine("\nBinarySearch for 'Tyrannosaurus':");
        index = Array.BinarySearch(dinosaurs, "Tyrannosaurus");
        ShowWhere(dinosaurs, index);
    }

    private static void ShowWhere<T>(T[] array, int index)
    {
        if (index<0)
        {
            // If the index is negative, it represents the bitwise
            // complement of the next larger element in the array.
            //
            index = ~index;

            Console.Write("Not found. Sorts between: ");

            if (index == 0)
                Console.Write("beginning of array and ");
            else
                Console.Write("{0} and ", array[index-1]);

            if (index == array.Length)
                Console.WriteLine("end of array.");
            else
                Console.WriteLine("{0}.", array[index]);
        }
        else
        {
            Console.WriteLine("Found at index {0}.", index);
        }
    }
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


