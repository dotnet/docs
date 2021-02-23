// <snippet03>
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ParallelExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // 2 million
            int limit = 2 * 1000000;
            var inputs = new List<int>(limit);
            Random radomGenerator = new Random();
            for (int index = 0; index < limit; index++)
            {
                inputs.Add(radomGenerator.Next());
            }

            var watch = new Stopwatch();
            watch.Start();
            var primeNumbers = GetPrimeList(inputs);
            watch.Stop();

            var watchForParallel = new Stopwatch();
            watchForParallel.Start();
            var primeNumbersFromParallel = GetPrimeListWithParallel(inputs);
            watchForParallel.Stop();

            Console.WriteLine($"Classical For loop    | Total prime numbers : {primeNumbersFromParallel.Count} | Time Taken : {watch.ElapsedMilliseconds} ms.");
            Console.WriteLine($"Parallel.ForEach loop | Total prime numbers : {primeNumbersFromParallel.Count} | Time Taken : {watchForParallel.ElapsedMilliseconds} ms.");

            Console.WriteLine("Press any key to exit.");
            Console.ReadLine();
        }

        /// <summary>
        /// GetPrimeList returns Prime numbers by using sequential ForEach
        /// </summary>
        /// <param name="inputs"></param>
        /// <returns></returns>
        static IList<int> GetPrimeList(IList<int> inputs)
        {
            var primeNumbers = new List<int>();

            foreach (var item in inputs)
            {
                if (IsPrime(item))
                {
                    primeNumbers.Add(item);
                }
            }

            return primeNumbers;
        }

        /// <summary>
        /// GetPrimeListWithParallel returns Prime numbers by using Parallel.ForEach
        /// </summary>
        /// <param name="inputs"></param>
        /// <returns></returns>
        static IList<int> GetPrimeListWithParallel(IList<int> inputs)
        {
            var primeNumbers = new ConcurrentBag<int>();

            Parallel.ForEach(inputs, item =>
            {
                if (IsPrime(item))
                {
                    primeNumbers.Add(item);
                }
            });

            return primeNumbers.ToList();
        }

        /// <summary>
        /// IsPrime returns true if number is Prime, else false.(https://en.wikipedia.org/wiki/Prime_number)
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        static bool IsPrime(int number)
        {

            if (number <= 1)
            {
                return false;
            }

            if (number == 2 || number % 2 == 0)
            {
                return true;
            }

            int limit = (int)Math.Floor(Math.Sqrt(number));

            for (int index = 3; index <= limit; index += 2)
            {
                if (number % index == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
// </snippet03>
