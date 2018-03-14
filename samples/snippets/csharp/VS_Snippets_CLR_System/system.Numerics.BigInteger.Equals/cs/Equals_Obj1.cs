// <Snippet3>
using System;
using System.Numerics;

public class Example
{
   public static void Main()
   {
      object[] obj = { 0, 10, 100, new BigInteger(1000), -10 };
      BigInteger[] bi = { BigInteger.Zero, new BigInteger(10),
                          new BigInteger(100), new BigInteger(1000),
                          new BigInteger(-10) };
      for (int ctr = 0; ctr < bi.Length; ctr++)
         Console.WriteLine(bi[ctr].Equals(obj[ctr]));
   }
}
// The example displays the following output:
//       False
//       False
//       False
//       True
//       False
// </Snippet3>
