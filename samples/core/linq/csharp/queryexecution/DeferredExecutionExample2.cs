using System;
using System.Linq;

namespace QueryExecution
{
    public class DeferredExecutionExample2
    {
        //The following sample shows how, because of deferred execution, queries can be used again after data changes
        //and will then operate on the new data.
        //
        //Output:
        // First run numbers <= 3:
        // 1
        // 3
        // 2
        // 0
        // Run lowEvenNumbers query:
        // 2
        // 0
        // Second run numbers <= 3:
        // -5
        // -4
        // -1
        // -3
        // -9
        // -8
        // -6
        // -7
        // -2
        // 0
        public static void QuerySyntaxExample()
        {
            // Deferred execution lets us define a query once
            // and then reuse it later in various ways.
            int[] numbers = {5, 4, 1, 3, 9, 8, 6, 7, 2, 0};
            var lowNumbers =
                from num in numbers
                where num <= 3
                select num;

            Console.WriteLine("First run numbers <= 3:");
            foreach (int n in lowNumbers)
            {
                Console.WriteLine(n);
            }

            // Query the original query.
            var lowEvenNumbers =
                from num in lowNumbers
                where num%2 == 0
                select num;

            Console.WriteLine("Run lowEvenNumbers query:");
            foreach (int n in lowEvenNumbers)
            {
                Console.WriteLine(n);
            }

            // Modify the source data.
            for (int i = 0; i < 10; i++)
            {
                numbers[i] = -numbers[i];
            }

            // During this second run, the same query object,
            // lowNumbers, will be iterating over the new state
            // of numbers[], producing different results:
            Console.WriteLine("Second run numbers <= 3:");
            foreach (int n in lowNumbers)
            {
                Console.WriteLine(n);
            }
        }

        //The following sample shows how, because of deferred execution, queries can be used again after data changes
        //and will then operate on the new data.
        //
        //Output:
        // First run numbers <= 3:
        // 1
        // 3
        // 2
        // 0
        // Run lowEvenNumbers query:
        // 2
        // 0
        // Second run numbers <= 3:
        // -5
        // -4
        // -1
        // -3
        // -9
        // -8
        // -6
        // -7
        // -2
        // 0
        public static void MethodSyntaxExample()
        {
            // Deferred execution lets us define a query once
            // and then reuse it later in various ways.
            int[] numbers = {5, 4, 1, 3, 9, 8, 6, 7, 2, 0};
            var lowNumbers = numbers.Where(num => num <= 3);

            Console.WriteLine("First run numbers <= 3:");
            foreach (int n in lowNumbers)
            {
                Console.WriteLine(n);
            }

            // Query the original query.
            var lowEvenNumbers = lowNumbers.Where(num => num%2 == 0);

            Console.WriteLine("Run lowEvenNumbers query:");
            foreach (int n in lowEvenNumbers)
            {
                Console.WriteLine(n);
            }

            // Modify the source data.
            for (int i = 0; i < 10; i++)
            {
                numbers[i] = -numbers[i];
            }

            // During this second run, the same query object,
            // lowNumbers, will be iterating over the new state
            // of numbers[], producing different results:
            Console.WriteLine("Second run numbers <= 3:");
            foreach (int n in lowNumbers)
            {
                Console.WriteLine(n);
            }
        }
    }
}