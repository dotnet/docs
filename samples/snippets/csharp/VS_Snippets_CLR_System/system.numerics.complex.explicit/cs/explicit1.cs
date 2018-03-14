using System;
using System.Numerics;

public class Example
{
   public static void Main()
   {
      FromDecimal();
      Console.WriteLine();
      FromBigInteger();
   }

   private static void FromDecimal()
   {
      // <Snippet1>
      decimal[] numbers = { Decimal.MinValue, -18.35m, 0m, 1893.019m, 
                            Decimal.MaxValue };
      foreach (decimal number in numbers)
      {
         System.Numerics.Complex c1 = (System.Numerics.Complex) number;
         Console.WriteLine("{0,30}  -->  {1}", number, c1);
      }   
      // The example displays the following output:
      //    -79228162514264337593543950335  -->  (-7.92281625142643E+28, 0)
      //                            -18.35  -->  (-18.35, 0)
      //                                 0  -->  (0, 0)
      //                          1893.019  -->  (1893.019, 0)
      //     79228162514264337593543950335  -->  (7.92281625142643E+28, 0)
     // </Snippet1>
   }

   private static void FromBigInteger()
   {
      // <Snippet2>
      BigInteger[] numbers= {
                       ((BigInteger) Double.MaxValue) * 2, 
                       BigInteger.Parse("901345277852317852466891423"), 
                       BigInteger.One }; 
      foreach (BigInteger number in numbers)
      {
        Complex c1 = (Complex) number;
         Console.WriteLine(c1);
      }        
      // The example displays the following output:
      //       (Infinity, 0)
      //       (9.01345277852318E+26, 0)
      //       (1, 0)      
      // </Snippet2>                            
   }
}
