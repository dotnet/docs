using System;
using System.Linq;

namespace Element
{
    public static class ElementAtSample1
    {
        //This sample uses ElementAt and query syntaxto retrieve the second number greater than 5 from an array.
        //
        //Output: 
        // Second number > 5: 8
        public static void QuerySyntaxExample()
        {
            int[] numbers = {5, 4, 1, 3, 9, 8, 6, 7, 2, 0};

            int fourthLowNum = (
                from num in numbers
                where num > 5
                select num)
                .ElementAt(1); // second number is index 1 because sequences use 0-based indexing

            Console.WriteLine("Second number > 5: {0}", fourthLowNum);
        }

        //This sample uses ElementAt and method syntax to retrieve the second number greater than 5 from an array.
        //
        //Output: 
        // Second number > 5: 8
        public static void MethodSyntaxExample()
        {
            int[] numbers = {5, 4, 1, 3, 9, 8, 6, 7, 2, 0};

            // second number is index 1 because sequences use 0-based indexing
            int fourthLowNum = (numbers.Where(num => num > 5)).ElementAt(1);
               
            Console.WriteLine("Second number > 5: {0}", fourthLowNum);
        }
    }
}