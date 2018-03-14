// REDMOND\glennha
// <Snippet1>
using System;
using System.Collections.Generic;

public class Example
{
    public static void Main()
    {
        List<string> dinosaurs = new List<string>();

        dinosaurs.Add("Tyrannosaurus");
        dinosaurs.Add("Amargasaurus");
        dinosaurs.Add("Mamenchisaurus");
        dinosaurs.Add("Brachiosaurus");
        dinosaurs.Add("Compsognathus");

        Console.WriteLine();
        foreach(string dinosaur in dinosaurs)
        {
            Console.WriteLine(dinosaur);
        }

        // Declare an array with 15 elements.
        string[] array = new string[15];

        dinosaurs.CopyTo(array);
        dinosaurs.CopyTo(array, 6);
        dinosaurs.CopyTo(2, array, 12, 3);

        Console.WriteLine("\nContents of the array:");
        foreach(string dinosaur in array)
        {
            Console.WriteLine(dinosaur);
        }
    }
}

/* This code example produces the following output:

Tyrannosaurus
Amargasaurus
Mamenchisaurus
Brachiosaurus
Compsognathus

Contents of the array:
Tyrannosaurus
Amargasaurus
Mamenchisaurus
Brachiosaurus
Compsognathus

Tyrannosaurus
Amargasaurus
Mamenchisaurus
Brachiosaurus
Compsognathus

Mamenchisaurus
Brachiosaurus
Compsognathus
 */
// </Snippet1>


