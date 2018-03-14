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
      Console.WriteLine("----");
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
      ConvertUInt32();
      Console.WriteLine("-----");
      ConvertUInt64();
   }

   private static void ConvertBoolean()
   {
      // <Snippet1>
      bool falseFlag = false;
      bool trueFlag = true;
      
      Console.WriteLine("{0} converts to {1}.", falseFlag,
                        Convert.ToInt16(falseFlag));
      Console.WriteLine("{0} converts to {1}.", trueFlag,
                        Convert.ToUInt16(trueFlag));
      // The example displays the following output:
      //       False converts to 0.
      //       True converts to 1.
      // </Snippet1>
   }
   
   private static void ConvertByte()
   {
      // <Snippet2>
      byte[] bytes = { Byte.MinValue, 14, 122, Byte.MaxValue};
      ushort result;
      
      foreach (byte byteValue in bytes)
      {
         result = Convert.ToUInt16(byteValue);
         Console.WriteLine("Converted the {0} value '{1}' to the {2} value {3}.",
                           byteValue.GetType().Name, byteValue, 
                           result.GetType().Name, result);
      }
      // The example displays the following output:
      //       Converted the Byte value '0' to the UInt16 value 0.
      //       Converted the Byte value '14' to the UInt16 value 14.
      //       Converted the Byte value '122' to the UInt16 value 122.
      //       Converted the Byte value '255' to the UInt16 value 255.
      // </Snippet2>
   }   
   
   private static void ConvertChar()
   {
      // <Snippet3>
      char[] chars = { 'a', 'z', '\x0007', '\x03FF',
                       '\x7FFF', '\xFFFE' };
      ushort result;
      
      foreach (char ch in chars)
      {
         try {
            result = Convert.ToUInt16(ch);
            Console.WriteLine("Converted the {0} value '{1}' to the {2} value {3}.", 
                              ch.GetType().Name, ch, 
                              result.GetType().Name, result);
         }
         catch (OverflowException) {
            Console.WriteLine("Unable to convert u+{0} to a UInt16.",
                              ((int)ch).ToString("X4"));
         }
      }   
      // The example displays the following output:
      //    Converted the Char value 'a' to the UInt16 value 97.
      //    Converted the Char value 'z' to the UInt16 value 122.
      //    Converted the Char value '' to the UInt16 value 7.
      //    Converted the Char value '?' to the UInt16 value 1023.
      //    Converted the Char value '?' to the UInt16 value 32767.
      //    Converted the Char value '?' to the UInt16 value 65534.
      // </Snippet3>
   }
   
   private static void ConvertDecimal()
   {
      // <Snippet4>
      decimal[] numbers = { Decimal.MinValue, -1034.23m, -12m, 0m, 147m,
                                  9214.16m, Decimal.MaxValue };
      ushort result;
      
      foreach (decimal number in numbers)
      {
         try {
            result = Convert.ToUInt16(number);
            Console.WriteLine("Converted the {0} value '{1}' to the {2} value {3}.", 
                              number.GetType().Name, number, 
                              result.GetType().Name, result);
         }   
         catch (OverflowException)
         {
            Console.WriteLine("{0} is outside the range of the UInt16 type.",
                              number);
         }   
      }                                  
      // The example displays the following output:
      //    -79228162514264337593543950335 is outside the range of the UInt16 type.
      //    -1034.23 is outside the range of the UInt16 type.
      //    -12 is outside the range of the UInt16 type.
      //    Converted the Decimal value '0' to the UInt16 value 0.
      //    Converted the Decimal value '147' to the UInt16 value 147.
      //    Converted the Decimal value '9214.16' to the UInt16 value 9214.
      //    79228162514264337593543950335 is outside the range of the UInt16 type.
      // </Snippet4>
   }
   
   private static void ConvertDouble()
   {
      // <Snippet5>
      double[] numbers = { Double.MinValue, -1.38e10, -1023.299, -12.98,
                          0, 9.113e-16, 103.919, 17834.191, Double.MaxValue };
      ushort result;
      
      foreach (double number in numbers)
      {
         try {
            result = Convert.ToUInt16(number);
            Console.WriteLine("Converted the {0} value '{1}' to the {2} value {3}.", 
                              number.GetType().Name, number, 
                              result.GetType().Name, result);
         }   
         catch (OverflowException)
         {
            Console.WriteLine("{0} is outside the range of the UInt16 type.", number);
         }   
      }                                 
      // The example displays the following output:
      //    -1.79769313486232E+308 is outside the range of the UInt16 type.
      //    -13800000000 is outside the range of the UInt16 type.
      //    -1023.299 is outside the range of the UInt16 type.
      //    -12.98 is outside the range of the UInt16 type.
      //    Converted the Double value '0' to the UInt16 value 0.
      //    Converted the Double value '9.113E-16' to the UInt16 value 0.
      //    Converted the Double value '103.919' to the UInt16 value 104.
      //    Converted the Double value '17834.191' to the UInt16 value 17834.
      //    1.79769313486232E+308 is outside the range of the UInt16 type.
      // </Snippet5>
   }
      
   private static void ConvertInt16()
   {
      // <Snippet6>
      short[] numbers = { Int16.MinValue, -132, 0, 121, 16103, Int16.MaxValue  };
      ushort result;
      
      foreach (short number in numbers)
      {
         try {
            result = Convert.ToUInt16(number);
            Console.WriteLine("Converted the {0} value '{1}' to the {2} value {3}.", 
                              number.GetType().Name, number, 
                              result.GetType().Name, result);
         }
         catch (OverflowException) {
            Console.WriteLine("The {0} value {1} is outside the range of the UInt16 type.",
                              number.GetType().Name, number);
         }
      }
      // The example displays the following output:
      //    The Int16 value -32768 is outside the range of the UInt16 type.
      //    The Int16 value -132 is outside the range of the UInt16 type.
      //    Converted the Int16 value '0' to the UInt16 value 0.
      //    Converted the Int16 value '121' to the UInt16 value 121.
      //    Converted the Int16 value '16103' to the UInt16 value 16103.
      //    Converted the Int16 value '32767' to the UInt16 value 32767.
      // </Snippet6>
   }
   
   private static void ConvertInt32()
   {
      // <Snippet7>
      int[] numbers = { Int32.MinValue, -1, 0, 121, 340, Int32.MaxValue };
      ushort result;
      
      foreach (int number in numbers)
      {
         try {
            result = Convert.ToUInt16(number);
            Console.WriteLine("Converted the {0} value '{1}' to the {2} value {3}.", 
                              number.GetType().Name, number, 
                              result.GetType().Name, result);
         }                     
         catch (OverflowException) {
            Console.WriteLine("The {0} value {1} is outside the range of the UInt16 type.",
                              number.GetType().Name, number);
         }
      }
      // The example displays the following output:
      //    The Int32 value -2147483648 is outside the range of the UInt16 type.
      //    The Int32 value -1 is outside the range of the UInt16 type.
      //    Converted the Int32 value '0' to the UInt16 value 0.
      //    Converted the Int32 value '121' to the UInt16 value 121.
      //    Converted the Int32 value '340' to the UInt16 value 340.
      //    The Int32 value 2147483647 is outside the range of the UInt16 type.
      // </Snippet7>
   }
   
   private static void ConvertInt64()
   {
      // <Snippet8>
      long[] numbers = { Int64.MinValue, -1, 0, 121, 340, Int64.MaxValue };
      ushort result;
      
      foreach (long number in numbers)
      {
         try {
            result = Convert.ToUInt16(number);
            Console.WriteLine("Converted the {0} value '{1}' to the {2} value {3}.", 
                              number.GetType().Name, number, 
                              result.GetType().Name, result);
         }                     
         catch (OverflowException) {
            Console.WriteLine("The {0} value {1} is outside the range of the UInt16 type.",
                              number.GetType().Name, number);
         }
      }
      // The example displays the following output:
      //    The Int64 value -9223372036854775808 is outside the range of the UInt16 type.
      //    The Int64 value -1 is outside the range of the UInt16 type.
      //    Converted the Int64 value '0' to the UInt16 value 0.
      //    Converted the Int64 value '121' to the UInt16 value 121.
      //    Converted the Int64 value '340' to the UInt16 value 340.
      //    The Int64 value 9223372036854775807 is outside the range of the UInt16 type.
      // </Snippet8>   
   }   
   
   private static void ConvertObject()
   {
      // <Snippet9>
      object[] values= { true, -12, 163, 935, 'x', new DateTime(2009, 5, 12),
                         "104", "103.0", "-1", "1.00e2", "One", 1.00e2};
      ushort result;
      
      foreach (object value in values)
      {
         try {
            result = Convert.ToUInt16(value);
            Console.WriteLine("Converted the {0} value '{1}' to the {2} value {3}.", 
                              value.GetType().Name, value, 
                              result.GetType().Name, result);
         }                     
         catch (OverflowException) {
            Console.WriteLine("The {0} value {1} is outside the range of the UInt16 type.",
                              value.GetType().Name, value);
         }                     
         catch (FormatException) {
            Console.WriteLine("The {0} value {1} is not in a recognizable format.",
                              value.GetType().Name, value);
         }                     
         catch (InvalidCastException) {
            Console.WriteLine("No conversion to a UInt16 exists for the {0} value {1}.",
                              value.GetType().Name, value);
         }
      }                           
      // The example displays the following output:
      //    Converted the Boolean value 'True' to the UInt16 value 1.
      //    The Int32 value -12 is outside the range of the UInt16 type.
      //    Converted the Int32 value '163' to the UInt16 value 163.
      //    Converted the Int32 value '935' to the UInt16 value 935.
      //    Converted the Char value 'x' to the UInt16 value 120.
      //    No conversion to a UInt16 exists for the DateTime value 5/12/2009 12:00:00 AM.
      //    Converted the String value '104' to the UInt16 value 104.
      //    The String value 103.0 is not in a recognizable format.
      //    The String value -1 is outside the range of the UInt16 type.
      //    The String value 1.00e2 is not in a recognizable format.
      //    The String value One is not in a recognizable format.
      //    Converted the Double value '100' to the UInt16 value 100.
      // </Snippet9>
   }
   
   private static void ConvertSByte()
   {
      // <Snippet10>
      sbyte[] numbers = { SByte.MinValue, -1, 0, 10, SByte.MaxValue };
      ushort result;
      
      foreach (sbyte number in numbers)
      {
         try {
            result = Convert.ToUInt16(number);
            Console.WriteLine("Converted the {0} value '{1}' to the {2} value {3}.", 
                              number.GetType().Name, number, 
                              result.GetType().Name, result);
         }
         catch (OverflowException) {
            Console.WriteLine("{0} is outside the range of the UInt16 type.", number);
         }
      }
      // The example displays the following output:
      //    -128 is outside the range of the UInt16 type.
      //    -1 is outside the range of the UInt16 type.
      //    Converted the SByte value '0' to the UInt16 value 0.
      //    Converted the SByte value '10' to the UInt16 value 10.
      //    Converted the SByte value '127' to the UInt16 value 127.
      // </Snippet10>
   }
   
   private static void ConvertSingle()
   {
      // <Snippet11>
      float[] numbers = { Single.MinValue, -1.38e10f, -1023.299f, -12.98f,
                         0f, 9.113e-16f, 103.919f, 17834.191f, Single.MaxValue };
      ushort result;
      
      foreach (float number in numbers)
      {
         try {
            result = Convert.ToUInt16(number);
            Console.WriteLine("Converted the {0} value '{1}' to the {2} value {3}.", 
                              number.GetType().Name, number, 
                              result.GetType().Name, result);
         }                     
         catch (OverflowException) {
            Console.WriteLine("{0} is outside the range of the UInt16 type.", number);
         }   
      }                                 
      // The example displays the following output:
      //    -3.402823E+38 is outside the range of the UInt16 type.
      //    -1.38E+10 is outside the range of the UInt16 type.
      //    -1023.299 is outside the range of the UInt16 type.
      //    -12.98 is outside the range of the UInt16 type.
      //    Converted the Single value '0' to the UInt16 value 0.
      //    Converted the Single value '9.113E-16' to the UInt16 value 0.
      //    Converted the Single value '103.919' to the UInt16 value 104.
      //    Converted the Single value '17834.19' to the UInt16 value 17834.
      //    3.402823E+38 is outside the range of the UInt16 type.
      // </Snippet11>
   }

   private static void ConvertString()
   {
      // <Snippet12>
      string[] values = { "1603", "1,603", "one", "1.6e03", "1.2e-02", 
                          "-1326", "1074122" };
      ushort result;
      
      foreach (string value in values)
      {
         try {
            result = Convert.ToUInt16(value);
            Console.WriteLine("Converted the {0} value '{1}' to the {2} value {3}.",
                              value.GetType().Name, value,
                              result.GetType().Name, result);
         }                     
         catch (FormatException) {
            Console.WriteLine("The {0} value {1} is not in a recognizable format.",
                              value.GetType().Name, value);
         }                     
         catch (OverflowException) {
            Console.WriteLine("{0} is outside the range of the UInt16 type.", value);
         }   
      }
      // The example displays the following output:
      //    Converted the String value '1603' to the UInt16 value 1603.
      //    The String value 1,603 is not in a recognizable format.
      //    The String value one is not in a recognizable format.
      //    The String value 1.6e03 is not in a recognizable format.
      //    The String value 1.2e-02 is not in a recognizable format.
      //    -1326 is outside the range of the UInt16 type.
      //    1074122 is outside the range of the UInt16 type.      
      // </Snippet12>
   }

   private static void ConvertUInt32()
   {
      // <Snippet13>
      uint[] numbers = { UInt32.MinValue, 121, 340, UInt32.MaxValue };
      ushort result;
      
      foreach (uint number in numbers)
      {
         try {
            result = Convert.ToUInt16(number);
            Console.WriteLine("Converted the {0} value '{1}' to the {2} value {3}.", 
                              number.GetType().Name, number, 
                              result.GetType().Name, result);
         }
         catch (OverflowException) {
            Console.WriteLine("The {0} value {1} is outside the range of the UInt16 type.",
                              number.GetType().Name, number);
         }
      }
      // The example displays the following output:
      //    Converted the UInt32 value '0' to the UInt16 value 0.
      //    Converted the UInt32 value '121' to the UInt16 value 121.
      //    Converted the UInt32 value '340' to the UInt16 value 340.
      //    The UInt32 value 4294967295 is outside the range of the UInt16 type.
      // </Snippet13>
   }
   
   private static void ConvertUInt64()
   {
      // <Snippet14>
      ulong[] numbers = { UInt64.MinValue, 121, 340, UInt64.MaxValue };
      ushort result;
      
      foreach (ulong number in numbers)
      {
         try {
            result = Convert.ToUInt16(number);
            Console.WriteLine("Converted the {0} value '{1}' to the {2} value {3}.", 
                              number.GetType().Name, number, 
                              result.GetType().Name, result);
         }
         catch (OverflowException) {
            Console.WriteLine("The {0} value {1} is outside the range of the UInt16 type.",
                              number.GetType().Name, number);
         }
      }
      // The example displays the following output:
      //    Converted the UInt64 value '0' to the UInt16 value 0.
      //    Converted the UInt64 value '121' to the UInt16 value 121.
      //    Converted the UInt64 value '340' to the UInt16 value 340.
      //    The UInt64 value 18446744073709551615 is outside the range of the UInt16 type.
      // </Snippet14>   
   }
}
