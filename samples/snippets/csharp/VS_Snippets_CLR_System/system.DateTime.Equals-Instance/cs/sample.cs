//<snippet1>
using System;

public class Application
{
    public static void Main()
    {
        // Create some DateTime objects.
        DateTime one = DateTime.UtcNow;

        DateTime two = DateTime.Now;

        DateTime three = one;

        // Compare the DateTime objects and display the results.
        bool result = one.Equals(two);

        Console.WriteLine("The result of comparing DateTime object one and two is: {0}.", result);

        result = one.Equals(three);

        Console.WriteLine("The result of comparing DateTime object one and three is: {0}.", result);
    }
}

// This code example displays the following:
//
// The result of comparing DateTime object one and two is: False.
// The result of comparing DateTime object one and three is: True.
//</snippet1>