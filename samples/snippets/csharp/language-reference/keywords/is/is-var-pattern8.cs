// <Snippet8>
using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        int[] testSet = { 100271, 234335, 342439, 999683 };

        var primes = testSet.Where(n => Factor(n).ToList() is var factors
                                    && factors.Count == 2
                                    && factors.Contains(1)
                                    && factors.Contains(n));

        foreach (int prime in primes)
        {
            Console.WriteLine($"Found prime: {prime}");
        }
    }

    static IEnumerable<int> Factor(int number)
    {
        int max = (int)Math.Sqrt(number);
        for (int i = 1; i <= max; i++)
        {
            if (number % i == 0)
            {
                yield return i;
                if (i != number / i)
                {
                    yield return number / i;
                }
            }
        }
    }
}
// The example displays the following output:
//       Found prime: 100271
//       Found prime: 999683
// </Snippet8>
