//<snippet01>
using System;
using System.Collections.Generic;

class Program
{
    //<snippet02>
    static void Main()
    {
        HashSet<int> lowNumbers = new HashSet<int>();
        HashSet<int> allNumbers = new HashSet<int>();

        for (int i = 1; i < 5; i++)
        {
            lowNumbers.Add(i);
        }

        for (int i = 0; i < 10; i++)
        {
            allNumbers.Add(i);
        }

        Console.Write("lowNumbers contains {0} elements: ", lowNumbers.Count);
        DisplaySet(lowNumbers);

        Console.Write("allNumbers contains {0} elements: ", allNumbers.Count);
        DisplaySet(allNumbers);

        Console.WriteLine("lowNumbers overlaps allNumbers: {0}",
            lowNumbers.Overlaps(allNumbers));

        Console.WriteLine("allNumbers and lowNumbers are equal sets: {0}",
            allNumbers.SetEquals(lowNumbers));

        // Show the results of sub/superset testing
        Console.WriteLine("lowNumbers is a subset of allNumbers: {0}",
            lowNumbers.IsSubsetOf(allNumbers));
        Console.WriteLine("allNumbers is a superset of lowNumbers: {0}",
            allNumbers.IsSupersetOf(lowNumbers));
        Console.WriteLine("lowNumbers is a proper subset of allNumbers: {0}",
            lowNumbers.IsProperSubsetOf(allNumbers));
        Console.WriteLine("allNumbers is a proper superset of lowNumbers: {0}",
            allNumbers.IsProperSupersetOf(lowNumbers));

        // Modify allNumbers to remove numbers that are not in lowNumbers.
        allNumbers.IntersectWith(lowNumbers);
        Console.Write("allNumbers contains {0} elements: ", allNumbers.Count);
        DisplaySet(allNumbers);

        Console.WriteLine("allNumbers and lowNumbers are equal sets: {0}",
            allNumbers.SetEquals(lowNumbers));

        // Show the results of sub/superset testing with the modified set.
        Console.WriteLine("lowNumbers is a subset of allNumbers: {0}",
            lowNumbers.IsSubsetOf(allNumbers));
        Console.WriteLine("allNumbers is a superset of lowNumbers: {0}",
            allNumbers.IsSupersetOf(lowNumbers));
        Console.WriteLine("lowNumbers is a proper subset of allNumbers: {0}",
            lowNumbers.IsProperSubsetOf(allNumbers));
        Console.WriteLine("allNumbers is a proper superset of lowNumbers: {0}",
            allNumbers.IsProperSupersetOf(lowNumbers));
    }
    /* This code example produces output similar to the following:
     * lowNumbers contains 4 elements: { 1 2 3 4 }
     * allNumbers contains 10 elements: { 0 1 2 3 4 5 6 7 8 9 }
     * lowNumbers overlaps allNumbers: True
     * allNumbers and lowNumbers are equal sets: False
     * lowNumbers is a subset of allNumbers: True
     * allNumbers is a superset of lowNumbers: True
     * lowNumbers is a proper subset of allNumbers: True
     * allNumbers is a proper superset of lowNumbers: True
     * allNumbers contains 4 elements: { 1 2 3 4 }
     * allNumbers and lowNumbers are equal sets: True
     * lowNumbers is a subset of allNumbers: True
     * allNumbers is a superset of lowNumbers: True
     * lowNumbers is a proper subset of allNumbers: False
     * allNumbers is a proper superset of lowNumbers: False
     */
    //</snippet02>

    private static void DisplaySet(HashSet<int> set)
    {
        Console.Write("{");
        foreach (int i in set)
        {
            Console.Write(" {0}", i);
        }
        Console.WriteLine(" }");
    }
}
//</snippet01>
