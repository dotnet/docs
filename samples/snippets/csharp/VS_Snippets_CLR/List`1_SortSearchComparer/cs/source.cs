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
        dinosaurs.Add("Amargasaurus");
        dinosaurs.Add("Mamenchisaurus");
        dinosaurs.Add("Deinonychus");
        Display(dinosaurs);

        DinoComparer dc = new DinoComparer();

        Console.WriteLine("\nSort with alternate comparer:");
        dinosaurs.Sort(dc);
        Display(dinosaurs);

        SearchAndInsert(dinosaurs, "Coelophysis", dc);
        Display(dinosaurs);

        SearchAndInsert(dinosaurs, "Oviraptor", dc);
        Display(dinosaurs);

        SearchAndInsert(dinosaurs, "Tyrannosaur", dc);
        Display(dinosaurs);

        SearchAndInsert(dinosaurs, null, dc);
        Display(dinosaurs);
    }

    private static void SearchAndInsert(List<string> list, 
        string insert, DinoComparer dc)
    {
        Console.WriteLine("\nBinarySearch and Insert \"{0}\":", insert);

        int index = list.BinarySearch(insert, dc);

        if (index < 0)
        {
            list.Insert(~index, insert);
        }
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
Amargasaurus
Mamenchisaurus
Deinonychus

Sort with alternate comparer:

Deinonychus
Amargasaurus
Mamenchisaurus
Pachycephalosaurus

BinarySearch and Insert "Coelophysis":

Coelophysis
Deinonychus
Amargasaurus
Mamenchisaurus
Pachycephalosaurus

BinarySearch and Insert "Oviraptor":

Oviraptor
Coelophysis
Deinonychus
Amargasaurus
Mamenchisaurus
Pachycephalosaurus

BinarySearch and Insert "Tyrannosaur":

Oviraptor
Coelophysis
Deinonychus
Tyrannosaur
Amargasaurus
Mamenchisaurus
Pachycephalosaurus

BinarySearch and Insert "":


Oviraptor
Coelophysis
Deinonychus
Tyrannosaur
Amargasaurus
Mamenchisaurus
Pachycephalosaurus
 */
// </Snippet1>


