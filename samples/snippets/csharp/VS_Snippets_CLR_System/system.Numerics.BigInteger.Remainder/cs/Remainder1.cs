// <Snippet1>
using System;
using System.Numerics;

public class Example
{
   public static void Main()
   {
      BigInteger dividend1 = BigInteger.Pow(Int64.MaxValue, 3);
      BigInteger dividend2 = dividend1 * BigInteger.MinusOne;
      BigInteger divisor1 = Int32.MaxValue;
      BigInteger divisor2 = divisor1 * BigInteger.MinusOne;
      BigInteger remainder1, remainder2;
      BigInteger divRem1 = BigInteger.Zero;
      BigInteger divRem2 = BigInteger.Zero;
       
      remainder1 = BigInteger.Remainder(dividend1, divisor1);
      remainder2 = BigInteger.Remainder(dividend2, divisor1);

      BigInteger.DivRem(dividend1, divisor1, out divRem1);
      Console.WriteLine("BigInteger.Remainder({0}, {1}) = {2}", 
                        dividend1, divisor1, remainder1);
      Console.WriteLine("BigInteger.DivRem({0}, {1}) = {2}", 
                        dividend1, divisor1, divRem1);                    
      if (remainder1.Equals(divRem1))
         Console.WriteLine("The remainders are equal.\n");
      
      BigInteger.DivRem(dividend2, divisor2, out divRem2);
      Console.WriteLine("BigInteger.Remainder({0}, {1}) = {2}", 
                        dividend2, divisor2, remainder2);
      Console.WriteLine("BigInteger.DivRem({0}, {1}) = {2}", 
                        dividend2, divisor2, divRem2);                    
      if (remainder2.Equals(divRem2))
         Console.WriteLine("The remainders are equal.\n");
   }
}
// The example displays the following output:
//    BigInteger.Remainder(7.8463771692333509522426190271E+56, 2147483647) = 1
//    BigInteger.DivRem(7.8463771692333509522426190271E+56, 2147483647) = 1
//    The remainders are equal.
//    
//    BigInteger.Remainder(-7.8463771692333509522426190271E+56, -2147483647) = -1
//    BigInteger.DivRem(-7.8463771692333509522426190271E+56, -2147483647) = -1
//    The remainders are equal.
// </Snippet1>