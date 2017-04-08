// <Snippet3>
using System;
using System.Reflection;

class Example
{
   public static void Main()
   {
      int limit = 10000000;
      PrimeNumberGenerator primes = new PrimeNumberGenerator(limit);
      int start = 1000001;
      try
      {
         int[] values = primes.GetPrimesFrom(start);
         Console.WriteLine("There are {0} prime numbers from {1} to {2}",
                           start, limit);
      }
      catch (NotPrimeException e)
      {
         Console.WriteLine("{0} is not prime", e.NonPrime);
         Console.WriteLine(e);
         Console.WriteLine("--------");
      }

      AppDomain domain = AppDomain.CreateDomain("Domain2");
      PrimeNumberGenerator gen = (PrimeNumberGenerator)domain.CreateInstanceAndUnwrap(
                                        typeof(Example).Assembly.FullName,
                                        "PrimeNumberGenerator", true,
                                        BindingFlags.Default, null,
                                        new object[] { 1000000 }, null, null);
      try
      {
         start = 100;
         Console.WriteLine(gen.GetPrimesFrom(start));
      }
      catch (NotPrimeException e)
      {
         Console.WriteLine("{0} is not prime", e.NonPrime);
         Console.WriteLine(e);
         Console.WriteLine("--------");
      }
   }
}
// </Snippet3>
