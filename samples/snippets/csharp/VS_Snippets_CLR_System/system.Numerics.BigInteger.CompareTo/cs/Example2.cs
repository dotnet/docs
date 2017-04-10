using System;
using System.Numerics;

public class Example
{
   public static void Main()
   {
      CompareToLong();
      Console.WriteLine("-----");
      CompareToObject();
   }

   private static void CompareToLong()
   {
      // <Snippet3>
      BigInteger bigIntValue = BigInteger.Parse("3221123045552");

      byte byteValue = 16;
      sbyte sbyteValue = -16;
      short shortValue = 1233;      
      ushort ushortValue = 1233;
      int intValue = -12233;
      uint uintValue = 12233;
      long longValue = 12382222;
      ulong ulongValue = 1238222;

      Console.WriteLine("Comparing {0} with {1}: {2}", 
                        bigIntValue, byteValue, 
                        bigIntValue.CompareTo(byteValue));
      Console.WriteLine("Comparing {0} with {1}: {2}", 
                        bigIntValue, sbyteValue, 
                        bigIntValue.CompareTo(sbyteValue)); 
      Console.WriteLine("Comparing {0} with {1}: {2}", 
                        bigIntValue, shortValue, 
                        bigIntValue.CompareTo(shortValue));
      Console.WriteLine("Comparing {0} with {1}: {2}", 
                        bigIntValue, ushortValue, 
                        bigIntValue.CompareTo(ushortValue)); 
      Console.WriteLine("Comparing {0} with {1}: {2}", 
                        bigIntValue, intValue, 
                        bigIntValue.CompareTo(intValue));
      Console.WriteLine("Comparing {0} with {1}: {2}", 
                        bigIntValue, uintValue, 
                        bigIntValue.CompareTo(uintValue)); 
      Console.WriteLine("Comparing {0} with {1}: {2}", 
                        bigIntValue, longValue, 
                        bigIntValue.CompareTo(longValue));
      Console.WriteLine("Comparing {0} with {1}: {2}", 
                        bigIntValue, ulongValue, 
                        bigIntValue.CompareTo(ulongValue));
      // The example displays the following output:
      //       Comparing 3221123045552 with 16: 1
      //       Comparing 3221123045552 with -16: 1
      //       Comparing 3221123045552 with 1233: 1
      //       Comparing 3221123045552 with 1233: 1
      //       Comparing 3221123045552 with -12233: 1
      //       Comparing 3221123045552 with 12233: 1
      //       Comparing 3221123045552 with 12382222: 1
      //       Comparing 3221123045552 with 1238222: 1
      // </Snippet3>
   }   

   private static void CompareToObject()
   {
      // <Snippet4>
      object[] values = { BigInteger.Pow(Int64.MaxValue, 10), null, 
                          12.534, Int64.MaxValue, BigInteger.One };
      BigInteger number = UInt64.MaxValue;
      
      foreach (object value in values)
      {
         try {
            Console.WriteLine("Comparing {0} with '{1}': {2}", number, value, 
                              number.CompareTo(value));
         }
         catch (ArgumentException) {
            Console.WriteLine("Unable to compare the {0} value {1} with a BigInteger.",
                              value.GetType().Name, value);
         }
      }                                 
      // The example displays the following output:
      //    Comparing 18446744073709551615 with '4.4555084156466750133735972424E+189': -1
      //    Comparing 18446744073709551615 with '': 1
      //    Unable to compare the Double value 12.534 with a BigInteger.
      //    Unable to compare the Int64 value 9223372036854775807 with a BigInteger.
      //    Comparing 18446744073709551615 with '1': 1
      // </Snippet4>
   }
}
