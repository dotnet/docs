// <Snippet1>
using System;

public class Example
{
   public static void Main()
   {
      // Create array of 8-tuple objects containing prime numbers.
      Tuple<Int32, Int32, Int32, Int32, Int32, Int32, Int32, Tuple<Int32>>[] primes = 
                     { new Tuple<Int32, Int32, Int32, Int32, Int32, Int32, Int32, 
                           Tuple<Int32>>(2, 3, 5, 7, 11, 13, 17, new Tuple<Int32>(19)),
                       new Tuple<Int32, Int32, Int32, Int32, Int32, Int32, Int32, 
                           Tuple<Int32>>(23, 29, 31, 37, 41, 43, 47, new Tuple<Int32>(55)), 
                       new Tuple<Int32, Int32, Int32, Int32, Int32, Int32, Int32, 
                           Tuple<Int32>>(3, 2, 5, 7, 11, 13, 17, new Tuple<Int32>(19)) };
      // Display 8-tuples in unsorted order.
      foreach (var prime in primes)
         Console.WriteLine(prime.ToString());
      Console.WriteLine();
      
      // Sort the array and display its 8-tuples.
      Array.Sort(primes);
      foreach (var prime in primes)
         Console.WriteLine(prime.ToString());
   }
}
// The example displays the following output:
//       (2, 3, 5, 7, 11, 13, 17, 19)
//       (23, 29, 31, 37, 41, 43, 47, 55)
//       (3, 2, 5, 7, 11, 13, 17, 19)
//       
//       (2, 3, 5, 7, 11, 13, 17, 19)
//       (3, 2, 5, 7, 11, 13, 17, 19)
//       (23, 29, 31, 37, 41, 43, 47, 55)
// </Snippet1>