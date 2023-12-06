using System;

public class ConvertStringExample1
{
    static void Main(string[] args)
    {
        int numVal = -1;
        Console.WriteLine($"Initial value: {numVal}");
        string[] inputs = [ "473", "2147483647", "-1000"];

        foreach (string input in inputs)
        {
            Console.WriteLine($"The next input is {input}.");

            // ToInt32 can throw FormatException or OverflowException.
            try
            {
                numVal = Convert.ToInt32(input);
                if (numVal < Int32.MaxValue)
                {
                    Console.WriteLine("The new value is {0}", ++numVal);
                }
                else
                {
                    Console.WriteLine("numVal cannot be incremented beyond its current value");
                }
           }
            catch (FormatException)
            {
                Console.WriteLine("Input string is not a sequence of digits.");
            }
            catch (OverflowException)
            {
                Console.WriteLine("The number cannot fit in an Int32.");
            }
        }
    }
}
// Output:
//   Initial value: -1
//   The next input is 473.
//   The new value is 474
//   The next input is 2147483647.
//   numVal cannot be incremented beyond its current value
//   The next input is -1000.
//   The new value is -999