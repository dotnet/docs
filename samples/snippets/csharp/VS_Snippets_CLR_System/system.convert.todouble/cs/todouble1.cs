using System;

public class Example
{
   public static void Main()
   {
      ConvertInt16();
      Console.WriteLine("-----");
      ConvertInt64();
      Console.WriteLine("-----");
      ConvertObject();
      Console.WriteLine("-----");
      ConvertSByte();
      Console.WriteLine("----");
      ConvertUInt16();
      Console.WriteLine("-----");
      ConvertUInt32();
      Console.WriteLine("------");
      ConvertUInt64();
      Console.WriteLine("-----");
      ConvertString();
   }

   private static void ConvertInt16()
   {
      // <Snippet1>
      short[] numbers = { Int16.MinValue, -1032, 0, 192, Int16.MaxValue };
      double result;
      
      foreach (short number in numbers)
      {
         result = Convert.ToDouble(number);
         Console.WriteLine("Converted the UInt16 value {0} to {1}.",
                           number, result);
      }                     
      //       Converted the UInt16 value -32768 to -32768.
      //       Converted the UInt16 value -1032 to -1032.
      //       Converted the UInt16 value 0 to 0.
      //       Converted the UInt16 value 192 to 192.
      //       Converted the UInt16 value 32767 to 32767.
      // </Snippet1>
   }
   
   private static void ConvertInt64()
   {
      // <Snippet2>
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
      //    Converted the Int64 value '-9223372036854775808' to the Double value -9.22337203685478E+18.
      //    Converted the Int64 value '-903' to the Double value -903.
      //    Converted the Int64 value '0' to the Double value 0.
      //    Converted the Int64 value '172' to the Double value 172.
      //    Converted the Int64 value '9223372036854775807' to the Double value 9.22337203685478E+18.
      // </Snippet2>
   }
   
   private static void ConvertObject()
   {
      // <Snippet3>
      object[] values = { true, 'a', 123, 1.764e32f, "9.78", "1e-02",
                          1.67e03f, "A100", "1,033.67", DateTime.Now,
                          Decimal.MaxValue };   
      double result;
      
      foreach (object value in values)
      {
         try {
            result = Convert.ToDouble(value);
            Console.WriteLine("Converted the {0} value {1} to {2}.",
                              value.GetType().Name, value, result);
         }                     
         catch (FormatException) {
            Console.WriteLine("The {0} value {1} is not recognized as a valid Double value.",
                              value.GetType().Name, value);
         }                     
         catch (InvalidCastException) {
            Console.WriteLine("Conversion of the {0} value {1} to a Double is not supported.",
                              value.GetType().Name, value);
         }                     
      }
      // The example displays the following output:
      //    Converted the Boolean value True to 1.
      //    Conversion of the Char value a to a Double is not supported.
      //    Converted the Int32 value 123 to 123.
      //    Converted the Single value 1.764E+32 to 1.76399995098587E+32.
      //    Converted the String value 9.78 to 9.78.
      //    Converted the String value 1e-02 to 0.01.
      //    Converted the Single value 1670 to 1670.
      //    The String value A100 is not recognized as a valid Double value.
      //    Converted the String value 1,033.67 to 1033.67.
      //    Conversion of the DateTime value 10/21/2008 07:12:12 AM to a Double is not supported.
      //    Converted the Decimal value 79228162514264337593543950335 to 7.92281625142643E+28.      
      // </Snippet3>
   }   
   
   private static void ConvertSByte()
   {
      // <Snippet4>
      sbyte[] numbers = { SByte.MinValue, -23, 0, 17, SByte.MaxValue };
      double result;
      
      foreach (sbyte number in numbers)
      {
         result = Convert.ToDouble(number);
         Console.WriteLine("Converted the SByte value {0} to {1}.", number, result);
      }
      //       Converted the SByte value -128 to -128.
      //       Converted the SByte value -23 to -23.
      //       Converted the SByte value 0 to 0.
      //       Converted the SByte value 17 to 17.
      //       Converted the SByte value 127 to 127.
      // </Snippet4>
   }

   private static void ConvertUInt16()
   {
      // <Snippet5>
      ushort[] numbers = { UInt16.MinValue, 121, 12345, UInt16.MaxValue };
      double result;
      
      foreach (ushort number in numbers)
      {
         result = Convert.ToDouble(number);
         Console.WriteLine("Converted the UInt16 value {0} to {1}.",
                           number, result);
      }   
      // The example displays the following output:
      //       Converted the UInt16 value 0 to 0.
      //       Converted the UInt16 value 121 to 121.
      //       Converted the UInt16 value 12345 to 12345.
      //       Converted the UInt16 value 65535 to 65535.      
      // </Snippet5>
   }
   
   private static void ConvertUInt32()
   {
      // <Snippet6>
      uint[] numbers = { UInt32.MinValue, 121, 12345, UInt32.MaxValue };
      double result;
      
      foreach (uint number in numbers)
      {
         result = Convert.ToDouble(number);
         Console.WriteLine("Converted the UInt32 value {0} to {1}.",
                           number, result);
      }   
      // The example displays the following output:
      //       Converted the UInt32 value 0 to 0.
      //       Converted the UInt32 value 121 to 121.
      //       Converted the UInt32 value 12345 to 12345.
      //       Converted the UInt32 value 4294967295 to 4294967295.
      // </Snippet6>
   }

   private static void ConvertUInt64()
   {
      // <Snippet7>
      ulong[] numbers = { UInt64.MinValue, 121, 12345, UInt64.MaxValue };
      double result;
      
      foreach (ulong number in numbers)
      {
         result = Convert.ToDouble(number);
         Console.WriteLine("Converted the UInt64 value {0} to {1}.",
                           number, result);
      }   
      // The example displays the following output:
      //    Converted the UInt64 value 0 to 0.
      //    Converted the UInt64 value 121 to 121.
      //    Converted the UInt64 value 12345 to 12345.
      //    Converted the UInt64 value 18446744073709551615 to 1.84467440737096E+19.
      // </Snippet7>
   }

   // unused
   private static void ConvertString()
   {
      string[] values= { "-1,035.77219", "1AFF", "1e-35", 
                         "1,635,592,999,999,999,999,999,999", "-17.455", 
                         "190.34001", "1.29e325"};
      double result;
      
      foreach (string value in values)
      {
         try {
            result = Convert.ToDouble(value);
            Console.WriteLine("Converted '{0}' to {1}.", value, result);
         }   
         catch (FormatException) {
            Console.WriteLine("Unable to convert '{0}' to a Double.", value);
         }               
         catch (OverflowException) {
            Console.WriteLine("'{0}' is outside the range of a Double.", value);
         }
      }       
      // The example displays the following output:
      //       Converted '-1,035.77219' to -1035.77219.
      //       Unable to convert '1AFF' to a Double.
      //       Converted '1e-35' to 1E-35.
      //       Converted '1,635,592,999,999,999,999,999,999' to 1.635593E+24.
      //       Converted '-17.455' to -17.455.
      //       Converted '190.34001' to 190.34001.
      //       '1.29e325' is outside the range of a Double.
   }   
}
