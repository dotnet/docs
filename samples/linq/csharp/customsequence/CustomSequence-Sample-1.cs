using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomSequence
{
    public static class CustomSequenceSample1
    {
        private static IEnumerable<T> Combine<T>(this IEnumerable<T> first, IEnumerable<T> second, Func<T, T, T> func)
        {
            var e1 = first.GetEnumerator();
            var e2 = second.GetEnumerator();

            while (e1.MoveNext() && e2.MoveNext())
            {
                yield return func(e1.Current, e2.Current);
            }
        }

        //This sample calculates the dot product of two integer vectors. It uses a user-created sequence operator,
        //Combine, to calculate the dot product, passing it a lambda function to multiply two arrays, element by element,
        //and sum the result.
        //
        //Output
        // Dot product: 109
        public static void Example()
        {
            int[] vectorA = {0, 2, 4, 5, 6};
            int[] vectorB = {1, 3, 5, 7, 8};

            int dotProduct = vectorA.Combine(vectorB, (a, b) => a * b).Sum();

            Console.WriteLine("Dot product: {0}", dotProduct);
        }
    }
}