// <Snippet3>
using System;

public class Example
{
   public static void Main()
   {
      string surrogate = "\uD800\uDC03";
      for (int ctr = 0; ctr < surrogate.Length; ctr++) 
         Console.Write("U+{0:X2} ", Convert.ToUInt16(surrogate[ctr]));

      Console.WriteLine();
      Console.WriteLine("   Is Surrogate Pair: {0}", 
                        Char.IsSurrogatePair(surrogate[0], surrogate[1]));
   }
}
// The example displays the following output:
//       U+D800 U+DC03
//          Is Surrogate Pair: True
// </Snippet3>         