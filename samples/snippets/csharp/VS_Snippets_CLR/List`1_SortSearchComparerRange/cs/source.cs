// REDMOND\glennha
// <Snippet1>
using System;
using System.Collections.Generic;

public class DinoComparer: IComparer<string>
{
    public int Compare(string x, string y)
    {
        if (x == null)
        {
            if (y == null)
            {
                // If x is null and y is null, they're
                // equal. 
                return 0;
            }
            else
            {
                // If x is null and y is not null, y
                // is greater. 
                return -1;
            }
        }
        else
        {
            // If x is not null...
            //
            if (y == null)
                // ...and y is null, x is greater.
            {
                return 1;
            }
            else
            {
                // ...and y is not null, compare the 
                // lengths of the two strings.
                //
                int retval = x.Length.CompareTo(y.Length);

                if (retval != 0)
                {
                    // If the strings are not of equal length,
                    // the longer string is greater.
                    //
                    return retval;
                }
                else
                {
                    // If the strings are of equal length,
                    // sort them with ordinary string comparison.
                    //
                    return x.CompareTo(y);
                }
            }
        }
    }
}

public class Example
{
    public static void Main()
    {
        List<string> dinosaurs = new List<string>();

        dinosaurs.Add("Pachycephalosaurus");
        dinosaurs.Add("Parasauralophus");
        dinosaurs.Add("Amargasaurus");
        dinosaurs.Add("Galimimus");
        dinosaurs.Add("Mamenchisaurus");
        dinosaurs.Add("Deinonychus");
        dinosaurs.Add("Oviraptor");
        dinosaurs.Add("Tyrannosaurus");

        int herbivores = 5;
        Display(dinosaurs);

        DinoComparer dc = new DinoComparer();

        Console.WriteLine("\nSort a range with the alternate comparer:");
        dinosaurs.Sort(0, herbivores, dc);
        Display(dinosaurs);

        Console.WriteLine("\nBinarySearch a range and Insert \"{0}\":",
            "Brachiosaurus");

        int index = dinosaurs.BinarySearch(0, herbivores, "Brachiosaurus", dc);

        if (index < 0)
        {
            dinosaurs.Insert(~index, "Brachiosaurus");
            herbivores++;
        }

        Display(dinosaurs);
    }

    private static void Display(List<string> list)
    {
        Console.WriteLine();
        foreach( string s in list )
        {
            Console.WriteLine(s);
        }
    }
}

/* This code example produces the following output:

Pachycephalosaurus
Parasauralophus
Amargasaurus
Galimimus
Mamenchisaurus
Deinonychus
Oviraptor
Tyrannosaurus

Sort a range with the alternate comparer:

Galimimus
Amargasaurus
Mamenchisaurus
Parasauralophus
Pachycephalosaurus
Deinonychus
Oviraptor
Tyrannosaurus

BinarySearch a range and Insert "Brachiosaurus":

Galimimus
Amargasaurus
Brachiosaurus
Mamenchisaurus
Parasauralophus
Pachycephalosaurus
Deinonychus
Oviraptor
Tyrannosaurus
 */
// </Snippet1>


