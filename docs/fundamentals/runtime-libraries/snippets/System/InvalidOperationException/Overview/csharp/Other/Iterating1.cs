// <Snippet1>
using System;
using System.Collections.Generic;

public class IteratingEx1
{
    public static void Main()
    {
        var numbers = new List<int>() { 1, 2, 3, 4, 5 };
        foreach (var number in numbers)
        {
            int square = (int)Math.Pow(number, 2);
            Console.WriteLine($"{number}^{square}");
            Console.WriteLine($"Adding {square} to the collection...");
            Console.WriteLine();
            numbers.Add(square);
        }
    }
}
// The example displays the following output:
//    1^1
//    Adding 1 to the collection...
//
//
//    Unhandled Exception: System.InvalidOperationException: Collection was modified;
//       enumeration operation may not execute.
//       at System.ThrowHelper.ThrowInvalidOperationException(ExceptionResource resource)
//       at System.Collections.Generic.List`1.Enumerator.MoveNextRare()
//       at Example.Main()
// </Snippet1>
