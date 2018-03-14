
// <Snippet10>
using System;
using System.Numerics;

[assembly: CLSCompliant(true)]

public class Numbers
{
   public static byte[] GetSquares(byte[] numbers)
   {
      byte[] numbersOut = new byte[numbers.Length];
      for (int ctr = 0; ctr < numbers.Length; ctr++) {
         int square = ((int) numbers[ctr]) * ((int) numbers[ctr]); 
         if (square <= Byte.MaxValue)
            numbersOut[ctr] = (byte) square;
         // If there's an overflow, assign MaxValue to the corresponding 
         // element.
         else
            numbersOut[ctr] = Byte.MaxValue;

      }
      return numbersOut;
   }

   public static BigInteger[] GetSquares(BigInteger[] numbers)
   {
      BigInteger[] numbersOut = new BigInteger[numbers.Length];
      for (int ctr = 0; ctr < numbers.Length; ctr++)
         numbersOut[ctr] = numbers[ctr] * numbers[ctr]; 

      return numbersOut;
   }
}
// </Snippet10>

public class Example
{
   public static void Main()
   {
       Byte[] bytes = Numbers.GetSquares( new Byte[] { (byte) 3, (byte) 10, 
                                                       (byte) 13, (byte) 20 } ); 
       foreach (var byt in bytes)
          Console.Write("{0}  ", byt);

       Console.WriteLine();
       BigInteger[] bigs = new BigInteger[] { 1034, 1058, 100, 12399 };
       foreach (var bigSquare in Numbers.GetSquares(bigs))
          Console.Write("{0:N0}  ", bigSquare);

       Console.WriteLine();
   }
}

