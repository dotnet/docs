// <Snippet2>
using System;
using System.Collections.Generic;

public class Example
{
   public static void Main()
   {
      int maxPrime = 100;
      IEnumerable<String> primeList = GetPrimes(maxPrime);
      Console.WriteLine("Primes less than {0}:", maxPrime);
      Console.WriteLine("   {0}", String.Concat(primeList));
   }

   private static IEnumerable<String> GetPrimes(int maxPrime)
   {
      Array values = Array.CreateInstance(typeof(int), 
                              new int[] { maxPrime - 1}, new int[] { 2 }); 
      // Use Sieve of Erathsthenes to determine prime numbers.
      for (int ctr = values.GetLowerBound(0); ctr <= (int) Math.Ceiling(Math.Sqrt(values.GetUpperBound(0))); ctr++)
      {
                           
         if ((int) values.GetValue(ctr) == 1) continue;
         
         for (int multiplier = ctr; multiplier <=  maxPrime / 2; multiplier++)
            if (ctr * multiplier <= maxPrime)
               values.SetValue(1, ctr * multiplier);
      }      
      
      List<String> primes = new List<String>();
      for (int ctr = values.GetLowerBound(0); ctr <= values.GetUpperBound(0); ctr++)
         if ((int) values.GetValue(ctr) == 0) 
            primes.Add(ctr.ToString() + " ");
      return primes;
   }   
}
// The example displays the following output:
//    Primes less than 100:
//       2 3 5 7 11 13 17 19 23 29 31 37 41 43 47 53 59 61 67 71 73 79 83 89 97
// </Snippet2>
