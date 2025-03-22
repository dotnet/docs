// <Snippet13>
using System;
using System.Threading;

public class Example16
{
    public static void Main()
    {
        Console.WriteLine("Instantiating two random number generators...");
        Random rnd1 = new Random();
        Thread.Sleep(2000);
        Random rnd2 = new Random();

        Console.WriteLine("\nThe first random number generator:");
        for (int ctr = 1; ctr <= 10; ctr++)
            Console.WriteLine($"   {rnd1.Next()}");

        Console.WriteLine("\nThe second random number generator:");
        for (int ctr = 1; ctr <= 10; ctr++)
            Console.WriteLine($"   {rnd2.Next()}");
    }
}
// The example displays output like the following:
//       Instantiating two random number generators...
//
//       The first random number generator:
//          643164361
//          1606571630
//          1725607587
//          2138048432
//          496874898
//          1969147632
//          2034533749
//          1840964542
//          412380298
//          47518930
//
//       The second random number generator:
//          1251659083
//          1514185439
//          1465798544
//          517841554
//          1821920222
//          195154223
//          1538948391
//          1548375095
//          546062716
//          897797880
// </Snippet13>
