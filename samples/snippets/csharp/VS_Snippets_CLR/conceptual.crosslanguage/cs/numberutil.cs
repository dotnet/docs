// <Snippet2>
using System;

public static class NumericLib
{
   public static bool IsEven(this IConvertible number)
   {
      if (number is Byte ||
          number is SByte ||
          number is Int16 ||
          number is UInt16 ||
          number is Int32 ||
          number is UInt32 ||
          number is Int64)
         return Convert.ToInt64(number) % 2 == 0;
      else if (number is UInt64)
         return ((ulong) number) % 2 == 0;
      else
         throw new NotSupportedException("IsEven called for a non-integer value.");
   }

   public static bool NearZero(double number)
   {
      return Math.Abs(number) < .00001;
   }
}
// </Snippet2>

public class Example
{
   public static void Main()
   {
      Console.WriteLine(3.IsEven());
      int value = 3;
      Console.WriteLine(value.IsEven());
      ulong uvalue = 3;
      Console.WriteLine(uvalue.IsEven());
      Console.WriteLine(NumericLib.NearZero(-.000001));
   }
}