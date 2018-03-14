using System;
using System.Numerics;

public class Class1
{
   public static void Main()
   {
      ExplicitFromDecimal();
      Console.WriteLine();
      ExplicitFromDouble();
      Console.WriteLine();
      ExplicitFromSingle();
      Console.WriteLine();
      DoublePrecision();
      Console.WriteLine();
      SinglePrecision();
   }

   private static void ExplicitFromDecimal()
   {
      // Explicit Decimal to BigInteger conversion
      // <Snippet1>
      decimal[] decimals = { Decimal.MinValue, -15632.991m, 9029321.12m, 
                             Decimal.MaxValue };
      BigInteger number; 
      
      Console.WriteLine("{0,35} {1,35}\n", "Decimal", "BigInteger");

      foreach (decimal value in decimals)
      {
         number = (BigInteger) value;
         Console.WriteLine("{0,35} {1,35}", value, number);
      }
      // The example displays the following output:
      //
      //                          Decimal                          BigInteger
      //    
      //    -79228162514264337593543950335      -79228162514264337593543950335
      //                       -15632.991                              -15632
      //                       9029321.12                             9029321
      //    79228162514264337593543950335       79228162514264337593543950335
      // </Snippet1>      
   }

   private static void ExplicitFromDouble()
   {
      // <Snippet2>
      double[] doubles = { Double.MinValue, -1.430955172e03, 2.410970032e05, 
                           Double.MaxValue, Double.PositiveInfinity, 
                           Double.NegativeInfinity, Double.NaN };
      BigInteger number;
      
      Console.WriteLine("{0,37} {1,37}\n", "Double", "BigInteger");

      foreach (double value in doubles)
      {
         try {
            number = (BigInteger) value;
            Console.WriteLine("{0,37} {1,37}", value, number);
         }   
         catch (OverflowException) {
            Console.WriteLine("{0,37} {1,37}", value, "OverflowException");
         }
      }
      // The example displays the following output:
      //                                Double                            BigInteger
      // 
      //                -1.79769313486232E+308  -1.7976931348623157081452742373E+308
      //                          -1430.955172                                 -1430
      //                           241097.0032                                241097
      //                 1.79769313486232E+308   1.7976931348623157081452742373E+308
      //                              Infinity                     OverflowException
      //                             -Infinity                     OverflowException
      //                                   NaN                     OverflowException      
      // </Snippet2>      
   }

   private static void ExplicitFromSingle()
   {
      // <Snippet3>
      float[] singles = { Single.MinValue, -1.430955172e03f, 2.410970032e05f, 
                          Single.MaxValue, Single.PositiveInfinity, 
                           Single.NegativeInfinity, Single.NaN };
      BigInteger number;
      
      Console.WriteLine("{0,37} {1,37}\n", "Single", "BigInteger");

      foreach (float value in singles)
      {
         try {
            number = (BigInteger) value;
            Console.WriteLine("{0,37} {1,37}", value, number);
         }   
         catch (OverflowException) {
            Console.WriteLine("{0,37} {1,37}", value, "OverflowException");
         }
      }
      // The example displays the following output:
      //           Single                            BigInteger
      // 
      //    -3.402823E+38   -3.4028234663852885981170418348E+38
      //        -1430.955                                 -1430
      //           241097                                241097
      //     3.402823E+38    3.4028234663852885981170418348E+38
      //         Infinity                     OverflowException
      //        -Infinity                     OverflowException
      //              NaN                     OverflowException      
      // </Snippet3>
   }

   private static void DoublePrecision()
   {
      // <Snippet4>
      // Increase a BigInteger so it exceeds Double.MaxValue.
      BigInteger number1 = (BigInteger) Double.MaxValue;
      BigInteger number2 = number1;
      number2 = number2 + (BigInteger) 9.999e291;
      // Compare the BigInteger values for equality.
      Console.WriteLine("BigIntegers equal: {0}", number2.Equals(number1));
      
      // Convert the BigInteger to a Double.
      double dbl = (double) number2;
      
      // Display the two values.
      Console.WriteLine("BigInteger: {0}", number2);
      Console.WriteLine("Double:     {0}", dbl); 
      // The example displays the following output:
      //       BigIntegers equal: False
      //       BigInteger: 1.7976931348623158081352742373E+308
      //       Double:     1.79769313486232E+308      
      // </Snippet4>
   }

   private static void SinglePrecision()
   {
      Console.WriteLine(Single.MaxValue);
      // <Snippet5>
      // Increase a BigInteger so it exceeds Single.MaxValue.
      BigInteger number1 = (BigInteger) Single.MaxValue;
      BigInteger number2 = number1;
      number2 = number2 + (BigInteger) 9.999e30;
      // Compare the BigInteger values for equality.
      Console.WriteLine("BigIntegers equal: {0}", number2.Equals(number1));
      
      // Convert the BigInteger to a Single.
      float sng = (float) number2;
      
      // Display the two values.
      Console.WriteLine("BigInteger: {0}", number2);
      Console.WriteLine("Single:     {0}", sng); 
      // The example displays the following output:
      //       BigIntegers equal: False
      //       BigInteger: 3.4028235663752885981170396038E+38
      //       Single:     3.402823E+38
      // </Snippet5>
   }
}