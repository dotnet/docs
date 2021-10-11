// <Snippet108>
using System;

class RefArrayExample
{
    static void Main()
    {
        int[] arr = {1, 4, 5};
        Console.WriteLine("In Main, array has {0} elements and starts with {1}",
                          arr.Length, arr[0]);

        Change(ref arr);
        Console.WriteLine("Back in Main, array has {0} elements and starts with {1}",
                          arr.Length, arr[0]);
    }

    static void Change(ref int[] arr)
    {
        // Both of the following changes will affect the original variables:
        arr = new int[5] {-9, -7, -5, -3, -1};
        Console.WriteLine("In Change, array has {0} elements and starts with {1}",
                          arr.Length, arr[0]);
    }
}
// The example displays the following output:
//        In Main, array has 3 elements and starts with 1
//        In Change, array has 5 elements and starts with -9
//        Back in Main, array has 5 elements and starts with -9
// </Snippet108>
