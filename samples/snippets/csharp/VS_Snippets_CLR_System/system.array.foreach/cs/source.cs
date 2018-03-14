// The following example demonstrates using the ForEach method.

//<Snippet1>
using System;

public class SamplesArray
{
    public static void Main()
    {
        // create a three element array of integers
        int[] intArray = new int[] {2, 3, 4};

        // set a delegate for the ShowSquares method
        Action<int> action = new Action<int>(ShowSquares);

        Array.ForEach(intArray, action);
    }

    private static void ShowSquares(int val)
    {
        Console.WriteLine("{0:d} squared = {1:d}", val, val*val);
    }
}

/*
This code produces the following output:

2 squared = 4
3 squared = 9
4 squared = 16
*/

//</Snippet1>
