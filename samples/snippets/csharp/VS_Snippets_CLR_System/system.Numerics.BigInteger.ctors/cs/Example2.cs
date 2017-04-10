using System;
using System.Numerics;

public class Example
{
   public static void Main()
   {
      DecimalConstructor();
      Console.WriteLine("-----");
      DoubleConstructor();
      Console.WriteLine("-----");
      IntegerConstructor();
      Console.WriteLine("-----");
      LongConstructor();
      Console.WriteLine("-----");
      SingleConstructor();
      Console.WriteLine("-----");
      UInt32Constructor();
      Console.WriteLine("-----");
      UInt64Constructor();     
   }

   private static void DecimalConstructor()
   {
      // <Snippet4>
      decimal[] decimalValues = { -1790.533m, -15.1514m, 18903.79m, 9180098.003m };
      foreach (decimal decimalValue in decimalValues)
      {
         BigInteger number = new BigInteger(decimalValue);
         Console.WriteLine("Instantiated BigInteger value {0} from the Decimal value {1}.",
                           number, decimalValue);
      }                 
      // The example displays the following output:
      //    Instantiated BigInteger value -1790 from the Decimal value -1790.533.
      //    Instantiated BigInteger value -15 from the Decimal value -15.1514.
      //    Instantiated BigInteger value 18903 from the Decimal value 18903.79.
      //    Instantiated BigInteger value 9180098 from the Decimal value 9180098.003.
      // </Snippet4>
   }

   private static void DoubleConstructor()
   {
      // <Snippet5>
      // Create a BigInteger from a large double value.
      double doubleValue = -6e20;
      BigInteger bigIntValue = new BigInteger(doubleValue);
      Console.WriteLine("Original Double value: {0:N0}", doubleValue);
      Console.WriteLine("Original BigInteger value: {0:N0}", bigIntValue);
      // Increment and then display both values.
      doubleValue++;
      bigIntValue += BigInteger.One;
      Console.WriteLine("Incremented Double value: {0:N0}", doubleValue);
      Console.WriteLine("Incremented BigInteger value: {0:N0}", bigIntValue);
      // The example displays the following output:
      //    Original Double value: -600,000,000,000,000,000,000
      //    Original BigInteger value: -600,000,000,000,000,000,000
      //    Incremented Double value: -600,000,000,000,000,000,000
      //    Incremented BigInteger value: -599,999,999,999,999,999,999
      // </Snippet5>   
   }

   private static void IntegerConstructor()
   {
      // <Snippet6>
      int[] integers = { Int32.MinValue, -10534, -189, 0, 17, 113439,
                         Int32.MaxValue };
      BigInteger constructed, assigned;
      
      foreach (int number in integers)
      {
         constructed = new BigInteger(number);
         assigned = number;
         Console.WriteLine("{0} = {1}: {2}", constructed, assigned, 
                           constructed.Equals(assigned)); 
      }                                                  
      // The example displays the following output:
      //       -2147483648 = -2147483648: True
      //       -10534 = -10534: True
      //       -189 = -189: True
      //       0 = 0: True
      //       17 = 17: True
      //       113439 = 113439: True
      //       2147483647 = 2147483647: True      
      // </Snippet6>
   }
   private static void LongConstructor()
   {
      // <Snippet7>
      long[] longs = { Int64.MinValue, -10534, -189, 0, 17, 113439,
                       Int64.MaxValue };
      BigInteger constructed, assigned;
      
      foreach (long number in longs)
      {
         constructed = new BigInteger(number);
         assigned = number;
         Console.WriteLine("{0} = {1}: {2}", constructed, assigned, 
                           constructed.Equals(assigned)); 
      }                                                  
      // The example displays the following output:
      //       -2147483648 = -2147483648: True
      //       -10534 = -10534: True
      //       -189 = -189: True
      //       0 = 0: True
      //       17 = 17: True
      //       113439 = 113439: True
      //       2147483647 = 2147483647: True      
      // </Snippet7>
   }

   private static void SingleConstructor()
   {
      // <Snippet8>
      // Create a BigInteger from a large negative Single value
      float negativeSingle = Single.MinValue;
      BigInteger negativeNumber = new BigInteger(negativeSingle);
      
      Console.WriteLine(negativeSingle.ToString("N0"));
      Console.WriteLine(negativeNumber.ToString("N0"));
      
      negativeSingle++;
      negativeNumber++;
      
      Console.WriteLine(negativeSingle.ToString("N0"));
      Console.WriteLine(negativeNumber.ToString("N0"));
      // The example displays the following output:
      //       -340,282,300,000,000,000,000,000,000,000,000,000,000
      //       -340,282,346,638,528,859,811,704,183,484,516,925,440
      //       -340,282,300,000,000,000,000,000,000,000,000,000,000
      //       -340,282,346,638,528,859,811,704,183,484,516,925,439
      // </Snippet8>
   }

   private static void UInt32Constructor()
   {
      // <Snippet9>
      uint[] unsignedValues = { 0, 16704, 199365, UInt32.MaxValue };
      foreach (uint unsignedValue in unsignedValues)
      {
         BigInteger constructedNumber = new BigInteger(unsignedValue);
         BigInteger assignedNumber = unsignedValue;
         if (constructedNumber.Equals(assignedNumber))
            Console.WriteLine("Both methods create a BigInteger whose value is {0:N0}.",
                              constructedNumber);
         else
            Console.WriteLine("{0:N0} ≠ {1:N0}", constructedNumber, assignedNumber);

      }
      // The example displays the following output:
      //    Both methods create a BigInteger whose value is 0.
      //    Both methods create a BigInteger whose value is 16,704.
      //    Both methods create a BigInteger whose value is 199,365.
      //    Both methods create a BigInteger whose value is 4,294,967,295.
      // </Snippet9>
   }

   private static void UInt64Constructor()
   {
      // <Snippet10>
      ulong unsignedValue = UInt64.MaxValue;
      BigInteger number = new BigInteger(unsignedValue);
      Console.WriteLine(number.ToString("N0"));       
      // The example displays the following output:
      //       18,446,744,073,709,551,615      
      // </Snippet10>   
   }
}
