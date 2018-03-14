using System;
using System.Linq;

namespace QueryExecution
{
    public class ImmediateExecutionExample1
    {
        //The following sample shows how queries can be executed immediately, and their results stored in memory, with methods such as ToList.
        //
        //Output:
        // The current value of i is 10
        // v = 1, i = 10
        // v = 2, i = 10
        // v = 3, i = 10
        // v = 4, i = 10
        // v = 5, i = 10
        // v = 6, i = 10
        // v = 7, i = 10
        // v = 8, i = 10
        // v = 9, i = 10
        // v = 10, i = 10
        public static void QuerySyntaxExample()
        {
            // Methods like ToList(), Max(), and Count() cause the query to be
            // executed immediately.            
            int[] numbers = {5, 4, 1, 3, 9, 8, 6, 7, 2, 0};

            int i = 0;
            var immediateQuery = (
                from num in numbers
                select ++i)
                .ToList();

            Console.WriteLine("The current value of i is {0}", i); //i has been incremented

            foreach (var item in immediateQuery)
            {
                Console.WriteLine("v = {0}, i = {1}", item, i);
            }
        }

        //The following sample shows how queries can be executed immediately, and their results stored in memory, with methods such as ToList.
        //
        //Output:
        // The current value of i is 10
        // v = 1, i = 10
        // v = 2, i = 10
        // v = 3, i = 10
        // v = 4, i = 10
        // v = 5, i = 10
        // v = 6, i = 10
        // v = 7, i = 10
        // v = 8, i = 10
        // v = 9, i = 10
        // v = 10, i = 10
        public static void MethodSyntaxExample()
        {
            // Methods like ToList(), Max(), and Count() cause the query to be
            // executed immediately.            
            int[] numbers = {5, 4, 1, 3, 9, 8, 6, 7, 2, 0};

            int i = 0;
            var immediateQuery = numbers.Select(num => ++i).ToList();

            Console.WriteLine("The current value of i is {0}", i); //i has been incremented

            foreach (var item in immediateQuery)
            {
                Console.WriteLine("v = {0}, i = {1}", item, i);
            }
        }
    }
}