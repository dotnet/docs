using System;
using System.Linq;

namespace Conversion
{
    public static class OfTypeSample1
    {
        //This sample uses OfType to return only the elements of the array that are of type double.
        //
        //Output:
        // Numbers stored as doubles:
        // 1
        // 7 
        public static void Example()
        {
            object[] numbers = { null, 1.0, "two", 3, "four", 5, "six", 7.0 };

            var doubles = numbers.OfType<double>();

            Console.WriteLine("Numbers stored as doubles:");
            foreach (var d in doubles)
            {
                Console.WriteLine(d);
            }
        }
    }
}