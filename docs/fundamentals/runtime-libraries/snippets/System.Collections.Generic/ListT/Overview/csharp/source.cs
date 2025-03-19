using System;
using System.Collections.Generic;

public class Example2
{
    public static void Main()
    {
        //<Snippet1>
        //<snippet2>
        List<string> dinosaurs = new List<string>();

        Console.WriteLine($"\nCapacity: {dinosaurs.Capacity}");

        dinosaurs.Add("Tyrannosaurus");
        dinosaurs.Add("Amargasaurus");
        dinosaurs.Add("Mamenchisaurus");
        dinosaurs.Add("Deinonychus");
        dinosaurs.Add("Compsognathus");
        //</snippet2>
        Console.WriteLine();
        foreach (string dinosaur in dinosaurs)
        {
            Console.WriteLine(dinosaur);
        }

        Console.WriteLine($"\nCapacity: {dinosaurs.Capacity}");
        Console.WriteLine($"Count: {dinosaurs.Count}");

        Console.WriteLine("\nContains(\"Deinonychus\"): {0}",
            dinosaurs.Contains("Deinonychus"));

        Console.WriteLine("\nInsert(2, \"Compsognathus\")");
        dinosaurs.Insert(2, "Compsognathus");

        Console.WriteLine();
        foreach (string dinosaur in dinosaurs)
        {
            Console.WriteLine(dinosaur);
        }

        //<snippet3>
        // Shows accessing the list using the Item property.
        Console.WriteLine($"\ndinosaurs[3]: {dinosaurs[3]}");
        //</snippet3>

        Console.WriteLine("\nRemove(\"Compsognathus\")");
        dinosaurs.Remove("Compsognathus");

        Console.WriteLine();
        foreach (string dinosaur in dinosaurs)
        {
            Console.WriteLine(dinosaur);
        }

        dinosaurs.TrimExcess();
        Console.WriteLine("\nTrimExcess()");
        Console.WriteLine($"Capacity: {dinosaurs.Capacity}");
        Console.WriteLine($"Count: {dinosaurs.Count}");

        dinosaurs.Clear();
        Console.WriteLine("\nClear()");
        Console.WriteLine($"Capacity: {dinosaurs.Capacity}");
        Console.WriteLine($"Count: {dinosaurs.Count}");

        /* This code example produces the following output:

        Capacity: 0

        Tyrannosaurus
        Amargasaurus
        Mamenchisaurus
        Deinonychus
        Compsognathus

        Capacity: 8
        Count: 5

        Contains("Deinonychus"): True

        Insert(2, "Compsognathus")

        Tyrannosaurus
        Amargasaurus
        Compsognathus
        Mamenchisaurus
        Deinonychus
        Compsognathus

        dinosaurs[3]: Mamenchisaurus

        Remove("Compsognathus")

        Tyrannosaurus
        Amargasaurus
        Mamenchisaurus
        Deinonychus
        Compsognathus

        TrimExcess()
        Capacity: 5
        Count: 5

        Clear()
        Capacity: 5
        Count: 0
         */
        // </Snippet1>
    }
}
