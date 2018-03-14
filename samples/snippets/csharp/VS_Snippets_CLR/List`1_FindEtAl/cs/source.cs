// REDMOND\glennha
// <Snippet1>
using System;
using System.Collections.Generic;

public class Example
{
    public static void Main()
    {
        List<string> dinosaurs = new List<string>();

        dinosaurs.Add("Compsognathus");
        dinosaurs.Add("Amargasaurus");
        dinosaurs.Add("Oviraptor");
        dinosaurs.Add("Velociraptor");
        dinosaurs.Add("Deinonychus");
        dinosaurs.Add("Dilophosaurus");
        dinosaurs.Add("Gallimimus");
        dinosaurs.Add("Triceratops");

        Console.WriteLine();
        foreach(string dinosaur in dinosaurs)
        {
            Console.WriteLine(dinosaur);
        }

        Console.WriteLine("\nTrueForAll(EndsWithSaurus): {0}",
            dinosaurs.TrueForAll(EndsWithSaurus));

        Console.WriteLine("\nFind(EndsWithSaurus): {0}", 
            dinosaurs.Find(EndsWithSaurus));

        Console.WriteLine("\nFindLast(EndsWithSaurus): {0}",
            dinosaurs.FindLast(EndsWithSaurus));

        Console.WriteLine("\nFindAll(EndsWithSaurus):");
        List<string> sublist = dinosaurs.FindAll(EndsWithSaurus);

        foreach(string dinosaur in sublist)
        {
            Console.WriteLine(dinosaur);
        }

        Console.WriteLine(
            "\n{0} elements removed by RemoveAll(EndsWithSaurus).", 
            dinosaurs.RemoveAll(EndsWithSaurus));

        Console.WriteLine("\nList now contains:");
        foreach(string dinosaur in dinosaurs)
        {
            Console.WriteLine(dinosaur);
        }

        Console.WriteLine("\nExists(EndsWithSaurus): {0}", 
            dinosaurs.Exists(EndsWithSaurus));
    }

    // Search predicate returns true if a string ends in "saurus".
    private static bool EndsWithSaurus(String s)
    {
        return s.ToLower().EndsWith("saurus");
    }
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

TrueForAll(EndsWithSaurus): False

Find(EndsWithSaurus): Amargasaurus

FindLast(EndsWithSaurus): Dilophosaurus

FindAll(EndsWithSaurus):
Amargasaurus
Dilophosaurus

2 elements removed by RemoveAll(EndsWithSaurus).

List now contains:
Compsognathus
Oviraptor
Velociraptor
Deinonychus
Gallimimus
Triceratops

Exists(EndsWithSaurus): False
 */
// </Snippet1>


