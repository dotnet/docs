// <Snippet3>
using System;
using System.Reflection;

class Example1
{
    public static void Main()
    {
        int limit = 10000000;
        PrimeNumberGenerator primes = new PrimeNumberGenerator(limit);
        int start = 1000001;
        try
        {
            int[] values = primes.GetPrimesFrom(start);
            Console.WriteLine($"There are {start} prime numbers from {limit} to {2}");
        }
        catch (NotPrimeException e)
        {
            Console.WriteLine($"{e.NonPrime} is not prime");
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
            Console.WriteLine($"{e.NonPrime} is not prime");
            Console.WriteLine(e);
            Console.WriteLine("--------");
        }
    }
}
// </Snippet3>
