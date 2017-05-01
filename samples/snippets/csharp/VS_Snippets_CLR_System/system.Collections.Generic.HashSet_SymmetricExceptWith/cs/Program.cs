//<snippet01>
using System;
using System.Collections.Generic;

class Program
{
    //<snippet02>
    static void Main()
    {
        HashSet<int> lowNumbers = new HashSet<int>();
        HashSet<int> highNumbers = new HashSet<int>();

        for (int i = 0; i < 6; i++)
        {
            lowNumbers.Add(i);
        }

        for (int i = 3; i < 10; i++)
        {
            highNumbers.Add(i);
        }

        Console.Write("lowNumbers contains {0} elements: ", lowNumbers.Count);
        DisplaySet(lowNumbers);

        Console.Write("highNumbers contains {0} elements: ", highNumbers.Count);
        DisplaySet(highNumbers);

        Console.WriteLine("lowNumbers SymmetricExceptWith highNumbers...");
        lowNumbers.SymmetricExceptWith(highNumbers);

        Console.Write("lowNumbers contains {0} elements: ", lowNumbers.Count);
        DisplaySet(lowNumbers);



    }
    /* This example provides output similar to the following:
     * lowNumbers contains 6 elements: { 0 1 2 3 4 5 }
     * highNumbers contains 7 elements: { 3 4 5 6 7 8 9 }
     * lowNumbers SymmetricExceptWith highNumbers...
     * lowNumbers contains 7 elements: { 0 1 2 8 7 6 9 }
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
