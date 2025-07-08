// <Snippet3>
using System;
using System.Collections.Generic;

public class IteratingEx3
{
    public static void Main()
    {
        var numbers = new List<int>() { 1, 2, 3, 4, 5 };
        var temp = new List<int>();

        // Square each number and store it in a temporary collection.
        foreach (var number in numbers)
        {
            int square = (int)Math.Pow(number, 2);
            temp.Add(square);
        }

        // Combine the numbers into a single array.
        int[] combined = new int[numbers.Count + temp.Count];
        Array.Copy(numbers.ToArray(), 0, combined, 0, numbers.Count);
        Array.Copy(temp.ToArray(), 0, combined, numbers.Count, temp.Count);

        // Iterate the array.
        foreach (var value in combined)
            Console.Write("{0}    ", value);
    }
}
// The example displays the following output:
//       1    2    3    4    5    1    4    9    16    25
// </Snippet3>
