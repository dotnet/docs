// REDMOND\glennha
// <Snippet1>
using System;
using System.Collections.Generic;

public class Example
{
    public static void Main()
    {
        List<string> dinosaurs = new List<string>(4);

        Console.WriteLine("\nCapacity: {0}", dinosaurs.Capacity);

        dinosaurs.Add("Tyrannosaurus");
        dinosaurs.Add("Amargasaurus");
        dinosaurs.Add("Mamenchisaurus");
        dinosaurs.Add("Deinonychus");

        Console.WriteLine();
        foreach(string s in dinosaurs)
        {
            Console.WriteLine(s);
        }

        Console.WriteLine("\nIList<string> roDinosaurs = dinosaurs.AsReadOnly()");
        IList<string> roDinosaurs = dinosaurs.AsReadOnly();

        Console.WriteLine("\nElements in the read-only IList:");
        foreach(string dinosaur in roDinosaurs)
        {
            Console.WriteLine(dinosaur);
        }

        Console.WriteLine("\ndinosaurs[2] = \"Coelophysis\"");
        dinosaurs[2] = "Coelophysis";

        Console.WriteLine("\nElements in the read-only IList:");
        foreach(string dinosaur in roDinosaurs)
        {
            Console.WriteLine(dinosaur);
        }
    }
}

/* This code example produces the following output:

Capacity: 4

Tyrannosaurus
Amargasaurus
Mamenchisaurus
Deinonychus

IList<string> roDinosaurs = dinosaurs.AsReadOnly()

Elements in the read-only IList:
Tyrannosaurus
Amargasaurus
Mamenchisaurus
Deinonychus

dinosaurs[2] = "Coelophysis"

Elements in the read-only IList:
Tyrannosaurus
Amargasaurus
Coelophysis
Deinonychus
 */
// </Snippet1>


