using System;

public class Example
{
   public static void Main()
   {
      ConvertBoolean();
      Console.WriteLine("-----");
      ConvertByte();
      Console.WriteLine("-----");
      ConvertChar();
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
      ConvertSingle();
      Console.WriteLine("----");
      ConvertString();     
      Console.WriteLine("-----");
      ConvertUInt16();
      Console.WriteLine("-----");
      ConvertUInt32();
    }

   private static void ConvertBoolean()
   {
      // <Snippet1>
      bool falseFlag = false;
      bool trueFlag = true;
      
      Console.WriteLine("{0} converts to {1}.", falseFlag,
                        Convert.ToUInt64(falseFlag));
      Console.WriteLine("{0} converts to {1}.", trueFlag,
                        Convert.ToUInt64(trueFlag));
      // The example displays the following output:
      //       False converts to 0.
      //       True converts to 1.
      // </Snippet1>
   }
   
   private static void ConvertByte()
      {
      // <Snippet2>
      byte[] bytes = { Byte.MinValue, 14, 122, Byte.MaxValue};
      ulong result;
      
      foreach (byte byteValue in bytes)
      {
         result = Convert.ToUInt64(byteValue);
         Console.WriteLine("Converted the {0} value {1} to the {2} value {3}.",
                           byteValue.GetType().Name, byteValue,
                           result.GetType().Name, result);
      }
      // The example displays the following output:
      //    Converted the Byte value 0 to the UInt64 value 0.
      //    Converted the Byte value 14 to the UInt64 value 14.
      //    Converted the Byte value 122 to the UInt64 value 122.
      //    Converted the Byte value 255 to the UInt64 value 255.
      // </Snippet2>
   }   
   
   private static void ConvertChar()
      {
      // <Snippet3>
      char[] chars = { 'a', 'z', '\u0007', '\u03FF',
                       '\u7FFF', '\uFFFE' };
      ulong result;
                              
      foreach (char ch in chars)
      {
         result = Convert.ToUInt64(ch);
         Console.WriteLine("Converted the {0} value '{1}' to the {2} value {3}.",
                           ch.GetType().Name, ch,
                           result.GetType().Name, result);
      }   
      // The example displays the following output:
      //    Converted the Char value 'a' to the UInt64 value 97.
      //    Converted the Char value 'z' to the UInt64 value 122.
      //    Converted the Char value '' to the UInt64 value 7.
      //    Converted the Char value '?' to the UInt64 value 1023.
      //    Converted the Char value '?' to the UInt64 value 32767.
      //    Converted the Char value '?' to the UInt64 value 65534.
      // </Snippet3>
   }
   
   private static void ConvertDecimal()
   {
      // <Snippet4>
      decimal[] values= { Decimal.MinValue, -1034.23m, -12m, 0m, 147m,
                          199.55m, 9214.16m, Decimal.MaxValue };
      ulong result;
      
      foreach (decimal value in values)
      {
         try {
            result = Convert.ToUInt64(value);
            Console.WriteLine("Converted the {0} value '{1}' to the {2} value {3}.",
                              value.GetType().Name, value,
                              result.GetType().Name, result);
         }
         catch (OverflowException) {
            Console.WriteLine("{0} is outside the range of the UInt64 type.",
                              value);
         }   
      }                                  
      // The example displays the following output:
      //    -79228162514264337593543950335 is outside the range of the UInt64 type.
      //    -1034.23 is outside the range of the UInt64 type.
      //    -12 is outside the range of the UInt64 type.
      //    Converted the Decimal value '0' to the UInt64 value 0.
      //    Converted the Decimal value '147' to the UInt64 value 147.
      //    Converted the Decimal value '199.55' to the UInt64 value 200.
      //    Converted the Decimal value '9214.16' to the UInt64 value 9214.
      //    79228162514264337593543950335 is outside the range of the UInt64 type.
      // </Snippet4>
   }
   
   private static void ConvertDouble()
   {   
      // <Snippet5>
      double[] values= { Double.MinValue, -1.38e10, -1023.299, -12.98,
                         0, 9.113e-16, 103.919, 17834.191, Double.MaxValue };
      ulong result;
      
      foreach (double value in values)
      {
         try {
            result = Convert.ToUInt64(value);
            Console.WriteLine("Converted the {0} value '{1}' to the {2} value {3}.",
                              value.GetType().Name, value,
                              result.GetType().Name, result);
         }
         catch (OverflowException) {
            Console.WriteLine("{0} is outside the range of the UInt64 type.", value);
         }   
      }                                 
      // The example displays the following output:
      //    -1.79769313486232E+308 is outside the range of the UInt64 type.
      //    -13800000000 is outside the range of the UInt64 type.
      //    -1023.299 is outside the range of the UInt64 type.
      //    -12.98 is outside the range of the UInt64 type.
      //    Converted the Double value '0' to the UInt64 value 0.
      //    Converted the Double value '9.113E-16' to the UInt64 value 0.
      //    Converted the Double value '103.919' to the UInt64 value 104.
      //    Converted the Double value '17834.191' to the UInt64 value 17834.
      //    1.79769313486232E+308 is outside the range of the UInt64 type.
      // </Snippet5>
   }
      
   private static void ConvertInt16()
   {
      // <Snippet6>
      short[] numbers= { Int16.MinValue, -1, 0, 121, 340, Int16.MaxValue };
      ulong result;
      
      foreach (short number in numbers)
      {
         try {
            result = Convert.ToUInt64(number);
            Console.WriteLine("Converted the {0} value {1} to a {2} value {3}.",
                                 number.GetType().Name, number,
                                 result.GetType().Name, result);
         }
         catch (OverflowException) {
            Console.WriteLine("{0} is outside the range of the UInt64 type.", number);
         }   
      
      }
      // The example displays the following output:
      //    -32768 is outside the range of the UInt64 type.
      //    -1 is outside the range of the UInt64 type.
      //    Converted the Int16 value 0 to a UInt64 value 0.
      //    Converted the Int16 value 121 to a UInt64 value 121.
      //    Converted the Int16 value 340 to a UInt64 value 340.
      //    Converted the Int16 value 32767 to a UInt64 value 32767.
      // </Snippet6>
   }
   
   private static void ConvertInt32()
   {
      // <Snippet7>
      int[] numbers = { Int32.MinValue, -1, 0, 121, 340, Int32.MaxValue };
      ulong result;

      foreach (int number in numbers)
      {
         try {
            result = Convert.ToUInt64(number);
            Console.WriteLine("Converted the {0} value {1} to the {2} value {3}.",
                              number.GetType().Name, number,
                              result.GetType().Name, result);
         } 
         catch (OverflowException) {
            Console.WriteLine("The {0} value {1} is outside the range of the UInt64 type.",
                              number.GetType().Name, number);
         }   
      }
      // The example displays the following output:
      //    The Int32 value -2147483648 is outside the range of the UInt64 type.
      //    The Int32 value -1 is outside the range of the UInt64 type.
      //    Converted the Int32 value 0 to the UInt64 value 0.
      //    Converted the Int32 value 121 to the UInt64 value 121.
      //    Converted the Int32 value 340 to the UInt64 value 340.
      //    Converted the Int32 value 2147483647 to the UInt64 value 2147483647.
      // </Snippet7>   
   }   
   
   private static void ConvertInt64()
   {
      // <Snippet8>
      long[] numbers = { Int64.MinValue, -19432, -18, 0, 121, 340, Int64.MaxValue };
      ulong result;
      foreach (long number in numbers)
      {
         try {
            result = Convert.ToUInt64(number);
            Console.WriteLine("Converted the {0} value {1} to the {2} value {3}.",
                              number.GetType().Name, number,
                              result.GetType().Name, result);
         }
         catch (OverflowException) {
            Console.WriteLine("The {0} value {1} is outside the range of the UInt64 type.",
                              number.GetType().Name, number);
         }
      }
      // The example displays the following output:
      //    The Int64 value -9223372036854775808 is outside the range of the UInt64 type.
      //    The Int64 value -19432 is outside the range of the UInt64 type.
      //    The Int64 value -18 is outside the range of the UInt64 type.
      //    Converted the Int64 value 0 to the UInt64 value 0.
      //    Converted the Int64 value 121 to the UInt64 value 121.
      //    Converted the Int64 value 340 to the UInt64 value 340.
      //    Converted the Int64 value 9223372036854775807 to a UInt64 value 9223372036854775807.
      // </Snippet8>   
   }
   
   private static void ConvertObject()
   {
      // <Snippet9>
      object[] values = { true, -12, 163, 935, 'x', new DateTime(2009, 5, 12),
                          "104", "103.0", "-1",
                          "1.00e2", "One", 1.00e2, 16.3e42};
      ulong result;
      
      foreach (object value in values)
      {
         try {
            result = Convert.ToUInt64(value);
            Console.WriteLine("Converted the {0} value {1} to the {2} value {3}.",
                              value.GetType().Name, value,
                              result.GetType().Name, result);
         }
         catch (OverflowException) {
            Console.WriteLine("The {0} value {1} is outside the range of the UInt64 type.",
                              value.GetType().Name, value);
         }                     
         catch (FormatException) {
            Console.WriteLine("The {0} value {1} is not in a recognizable format.",
                              value.GetType().Name, value);
         }
         catch (InvalidCastException) {
            Console.WriteLine("No conversion to a UInt64 exists for the {0} value {1}.",
                              value.GetType().Name, value);
                              
         }
      }                           
      // The example displays the following output:
      //    Converted the Boolean value True to the UInt64 value 1.
      //    The Int32 value -12 is outside the range of the UInt64 type.
      //    Converted the Int32 value 163 to the UInt64 value 163.
      //    Converted the Int32 value 935 to the UInt64 value 935.
      //    Converted the Char value x to the UInt64 value 120.
      //    No conversion to a UInt64 exists for the DateTime value 5/12/2009 12:00:00 AM.
      //    Converted the String value 104 to the UInt64 value 104.
      //    The String value 103.0 is not in a recognizable format.
      //    The String value -1 is outside the range of the UInt64 type.
      //    The String value 1.00e2 is not in a recognizable format.
      //    The String value One is not in a recognizable format.
      //    Converted the Double value 100 to the UInt64 value 100.
      //    The Double value 1.63E+43 is outside the range of the UInt64 type.
      // </Snippet9>
   }
   
   private static void ConvertSByte()
   {
      // <Snippet10>
      sbyte[] numbers = { SByte.MinValue, -1, 0, 10, SByte.MaxValue };
      ulong result;
      
      foreach (sbyte number in numbers)
      {
         try {
            result = Convert.ToUInt64(number);
            Console.WriteLine("Converted the {0} value {1} to the {2} value {3}.",
                              number.GetType().Name, number,
                              result.GetType().Name, result);
         }
         catch (OverflowException) {
            Console.WriteLine("The {0} value {1} is outside the range of the UInt64 type.",
                              number.GetType().Name, number);
         }   
      }
      // The example displays the following output:
      //    The SByte value -128 is outside the range of the UInt64 type.
      //    The SByte value -1 is outside the range of the UInt64 type.
      //    Converted the SByte value 0 to the UInt64 value 0.
      //    Converted the SByte value 10 to the UInt64 value 10.
      //    Converted the SByte value 127 to the UInt64 value 127.
      // </Snippet10>
   }
   
   private static void ConvertSingle()
   {
      // <Snippet11>
      float[] values= { Single.MinValue, -1.38e10f, -1023.299f, -12.98f,
                        0f, 9.113e-16f, 103.919f, 17834.191f, Single.MaxValue };
      ulong result;
      
      foreach (float value in values)
      {
         try {
            result = Convert.ToUInt64(value);
            Console.WriteLine("Converted the {0} value {1} to the {2} value {3}.",
                              value.GetType().Name, value, result.GetType().Name, result);
         }
         catch (OverflowException) {
            Console.WriteLine("{0} is outside the range of the UInt64 type.", value);
         }   
      }                                 
      // The example displays the following output:
      //    -3.402823E+38 is outside the range of the UInt64 type.
      //    -1.38E+10 is outside the range of the UInt64 type.
      //    -1023.299 is outside the range of the UInt64 type.
      //    -12.98 is outside the range of the UInt64 type.
      //    Converted the Single value 0 to the UInt64 value 0.
      //    Converted the Single value 9.113E-16 to the UInt64 value 0.
      //    Converted the Single value 103.919 to the UInt64 value 104.
      //    Converted the Single value 17834.19 to the UInt64 value 17834.
      //    3.402823E+38 is outside the range of the UInt64 type.
      // </Snippet11>
   }

   private static void ConvertString()
   {
      // <Snippet12>
      string[] values = { "One", "1.34e28", "-26.87", "-18", "-6.00",
                          " 0", "137", "1601.9", Int32.MaxValue.ToString() };
      ulong result;
      
      foreach (string value in values)
      {
         try {
            result = Convert.ToUInt64(value);
            Console.WriteLine("Converted the {0} value '{1}' to the {2} value {3}.",
                              value.GetType().Name, value, result.GetType().Name, result);
         }
         catch (OverflowException) {
            Console.WriteLine("{0} is outside the range of the UInt64 type.", value);
         }   
         catch (FormatException) {
            Console.WriteLine("The {0} value '{1}' is not in a recognizable format.",
                              value.GetType().Name, value);
         }   
      }                                 
      // The example displays the following output:
      //    The String value 'One' is not in a recognizable format.
      //    The String value '1.34e28' is not in a recognizable format.
      //    The String value '-26.87' is not in a recognizable format.
      //    -18 is outside the range of the UInt64 type.
      //    The String value '-6.00' is not in a recognizable format.
      //    Converted the String value ' 0' to the UInt64 value 0.
      //    Converted the String value '137' to the UInt64 value 137.
      //    The String value '1601.9' is not in a recognizable format.
      //    Converted the String value '2147483647' to the UInt64 value 2147483647.
      // </Snippet12>
   }

   private static void ConvertUInt16()
   { 
      // <Snippet13>
      ushort[] numbers = { UInt16.MinValue, 121, 340, UInt16.MaxValue };
      ulong result;
      
      foreach (ushort number in numbers)
      {
         try {
            result = Convert.ToUInt64(number);
            Console.WriteLine("Converted the {0} value {1} to the {2} value {3}.",
                              number.GetType().Name, number,
                              result.GetType().Name, result);
         }
         catch (OverflowException) {
            Console.WriteLine("The {0} value {1} is outside the range of the UInt64 type.",
                              number.GetType().Name, number);
         }
      }
      // The example displays the following output:
      //    Converted the UInt16 value 0 to the UInt64 value 0.
      //    Converted the UInt16 value 121 to the UInt64 value 121.
      //    Converted the UInt16 value 340 to the UInt64 value 340.
      //    Converted the UInt16 value 65535 to the UInt64 value 65535.
      // </Snippet13>
   }
   
   private static void ConvertUInt32()
   {
      // <Snippet14>
      uint[] numbers = { UInt32.MinValue, 121, 340, UInt32.MaxValue };
      ulong result;
      
      foreach (uint number in numbers)
      {
         try {
            result = Convert.ToUInt64(number);
            Console.WriteLine("Converted the {0} value {1} to the {2} value {3}.",
                              number.GetType().Name, number,
                              result.GetType().Name, result);
         }
         catch (OverflowException) {
            Console.WriteLine("The {0} value {1} is outside the range of the UInt64 type.",
                              number.GetType().Name, number);
         }
      }
      // The example displays the following output:
      //    Converted the UInt32 value 0 to the UInt64 value 0.
      //    Converted the UInt32 value 121 to the UInt64 value 121.
      //    Converted the UInt32 value 340 to the UInt64 value 340.
      //    Converted the UInt32 value 4294967295 to the UInt64 value 4294967295.
      // </Snippet14>
   }
}
