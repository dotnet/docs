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
        dinosaurs.Add("Deinonychus");
        dinosaurs.Add("Tyrannosaurus");
        dinosaurs.Add("Compsognathus");

        Console.WriteLine();
        foreach(string dinosaur in dinosaurs)
        {
            Console.WriteLine(dinosaur);
        }

        Console.WriteLine("\nIndexOf(\"Tyrannosaurus\"): {0}", 
            dinosaurs.IndexOf("Tyrannosaurus"));

        Console.WriteLine("\nIndexOf(\"Tyrannosaurus\", 3): {0}", 
            dinosaurs.IndexOf("Tyrannosaurus", 3));

        Console.WriteLine("\nIndexOf(\"Tyrannosaurus\", 2, 2): {0}", 
            dinosaurs.IndexOf("Tyrannosaurus", 2, 2));
    }
}

/* This code example produces the following output:

Tyrannosaurus
Amargasaurus
Mamenchisaurus
Brachiosaurus
Deinonychus
Tyrannosaurus
Compsognathus

IndexOf("Tyrannosaurus"): 0

IndexOf("Tyrannosaurus", 3): 5

IndexOf("Tyrannosaurus", 2, 2): -1
 */
// </Snippet1>


