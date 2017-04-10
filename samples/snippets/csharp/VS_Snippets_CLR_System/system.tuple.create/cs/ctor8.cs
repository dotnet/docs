using System;

public class Example
{
   public static void Main()
   {
      // <Snippet20>
      var primes = new Tuple<int, int, int, int, int, int, int, 
                       Tuple<int>>(2, 3, 5, 7, 11, 13, 16, 
                       new Tuple<int>(19));
      // </Snippet20>
      Console.WriteLine(primes.ToString());
   }
}
