// <Snippet1>
using System;

public class Example
{
    public static void Main()
    {
        var numbers = (2, 3, 4, 5, 6);
        Func<(int, int, int, int, int), (int, int, int, int, int)> doubleThem = (n) => (n.Item1 * 2, n.Item2 * 2, n.Item3 * 2, n.Item4 * 2, n.Item5 * 2);
        var doubledNumbers = doubleThem(numbers);

        Console.WriteLine("The set {0} doubled: {1}", numbers, doubledNumbers);
        Console.ReadLine();
    }
}
// The example displays the following output:
//    The set (2, 3, 4, 5, 6) doubled: (4, 6, 8, 10, 12)
// </Snippet1>
