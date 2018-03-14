using System;

public class Example
{
   public static void Main()
   {
      ConvertBoolean();
      Console.WriteLine("-----");
      ConvertInt16();
      Console.WriteLine("-----");
      ConvertInt32();
      Console.WriteLine("-----");
      ConvertObject();
      Console.WriteLine("-----");
      ConvertSByte();
      Console.WriteLine("-----");
      ConvertSingle();
      Console.WriteLine("-----");
      ConvertUInt16();
      Console.WriteLine("-----");
      ConvertUInt32();
      Console.WriteLine("-----");
      ConvertUInt64();
   }

   private static void ConvertBoolean()
   {
      // <Snippet1>
      bool[] flags = { true, false };
      decimal result;
      
      foreach (bool flag in flags)
      {
         result = Convert.ToDecimal(flag);
         Console.WriteLine("Converted {0} to {1}.", flag, result);
      }
      // The example displays the following output:
      //       Converted True to 1.
      //       Converted False to 0.      
      // </Snippet1>
   }
   
   private static void ConvertInt16()
   {
      // <Snippet2>
      short[] numbers = { Int16.MinValue, -1000, 0, 1000, Int16.MaxValue };
      decimal result;
      
      foreach (short number in numbers)
      {
         result = Convert.ToDecimal(number);
         Console.WriteLine("Converted the Int16 value {0} to the Decimal value {1}.",
                           number, result);
      }
      // The example displays the following output:
      //       Converted the Int16 value -32768 to the Decimal value -32768.
      //       Converted the Int16 value -1000 to the Decimal value -1000.
      //       Converted the Int16 value 0 to the Decimal value 0.
      //       Converted the Int16 value 1000 to the Decimal value 1000.
      //       Converted the Int16 value 32767 to the Decimal value 32767.
      // </Snippet2>
   }   

   private static void ConvertInt32()
   {
      // <Snippet3>
      int[] numbers = { Int32.MinValue, -1000, 0, 1000, Int32.MaxValue };
      decimal result;
      
      foreach (int number in numbers)
      {
         result = Convert.ToDecimal(number);
         Console.WriteLine("Converted the Int32 value {0} to the Decimal value {1}.",
                           number, result);
      }
      // The example displays the following output:
      //    Converted the Int32 value -2147483648 to the Decimal value -2147483648.
      //    Converted the Int32 value -1000 to the Decimal value -1000.
      //    Converted the Int32 value 0 to the Decimal value 0.
      //    Converted the Int32 value 1000 to the Decimal value 1000.
      //    Converted the Int32 value 2147483647 to the Decimal value 2147483647.      
      // </Snippet3>
   }   

   private static void ConvertObject()
   {
      // <Snippet4>
      object[] values = { true, 'a', 123, 1.764e32, "9.78", "1e-02",
                          1.67e03, "A100", "1,033.67", DateTime.Now,
                          Double.MaxValue };   
      decimal result;
      
      foreach (object value in values)
      {
         try {
            result = Convert.ToDecimal(value);
            Console.WriteLine("Converted the {0} value {1} to {2}.",
                              value.GetType().Name, value, result);
         }                     
         catch (OverflowException) {
            Console.WriteLine("The {0} value {1} is out of range of the Decimal type.",
                              value.GetType().Name, value);
         }                     
         catch (FormatException) {
            Console.WriteLine("The {0} value {1} is not recognized as a valid Decimal value.",
                              value.GetType().Name, value);
         }                     
         catch (InvalidCastException) {
            Console.WriteLine("Conversion of the {0} value {1} to a Decimal is not supported.",
                              value.GetType().Name, value);
         }                     
      }
      // The example displays the following output:
      //    Converted the Boolean value True to 1.
      //    Conversion of the Char value a to a Decimal is not supported.
      //    Converted the Int32 value 123 to 123.
      //    The Double value 1.764E+32 is out of range of the Decimal type.
      //    Converted the String value 9.78 to 9.78.
      //    The String value 1e-02 is not recognized as a valid Decimal value.
      //    Converted the Double value 1670 to 1670.
      //    The String value A100 is not recognized as a valid Decimal value.
      //    Converted the String value 1,033.67 to 1033.67.
      //    Conversion of the DateTime value 10/15/2008 05:40:42 PM to a Decimal is not supported.
      //    The Double value 1.79769313486232E+308 is out of range of the Decimal type.      
      // </Snippet4>
   }

   private static void ConvertSByte()
   {
      // <Snippet5>
      sbyte[] numbers = { SByte.MinValue, -23, 0, 17, SByte.MaxValue };
      decimal result;
      
      foreach (sbyte number in numbers)
      {
         result = Convert.ToDecimal(number);
         Console.WriteLine("Converted the SByte value {0} to {1}.", number, result);
      }
      //       Converted the SByte value -128 to -128.
      //       Converted the SByte value -23 to -23.
      //       Converted the SByte value 0 to 0.
      //       Converted the SByte value 17 to 17.
      //       Converted the SByte value 127 to 127.
      // </Snippet5>
   }
   
   private static void ConvertSingle()
   {
      // <Snippet6>
      float[] numbers = { Single.MinValue, -3e10f, -1093.54f, 0f, 1e-03f,
                          1034.23f, Single.MaxValue };
      decimal result;
      
      foreach (float number in numbers)
      {
         try {
            result = Convert.ToDecimal(number);
            Console.WriteLine("Converted the Single value {0} to {1}.", number, result);
         }   
         catch (OverflowException) {
            Console.WriteLine("{0} is out of range of the Decimal type.", number);
         }
      }                                  
      // The example displays the following output:
      //       -3.402823E+38 is out of range of the Decimal type.
      //       Converted the Single value -3E+10 to -30000000000.
      //       Converted the Single value -1093.54 to -1093.54.
      //       Converted the Single value 0 to 0.
      //       Converted the Single value 0.001 to 0.001.
      //       Converted the Single value 1034.23 to 1034.23.
      //       3.402823E+38 is out of range of the Decimal type.
      // </Snippet6>
   }
   
   private static void ConvertUInt16()
   {
      // <Snippet7>
      ushort[] numbers = { UInt16.MinValue, 121, 12345, UInt16.MaxValue };
      decimal result;
      
      foreach (ushort number in numbers)
      {
         result = Convert.ToDecimal(number);
         Console.WriteLine("Converted the UInt16 value {0} to {1}.",
                           number, result);
      }   
      // The example displays the following output:
      //       Converted the UInt16 value 0 to 0.
      //       Converted the UInt16 value 121 to 121.
      //       Converted the UInt16 value 12345 to 12345.
      //       Converted the UInt16 value 65535 to 65535.      
      // </Snippet7>
   }
   
   private static void ConvertUInt32()
   {
      // <Snippet8>
      uint[] numbers = { UInt32.MinValue, 121, 12345, UInt32.MaxValue };
      decimal result;
      
      foreach (uint number in numbers)
      {
         result = Convert.ToDecimal(number);
         Console.WriteLine("Converted the UInt32 value {0} to {1}.",
                           number, result);
      }   
      // The example displays the following output:
      //       Converted the UInt32 value 0 to 0.
      //       Converted the UInt32 value 121 to 121.
      //       Converted the UInt32 value 12345 to 12345.
      //       Converted the UInt32 value 4294967295 to 4294967295.
      // </Snippet8>
   }

   private static void ConvertUInt64()
   {
      // <Snippet9>
      ulong[] numbers = { UInt64.MinValue, 121, 12345, UInt64.MaxValue };
      decimal result;
      
      foreach (ulong number in numbers)
      {
         result = Convert.ToDecimal(number);
         Console.WriteLine("Converted the UInt64 value {0} to {1}.",
                           number, result);
      }   
      // The example displays the following output:
      //    Converted the UInt64 value 0 to 0.
      //    Converted the UInt64 value 121 to 121.
      //    Converted the UInt64 value 12345 to 12345.
      //    Converted the UInt64 value 18446744073709551615 to 18446744073709551615.
      // </Snippet9>
   }
}
