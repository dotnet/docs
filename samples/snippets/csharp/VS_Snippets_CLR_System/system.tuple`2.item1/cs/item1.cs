// <Snippet1>
using System;

public class Class1
{
   public static void Main()
   {
      int dividend, divisor;
      Tuple<int, int> result;
      
      dividend = 136945; divisor = 178;
      result = IntegerDivide(dividend, divisor);
      if (result != null)
         Console.WriteLine(@"{0} \ {1} = {2}, remainder {3}", 
                           dividend, divisor, result.Item1, result.Item2);
      else
         Console.WriteLine(@"{0} \ {1} = <Error>", dividend, divisor);
                        
      dividend = Int32.MaxValue; divisor = -2073;
      result = IntegerDivide(dividend, divisor);
      if (result != null)
         Console.WriteLine(@"{0} \ {1} = {2}, remainder {3}", 
                           dividend, divisor, result.Item1, result.Item2);
      else
         Console.WriteLine(@"{0} \ {1} = <Error>", dividend, divisor);
   }

   private static Tuple<int, int> IntegerDivide(int dividend, int divisor)
   {
      try {
         int remainder;
         int quotient = Math.DivRem(dividend, divisor, out remainder);
         return new Tuple<int, int>(quotient, remainder);
      }   
      catch (DivideByZeroException) {
         return null;
      }      
   }
}
// The example displays the following output:
//       136945 \ 178 = 769, remainder 63
//       2147483647 \ -2073 = -1035930, remainder 757
// </Snippet1>