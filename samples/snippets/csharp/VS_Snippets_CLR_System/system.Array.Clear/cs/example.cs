//<snippet1>
using System;

class Example
{
    public static void Main()
    {
        Console.WriteLine("One dimension (Rank=1):");
        int[] numbers1 = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        for (int i = 0; i < 9; i++)
        {
            Console.Write("{0} ", numbers1[i]);
        }
        Console.WriteLine();
        Console.WriteLine();

        Console.WriteLine("Array.Clear(numbers1, 2, 5)");
        Array.Clear(numbers1, 2, 5);

        for (int i = 0; i < 9; i++)
        {
            Console.Write("{0} ", numbers1[i]);
        }
        Console.WriteLine();
        Console.WriteLine();

        Console.WriteLine("Two dimensions (Rank=2):");
        int[,] numbers2 = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Console.Write("{0} ", numbers2[i, j]);
            }
            Console.WriteLine();
        }

        Console.WriteLine();
        Console.WriteLine("Array.Clear(numbers2, 2, 5)");
        Array.Clear(numbers2, 2, 5);

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Console.Write("{0} ", numbers2[i, j]);
            }
            Console.WriteLine();
        }

        Console.WriteLine("Three dimensions (Rank=3):");
        int[, ,] numbers3 = {{{1, 2}, {3, 4}},
                             {{5, 6}, {7, 8}},
                             {{9, 10}, {11, 12}}};

        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                for (int k = 0; k < 2; k++)
                {
                    Console.Write("{0} ", numbers3[i, j, k]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        Console.WriteLine("Array.Clear(numbers3, 2, 5)");
        Array.Clear(numbers3, 2, 5);

        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                for (int k = 0; k < 2; k++)
                {
                    Console.Write("{0} ", numbers3[i, j, k]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
/*  This code example produces the following output:
 * 
 * One dimension (Rank=1):
 * 1 2 3 4 5 6 7 8 9
 * 
 * Array.Clear(numbers1, 2, 5)
 * 1 2 0 0 0 0 0 8 9
 * 
 * Two dimensions (Rank=2):
 * 1 2 3
 * 4 5 6
 * 7 8 9
 * 
 * Array.Clear(numbers2, 2, 5)
 * 1 2 0
 * 0 0 0
 * 0 8 9
 * 
 * Three dimensions (Rank=3):
 * 1 2
 * 3 4
 * 
 * 5 6
 * 7 8
 * 
 * Array.Clear(numbers3, 2, 5)
 * 1 2
 * 0 0
 * 
 * 0 0
 * 0 8
 */
//</snippet1>