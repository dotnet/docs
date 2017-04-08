// <Snippet1>
using System;

public class Example
{
   public static void Main()
   {
      double value1 = .1 * 10;
      double value2 = 0;
      for (int ctr = 0; ctr < 10; ctr++)
         value2 += .1;
         
      Console.WriteLine("{0:R} = {1:R}: {2}", value1, value2,
                        HasMinimalDifference(value1, value2, 1));
   }

   public static bool HasMinimalDifference(double value1, double value2, int units)
   {
      long lValue1 = BitConverter.DoubleToInt64Bits(value1);
      long lValue2 = BitConverter.DoubleToInt64Bits(value2);
      
      // If the signs are different, return false except for +0 and -0.
      if ((lValue1 >> 63) != (lValue2 >> 63))
      {
         if (value1 == value2)
            return true;
          
         return false;
      }

      long diff = Math.Abs(lValue1 - lValue2);

      if (diff <= (long) units)
         return true;

      return false;
   }
}
// The example displays the following output:
//        01 = 0.99999999999999989: True
// </Snippet1>