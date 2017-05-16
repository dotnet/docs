using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace IOrderedSequence
{
    static class IOrderedSequence
    {
        static void Main(string[] args)
        {
            Example2();
        }

        static void Example1()
        {
            // <Snippet1>
            // Create an array of strings to sort.
            string[] fruits = { "apricot", "orange", "banana", "mango", "apple", "grape", "strawberry" };

            // Sort the strings first by their length and then alphabetically
            // by passing the identity selector function.
            IOrderedEnumerable<string> sortedFruits1 =
                fruits.OrderBy(fruit => fruit.Length).ThenBy(fruit => fruit);

            // Output the resulting sequence of strings.
            foreach (string fruit in sortedFruits1)
                Console.WriteLine(fruit);

            // This code produces the following output:
            //
            // apple
            // grape
            // mango
            // banana
            // orange
            // apricot
            // strawberry

            // </Snippet1>

            Console.WriteLine();
        }

        static void Example2()
        {
            // <Snippet2>
            // Create an array of strings to sort.
            string[] fruits = { "apricot", "orange", "banana", "mango", "apple", "grape", "strawberry" };
            // First sort the strings by their length.
            IOrderedEnumerable<string> sortedFruits2 =
                fruits.OrderBy(fruit => fruit.Length);
            // Secondarily sort the strings alphabetically, using the default comparer.
            IOrderedEnumerable<string> sortedFruits3 =
                sortedFruits2.CreateOrderedEnumerable<string>(
                    fruit => fruit,
                    Comparer<string>.Default, false);

            // Output the resulting sequence of strings.
            foreach (string fruit in sortedFruits3)
                Console.WriteLine(fruit);

            // This code produces the following output:
            //
            // apple
            // grape
            // mango
            // banana
            // orange
            // apricot
            // strawberry

            // </Snippet2>
        }
    }
}
