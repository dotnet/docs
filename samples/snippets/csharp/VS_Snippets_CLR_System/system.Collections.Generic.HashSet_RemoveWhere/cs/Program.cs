//<snippet01>
//<snippet02>
using System;
using System.Collections.Generic;

class Example
{
    static void Main()
    {
        HashSet<int> numbers = new HashSet<int>();

        for (int i = 0; i < 20; i++) {
            numbers.Add(i);
        }

        // Display all the numbers in the hash table.
        Console.Write("numbers contains {0} elements: ", numbers.Count);
        DisplaySet(numbers);

        // Remove all odd numbers.
        numbers.RemoveWhere(IsOdd);
        Console.Write("numbers contains {0} elements: ", numbers.Count);
        DisplaySet(numbers);

        // Check if the hash table contains 0 and, if so, remove it.
        if (numbers.Contains(0)) {
            numbers.Remove(0);
        }
        Console.Write("numbers contains {0} elements: ", numbers.Count);
        DisplaySet(numbers);
    }

    private static bool IsOdd(int i)
    {
        return ((i % 2) == 1);
    }

    private static void DisplaySet(HashSet<int> set)
    {
        Console.Write("{");
        foreach (int i in set)
            Console.Write(" {0}", i);

        Console.WriteLine(" }");
    }
}
// This example display the following output:
//    numbers contains 20 elements: { 0 1 2 3 4 5 6 7 8 9 10 11 12 13 14 15 16 17 18 19 }
//    numbers contains 10 elements: { 0 2 4 6 8 10 12 14 16 18 }
//    numbers contains 9 elements: { 2 4 6 8 10 12 14 16 18 }
// </snippet02>
// </snippet01>


