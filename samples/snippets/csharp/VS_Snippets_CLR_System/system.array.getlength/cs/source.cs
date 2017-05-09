// The following example demonstrates using the Array.GetLength method.

// <Snippet1>
using System;

public class SamplesArray
{
    public static void Main()
    {
        // make a single dimension array
        Array MyArray1 = Array.CreateInstance(typeof(int), 5);

        // make a 3 dimensional array
        Array MyArray2 = Array.CreateInstance(typeof(int), 5, 3, 2);

        // make an array container
        Array BossArray = Array.CreateInstance(typeof(Array), 2);
        BossArray.SetValue(MyArray1, 0);
        BossArray.SetValue(MyArray2, 1);

        int i = 0, j, rank;
        foreach (Array anArray in BossArray)
        {
            rank = anArray.Rank;
            if (rank > 1)
            {
                Console.WriteLine("Lengths of {0:d} dimension array[{1:d}]", rank, i);
                // show the lengths of each dimension
                for (j = 0; j < rank; j++)
                {
                    Console.WriteLine("    Length of dimension({0:d}) = {1:d}", j, anArray.GetLength(j));
                }
            }
            else
            {
                Console.WriteLine("Lengths of single dimension array[{0:d}]", i);
            }
            // show the total length of the entire array or all dimensions
            Console.WriteLine("    Total length of the array = {0:d}", anArray.Length);
            Console.WriteLine();
            i++;
        }
    }
}

/*
This code produces the following output:

Lengths of single dimension array[0]
    Total length of the array = 5

Lengths of 3 dimension array[1]
    Length of dimension(0) = 5
    Length of dimension(1) = 3
    Length of dimension(2) = 2
    Total length of the array = 30
*/
// </Snippet1>
