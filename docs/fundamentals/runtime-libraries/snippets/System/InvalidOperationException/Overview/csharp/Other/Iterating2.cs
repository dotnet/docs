// <Snippet2>
using System;
using System.Collections.Generic;

public class IteratingEx2
{
    public static void Main()
    {
        var numbers = new List<int>() { 1, 2, 3, 4, 5 };

        int upperBound = numbers.Count - 1;
        for (int ctr = 0; ctr <= upperBound; ctr++)
        {
            int square = (int)Math.Pow(numbers[ctr], 2);
            Console.WriteLine($"{numbers[ctr]}^{square}");
            Console.WriteLine($"Adding {square} to the collection...");
            Console.WriteLine();
            numbers.Add(square);
        }

        Console.WriteLine("Elements now in the collection: ");
        foreach (var number in numbers)
            Console.Write("{0}    ", number);
    }
}
// The example displays the following output:
//    1^1
//    Adding 1 to the collection...
//
//    2^4
//    Adding 4 to the collection...
//
//    3^9
//    Adding 9 to the collection...
//
//    4^16
//    Adding 16 to the collection...
//
//    5^25
//    Adding 25 to the collection...
//
//    Elements now in the collection:
//    1    2    3    4    5    1    4    9    16    25
// </Snippet2>
