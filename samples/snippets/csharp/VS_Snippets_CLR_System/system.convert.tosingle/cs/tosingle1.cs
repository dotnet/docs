using System;

public class Example
{
   public static void Main()
   {
      ConvertBoolean();
      Console.WriteLine("-----");
      ConvertByte();
      Console.WriteLine("-----");
      ConvertDecimal();
      Console.WriteLine("-----");
      ConvertDouble();
      Console.WriteLine("-----");
      ConvertInt16();
      Console.WriteLine("-----");
      ConvertInt32();
      Console.WriteLine("-----");
      ConvertInt64();
      Console.WriteLine("-----");
      ConvertObject();
      Console.WriteLine("-----");
      ConvertSByte();
      Console.WriteLine("-----");
      ConvertString();
      Console.WriteLine("----");
      ConvertUInt16();
      Console.WriteLine("-----");
      ConvertUInt32();
      Console.WriteLine("------");
      ConvertUInt64();
   }

   private static void ConvertBoolean()
   {
      // <Snippet1>
      bool[] flags = { true, false };
      float result;
      
      foreach (bool flag in flags)
      {
         result = Convert.ToSingle(flag);
         Console.WriteLine("Converted {0} to {1}.", flag, result);
      }
      // The example displays the following output:
      //       Converted True to 1.
      //       Converted False to 0.      
      // </Snippet1>
   }

   private static void ConvertByte()
   {
      // <Snippet2>
      byte[] numbers = { Byte.MinValue, 10, 100, Byte.MaxValue };
      float result;
      
      foreach (byte number in numbers)
      {
         result = Convert.ToSingle(number);
         Console.WriteLine("Converted the {0} value {1} to the {2} value {3}.",
                           number.GetType().Name, number,
                           result.GetType().Name, result);
      }
      // The example displays the following output:
      //       Converted the Byte value 0 to the Single value 0.
      //       Converted the Byte value 10 to the Single value 10.
      //       Converted the Byte value 100 to the Single value 100.
      //       Converted the Byte value 255 to the Single value 255.
      // </Snippet2>
   }

   private static void ConvertDecimal()
   {
      // <Snippet3>
      decimal[] values = { Decimal.MinValue, -1034.23m, -12m, 0m, 147m, 
                                  199.55m, 9214.16m, Decimal.MaxValue };
      float result;
      
      foreach (float value in values)
      {
         result = Convert.ToSingle(value);
         Console.WriteLine("Converted the {0} value '{1}' to the {2} value {3}.",
                           value.GetType().Name, value,
                           result.GetType().Name, result);
      }                                  
      // The example displays the following output:
      //    Converted the Decimal value '-79228162514264337593543950335' to the Single value -7.922816E+28.
      //    Converted the Decimal value '-1034.23' to the Single value -1034.23.
      //    Converted the Decimal value '-12' to the Single value -12.
      //    Converted the Decimal value '0' to the Single value 0.
      //    Converted the Decimal value '147' to the Single value 147.
      //    Converted the Decimal value '199.55' to the Single value 199.55.
      //    Converted the Decimal value '9214.16' to the Single value 9214.16.
      //    Converted the Decimal value '79228162514264337593543950335' to the Single value 7.922816E+28.
      // </Snippet3>
   }
   
   private static void ConvertDouble()
   {
      // <Snippet4>
      double[] values = { Double.MinValue, -1.38e10, -1023.299, -12.98, 
                          0, 9.113e-16, 103.919, 17834.191, Double.MaxValue };
      float result;
      
      foreach (double value in values)
      {
         result = Convert.ToSingle(value);
         Console.WriteLine("Converted the {0} value '{1}' to the {2} value {3}.", 
                           value.GetType().Name, value, 
                           result.GetType().Name, result);
      }                                 
      // The example displays the following output:
      //    Converted the Double value '-1.79769313486232E+308' to the Single value -Infinity.
      //    Converted the Double value '-13800000000' to the Single value -1.38E+10.
      //    Converted the Double value '-1023.299' to the Single value -1023.299.
      //    Converted the Double value '-12.98' to the Single value -12.98.
      //    Converted the Double value '0' to the Single value 0.
      //   Converted the Double value '9.113E-16' to the Single value 9.113E-16.
      //    Converted the Double value '103.919' to the Single value 103.919.
      //    Converted the Double value '17834.191' to the Single value 17834.19.
      //    Converted the Double value '1.79769313486232E+308' to the Single value Infinity.
      // </Snippet4>
   }

   private static void ConvertInt16()
   {
      // <Snippet5>
      short[] numbers = { Int16.MinValue, -1032, 0, 192, Int16.MaxValue };
      float result;
      
      foreach (short number in numbers)
      {
         result = Convert.ToSingle(number);
         Console.WriteLine("Converted the {0} value '{1}' to the {2} value {3}.", 
                           number.GetType().Name, number, 
                           result.GetType().Name, result);

      }                     
      // The example displays the following output:
      //    Converted the Int16 value '-32768' to the Single value -32768.
      //    Converted the Int16 value '-1032' to the Single value -1032.
      //    Converted the Int16 value '0' to the Single value 0.
      //    Converted the Int16 value '192' to the Single value 192.
      //    Converted the Int16 value '32767' to the Single value 32767.
      // </Snippet5>
   }
   
   private static void ConvertInt32()
   {
      // <Snippet6>
      int[] numbers = { Int32.MinValue, -1000, 0, 1000, Int32.MaxValue };
      float result;
      
      foreach (int number in numbers)
      {
         result = Convert.ToSingle(number);
         Console.WriteLine("Converted the {0} value '{1}' to the {2} value {3}.", 
                           number.GetType().Name, number, 
                           result.GetType().Name, result);

      }
      // The example displays the following output:
      //    Converted the Int32 value '-2147483648' to the Single value -2.147484E+09.
      //    Converted the Int32 value '-1000' to the Single value -1000.
      //    Converted the Int32 value '0' to the Single value 0.
      //    Converted the Int32 value '1000' to the Single value 1000.
      //    Converted the Int32 value '2147483647' to the Single value 2.147484E+09.
      // </Snippet6>
   }

   private static void ConvertInt64()
   {
      // <Snippet7>
      long[] numbers = { Int64.MinValue, -903, 0, 172, Int64.MaxValue};
      double result;
      
      foreach (long number in numbers)
      {
         result = Convert.ToDouble(number);
         Console.WriteLine("Converted the {0} value '{1}' to the {2} value {3}.", 
                           number.GetType().Name, number, 
                           result.GetType().Name, result);

      }
      // The example displays the following output:
      //    Converted the Int64 value '-9223372036854775808' to the Single value -9.223372E+18.
      //    Converted the Int64 value '-903' to the Single value -903.
      //    Converted the Int64 value '0' to the Single value 0.
      //    Converted the Int64 value '172' to the Single value 172.
      //    Converted the Int64 value '9223372036854775807' to the Single value 9.223372E+18.
      // </Snippet7>
   }
   
   private static void ConvertObject()
   {
      // <Snippet8>
      object[] values = { true, 'a', 123, 1.764e32, "9.78", "1e-02",
                          1.67e03, "A100", "1,033.67", DateTime.Now,
                          Decimal.MaxValue };   
      float result;
      
      foreach (object value in values)
      {
         try {
            result = Convert.ToSingle(value);
            Console.WriteLine("Converted the {0} value '{1}' to the {2} value {3}.", 
                              value.GetType().Name, value, 
                              result.GetType().Name, result);
         }
         catch (FormatException) {
            Console.WriteLine("The {0} value {1} is not recognized as a valid Single value.",
                              value.GetType().Name, value);
         }                     
         catch (OverflowException) {
            Console.WriteLine("The {0} value {1} is outside the range of the Single type.",
                              value.GetType().Name, value);
         }
         catch (InvalidCastException) {
            Console.WriteLine("Conversion of the {0} value {1} to a Single is not supported.",
                              value.GetType().Name, value);
         }                     
      }
      // The example displays the following output:
      //    Converted the Boolean value 'True' to the Single value 1.
      //    Conversion of the Char value a to a Single is not supported.
      //    Converted the Int32 value '123' to the Single value 123.
      //    Converted the Double value '1.764E+32' to the Single value 1.764E+32.
      //    Converted the String value '9.78' to the Single value 9.78.
      //    Converted the String value '1e-02' to the Single value 0.01.
      //    Converted the Double value '1670' to the Single value 1670.
      //    The String value A100 is not recognized as a valid Single value.
      //    Converted the String value '1,033.67' to the Single value 1033.67.
      //    Conversion of the DateTime value 11/7/2008 08:02:35 AM to a Single is not supported.
      //    Converted the Decimal value '79228162514264337593543950335' to the Single value 7.922816E+28.
      // </Snippet8>
   }   
   
   private static void ConvertSByte()
   {
      // <Snippet9>
      sbyte[] numbers = { SByte.MinValue, -23, 0, 17, SByte.MaxValue };
      float result;
      
      foreach (sbyte number in numbers)
      {
         result = Convert.ToSingle(number);
         Console.WriteLine("Converted the {0} value '{1}' to the {2} value {3}.", 
                           number.GetType().Name, number, 
                           result.GetType().Name, result);

      }
      // The example displays the following output:
      //    Converted the SByte value '-128' to the Single value -128.
      //    Converted the SByte value '-23' to the Single value -23.
      //    Converted the SByte value '0' to the Single value 0.
      //    Converted the SByte value '17' to the Single value 17.
      //    Converted the SByte value '127' to the Single value 127.
      // </Snippet9>
   }

   private static void ConvertString()
   {
      // <Snippet10>
      string[] values= { "-1,035.77219", "1AFF", "1e-35", "1.63f",
                         "1,635,592,999,999,999,999,999,999", "-17.455", 
                         "190.34001", "1.29e325"};
      float result;
      
      foreach (string value in values)
      {
         try {
            result = Convert.ToSingle(value);
            Console.WriteLine("Converted the {0} value '{1}' to the {2} value {3}.", 
                              value.GetType().Name, value, 
                              result.GetType().Name, result);
         }   
         catch (FormatException) {
            Console.WriteLine("Unable to convert '{0}' to a Single.", value);
         }               
         catch (OverflowException) {
            Console.WriteLine("'{0}' is outside the range of a Single.", value);
         }
      }       
      // The example displays the following output:
      //    Converted the String value '-1,035.77219' to the Single value -1035.772.
      //    Unable to convert '1AFF' to a Single.
      //    Converted the String value '1e-35' to the Single value 1E-35.
      //    Unable to convert '1.63f' to a Single.
      //    Converted the String value '1,635,592,999,999,999,999,999,999' to the Single value 1.635593E+24.
      //    Converted the String value '-17.455' to the Single value -17.455.
      //    Converted the String value '190.34001' to the Single value 190.34.
      //    1.29e325' is outside the range of a Single.
      // </Snippet10>
   }

   private static void ConvertUInt16()
   {
      // <Snippet11>
      ushort[] numbers = { UInt16.MinValue, 121, 12345, UInt16.MaxValue };
      float result;
      
      foreach (ushort number in numbers)
      {
         result = Convert.ToSingle(number);
         Console.WriteLine("Converted the {0} value '{1}' to the {2} value {3}.", 
                           number.GetType().Name, number, 
                           result.GetType().Name, result);
      }   
      // The example displays the following output:
      //    Converted the UInt16 value '0' to the Single value 0.
      //    Converted the UInt16 value '121' to the Single value 121.
      //    Converted the UInt16 value '12345' to the Single value 12345.
      //    Converted the UInt16 value '65535' to the Single value 65535.
      // </Snippet11>
   }
   
   private static void ConvertUInt32()
   {
      // <Snippet12>
      uint[] numbers = { UInt32.MinValue, 121, 12345, UInt32.MaxValue };
      float result;
      
      foreach (uint number in numbers)
      {
         result = Convert.ToSingle(number);
         Console.WriteLine("Converted the {0} value '{1}' to the {2} value {3}.", 
                           number.GetType().Name, number, 
                           result.GetType().Name, result);
      }   
      // The example displays the following output:
      //    Converted the UInt32 value '0' to the Single value 0.
      //    Converted the UInt32 value '121' to the Single value 121.
      //    Converted the UInt32 value '12345' to the Single value 12345.
      //    Converted the UInt32 value '4294967295' to the Single value 4.294967E+09.
      // </Snippet12>
   }

   private static void ConvertUInt64()
   {
      // <Snippet13>
      ulong[] numbers = { UInt64.MinValue, 121, 12345, UInt64.MaxValue };
      float result;
      
      foreach (ulong number in numbers)
      {
         result = Convert.ToSingle(number);
         Console.WriteLine("Converted the {0} value '{1}' to the {2} value {3}.", 
                           number.GetType().Name, number, 
                           result.GetType().Name, result);
      }   
      // The example displays the following output:
      //    Converted the UInt64 value '0' to the Single value 0.
      //    Converted the UInt64 value '121' to the Single value 121.
      //    Converted the UInt64 value '12345' to the Single value 12345.
      //    Converted the UInt64 value '18446744073709551615' to the Single value 1.844674E+19.
      // </Snippet13>
   }
}
