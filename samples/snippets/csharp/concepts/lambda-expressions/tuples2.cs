
// <Snippet1>
using System;

public class Example
{
    public static void Main()
    {
        var numbers = (2, 3, 4, 5, 6);
        Func<(int n1, int n2, int n3, int n4, int n5), (int, int, int, int, int)> doubleThem = (n) => (n.n1 * 2, n2 * 2, n.n3 * 2, n.n4 * 2, n.n5 * 2);
        var doubledNumbers = doubleThem(numbers);

        Console.WriteLine("The set {0} doubled: {1}", numbers, doubledNumbers);
        Console.ReadLine();
    }
}
// The example displays the following output:
//    The set (2, 3, 4, 5, 6) doubled: (4, 6, 8, 10, 12)
// </Snippet1>
