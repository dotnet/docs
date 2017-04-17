using System;

public class Class1
{
   public static void Main()
   {
      // <Snippet1>
      var primes = new Tuple<Int32, Int32, Int32, Int32, Int32, Int32, Int32,  
                   Tuple<Int32>> (2, 3, 5, 7, 11, 13, 17, new Tuple<Int32>(19));
      // </Snippet1>
      Console.WriteLine(primes.ToString());
   }
}
