// REDMOND\glennha
// <Snippet1>
using System;
using System.Collections.Generic;

public class ReverseComparer: IComparer<string>
{
    public int Compare(string x, string y)
    {
        // Compare y and x in reverse order.
        return y.CompareTo(x);
    }
}

public class Example
{
    public static void Main()
    {
        string[] dinosaurs = {"Pachycephalosaurus", 
                              "Amargasaurus", 
                              "Mamenchisaurus", 
                              "Tarbosaurus",
                              "Tyrannosaurus", 
                              "Albertasaurus"};

        Console.WriteLine();
        foreach( string dinosaur in dinosaurs )
        {
            Console.WriteLine(dinosaur);
        }

        Console.WriteLine("\nSort(dinosaurs, 3, 3)");
        Array.Sort(dinosaurs, 3, 3);

        Console.WriteLine();
        foreach( string dinosaur in dinosaurs )
        {
            Console.WriteLine(dinosaur);
        }

        ReverseComparer rc = new ReverseComparer();

        Console.WriteLine("\nSort(dinosaurs, 3, 3, rc)");
        Array.Sort(dinosaurs, 3, 3, rc);

        Console.WriteLine();
        foreach( string dinosaur in dinosaurs )
        {
            Console.WriteLine(dinosaur);
        }
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


