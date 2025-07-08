// <Snippet1>
using System;

public class Example
{
   public static void Main()
   {
      float value1 = .1f * 10f;
      float value2 = 0f;
      for (int ctr = 0; ctr < 10; ctr++)
         value2 += .1f;
         
      Console.WriteLine($"{value1:R} = {value2:R}: {HasMinimalDifference(value1, value2, 1)}");
   }

   public static bool HasMinimalDifference(float value1, float value2, int units)
   {
      byte[] bytes = BitConverter.GetBytes(value1);
      int iValue1 = BitConverter.ToInt32(bytes, 0);
      
      bytes = BitConverter.GetBytes(value2);
      int iValue2 = BitConverter.ToInt32(bytes, 0);
      
      // If the signs are different, return false except for +0 and -0.
      if ((iValue1 >> 31) != (iValue2 >> 31))
      {
         if (value1 == value2)
            return true;
          
         return false;
      }

      int diff = Math.Abs(iValue1 - iValue2);

      if (diff <= units)
         return true;

      return false;
   }
}
// The example displays the following output:
//        1 = 1.00000012: True
// </Snippet1>