using System;

public class Example18
{
   public static void Main()
   {
      // <Snippet3>
      string surrogate = "\uD800\uDC03";
      for (int ctr = 0; ctr < surrogate.Length; ctr++) 
         Console.Write($"U+{(ushort)surrogate[ctr]:X2} ");

      Console.WriteLine();
      Console.WriteLine($"   Is Surrogate Pair: {Char.IsSurrogatePair(surrogate[0], surrogate[1])}");
      // The example displays the following output:
      //       U+D800 U+DC03
      //          Is Surrogate Pair: True
      // </Snippet3>
   }
}
