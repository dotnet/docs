using System;
using System.Linq;

namespace QueryExecution
{
    public class DeferredExecutionExample1
    {
        //The following sample shows how query execution is deferred until the query is enumerated at a foreach statement.
        //
        //Output:
        // The current value of i is 0
        // v = 1, i = 1
        // v = 2, i = 2
        // v = 3, i = 3
        // v = 4, i = 4
        // v = 5, i = 5
        // v = 6, i = 6
        // v = 7, i = 7
        // v = 8, i = 8
        // v = 9, i = 9
        // v = 10, i = 10
        public static void QuerySyntaxExample()
        {
            // Queries are not executed until you enumerate over them.
            int[] numbers = {5, 4, 1, 3, 9, 8, 6, 7, 2, 0};

            int i = 0;
            var simpleQuery =
                from num in numbers
                select ++i;

            // The local variable 'i' is not incremented
            // until the query is executed in the foreach loop.
            Console.WriteLine("The current value of i is {0}", i); //i is still zero

            foreach (var item in simpleQuery)
            {
                Console.WriteLine("v = {0}, i = {1}", item, i); // now i is incremented          
            }
        }

        //The following sample shows how query execution is deferred until the query is enumerated at a foreach statement.
        //
        //Output:
        // The current value of i is 0
        // v = 1, i = 1
        // v = 2, i = 2
        // v = 3, i = 3
        // v = 4, i = 4
        // v = 5, i = 5
        // v = 6, i = 6
        // v = 7, i = 7
        // v = 8, i = 8
        // v = 9, i = 9
        // v = 10, i = 10
        public static void MethodSyntaxExample()
        {
            // Queries are not executed until you enumerate over them.
            int[] numbers = {5, 4, 1, 3, 9, 8, 6, 7, 2, 0};

            int i = 0;
            var simpleQuery = numbers.Select(num => ++i);

            // The local variable 'i' is not incremented
            // until the query is executed in the foreach loop.
            Console.WriteLine("The current value of i is {0}", i); //i is still zero

            foreach (var item in simpleQuery)
            {
                Console.WriteLine("v = {0}, i = {1}", item, i); // now i is incremented          
            }
        }
    }
}