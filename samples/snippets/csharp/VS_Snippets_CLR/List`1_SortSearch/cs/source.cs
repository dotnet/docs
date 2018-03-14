// REDMOND\glennha
// <Snippet1>
using System;
using System.Collections.Generic;

public class Example
{
    public static void Main()
    {
        List<string> dinosaurs = new List<string>();

        dinosaurs.Add("Pachycephalosaurus");
        dinosaurs.Add("Amargasaurus");
        dinosaurs.Add("Mamenchisaurus");
        dinosaurs.Add("Deinonychus");

        Console.WriteLine();
        foreach(string dinosaur in dinosaurs)
        {
            Console.WriteLine(dinosaur);
        }

        Console.WriteLine("\nSort");
        dinosaurs.Sort();

        Console.WriteLine();
        foreach(string dinosaur in dinosaurs)
        {
            Console.WriteLine(dinosaur);
        }

        Console.WriteLine("\nBinarySearch and Insert \"Coelophysis\":");
        int index = dinosaurs.BinarySearch("Coelophysis");
        if (index < 0)
        {
            dinosaurs.Insert(~index, "Coelophysis");
        }

        Console.WriteLine();
        foreach(string dinosaur in dinosaurs)
        {
            Console.WriteLine(dinosaur);
        }

        Console.WriteLine("\nBinarySearch and Insert \"Tyrannosaurus\":");
        index = dinosaurs.BinarySearch("Tyrannosaurus");
        if (index < 0)
        {
            dinosaurs.Insert(~index, "Tyrannosaurus");
        }

        Console.WriteLine();
        foreach(string dinosaur in dinosaurs)
        {
            Console.WriteLine(dinosaur);
        }
    }
}

/* This code example produces the following output:

Pachycephalosaurus
Amargasaurus
Mamenchisaurus
Deinonychus

Sort

Amargasaurus
Deinonychus
Mamenchisaurus
Pachycephalosaurus

BinarySearch and Insert "Coelophysis":

Amargasaurus
Coelophysis
Deinonychus
Mamenchisaurus
Pachycephalosaurus

BinarySearch and Insert "Tyrannosaurus":

Amargasaurus
Coelophysis
Deinonychus
Mamenchisaurus
Pachycephalosaurus
Tyrannosaurus
 */
// </Snippet1>


