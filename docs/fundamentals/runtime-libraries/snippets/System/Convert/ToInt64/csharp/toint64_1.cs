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
      Console.WriteLine("-----");
      ConvertUInt64();
    }

   private static void ConvertBoolean()
   {
      // <Snippet1>
      bool falseFlag = false;
      bool trueFlag = true;

      Console.WriteLine("{0} converts to {1}.", falseFlag,
                        Convert.ToInt64(falseFlag));
      Console.WriteLine("{0} converts to {1}.", trueFlag,
                        Convert.ToInt64(trueFlag));
      // The example displays the following output:
      //       False converts to 0.
      //       True converts to 1.
      // </Snippet1>
   }

   private static void ConvertByte()
      {
      // <Snippet2>
      byte[] bytes = { Byte.MinValue, 14, 122, Byte.MaxValue};
      long result;

      foreach (byte byteValue in bytes)
      {
         result = Convert.ToInt64(byteValue);
         Console.WriteLine("Converted the {0} value {1} to the {2} value {3}.",
                           byteValue.GetType().Name, byteValue,
                           result.GetType().Name, result);
      }
      // The example displays the following output:
      //       Converted the Byte value 0 to the Int64 value 0.
      //       Converted the Byte value 14 to the Int64 value 14.
      //       Converted the Byte value 122 to the Int64 value 122.
      //       Converted the Byte value 255 to the Int64 value 255.
      // </Snippet2>
   }

   private static void ConvertChar()
      {
      // <Snippet3>
      char[] chars = { 'a', 'z', '\u0007', '\u03FF',
                       '\u7FFF', '\uFFFE' };
      long result;

      foreach (char ch in chars)
      {
         result = Convert.ToInt64(ch);
         Console.WriteLine("Converted the {0} value '{1}' to the {2} value {3}.",
                           ch.GetType().Name, ch,
                           result.GetType().Name, result);
      }
      // The example displays the following output:
      //       Converted the Char value 'a' to the Int64 value 97.
      //       Converted the Char value 'z' to the Int64 value 122.
      //       Converted the Char value '' to the Int64 value 7.
      //       Converted the Char value 'Ͽ' to the Int64 value 1023.
      //       Converted the Char value '翿' to the Int64 value 32767.
      //       Converted the Char value '￾' to the Int64 value 65534.
      // </Snippet3>
   }

   private static void ConvertDecimal()
   {
      // <Snippet4>
      decimal[] values= { Decimal.MinValue, -1034.23m, -12m, 0m, 147m,
                          199.55m, 9214.16m, Decimal.MaxValue };
      long result;

      foreach (decimal value in values)
      {
         try {
            result = Convert.ToInt64(value);
            Console.WriteLine("Converted the {0} value '{1}' to the {2} value {3}.",
                              value.GetType().Name, value,
                              result.GetType().Name, result);
         }
         catch (OverflowException) {
            Console.WriteLine($"{value} is outside the range of the Int64 type.");
         }
      }
      // The example displays the following output:
      //    -79228162514264337593543950335 is outside the range of the Int64 type.
      //    Converted the Decimal value '-1034.23' to the Int64 value -1034.
      //    Converted the Decimal value '-12' to the Int64 value -12.
      //    Converted the Decimal value '0' to the Int64 value 0.
      //    Converted the Decimal value '147' to the Int64 value 147.
      //    Converted the Decimal value '199.55' to the Int64 value 200.
      //    Converted the Decimal value '9214.16' to the Int64 value 9214.
      //    79228162514264337593543950335 is outside the range of the Int64 type.
      // </Snippet4>
   }

   private static void ConvertDouble()
   {
      // <Snippet5>
      double[] values= { Double.MinValue, -1.38e10, -1023.299, -12.98,
                         0, 9.113e-16, 103.919, 17834.191, Double.MaxValue };
      long result;

      foreach (double value in values)
      {
         try {
            result = Convert.ToInt64(value);
            Console.WriteLine("Converted the {0} value '{1}' to the {2} value {3}.",
                              value.GetType().Name, value,
                              result.GetType().Name, result);
         }
         catch (OverflowException) {
            Console.WriteLine($"{value} is outside the range of the Int64 type.");
         }
      }
      //    -1.7976931348623157E+308 is outside the range of the Int64 type.
      //    Converted the Double value '-13800000000' to the Int64 value -13800000000.
      //    Converted the Double value '-1023.299' to the Int64 value -1023.
      //    Converted the Double value '-12.98' to the Int64 value -13.
      //    Converted the Double value '0' to the Int64 value 0.
      //    Converted the Double value '9.113E-16' to the Int64 value 0.
      //    Converted the Double value '103.919' to the Int64 value 104.
      //    Converted the Double value '17834.191' to the Int64 value 17834.
      //    1.7976931348623157E+308 is outside the range of the Int64 type.
      // </Snippet5>
   }

   private static void ConvertInt16()
   {
      // <Snippet6>
      short[] numbers= { Int16.MinValue, -1, 0, 121, 340, Int16.MaxValue };
      long result;

      foreach (short number in numbers)
      {
         result = Convert.ToInt64(number);
         Console.WriteLine("Converted the {0} value {1} to a {2} value {3}.",
                              number.GetType().Name, number,
                              result.GetType().Name, result);
      }
      // The example displays the following output:
      //    Converted the Int16 value -32768 to a Int32 value -32768.
      //    Converted the Int16 value -1 to a Int32 value -1.
      //    Converted the Int16 value 0 to a Int32 value 0.
      //    Converted the Int16 value 121 to a Int32 value 121.
      //    Converted the Int16 value 340 to a Int32 value 340.
      //    Converted the Int16 value 32767 to a Int32 value 32767.
      // </Snippet6>
   }

   private static void ConvertInt32()
   {
      // <Snippet7>
      int[] numbers = { Int32.MinValue, -1, 0, 121, 340, Int32.MaxValue };
      long result;
      foreach (int number in numbers)
      {
         result = Convert.ToInt64(number);
         Console.WriteLine("Converted the {0} value {1} to the {2} value {3}.",
                           number.GetType().Name, number,
                           result.GetType().Name, result);
      }
      // The example displays the following output:
      //    Converted the Int32 value -2147483648 to the Int64 value -2147483648.
      //    Converted the Int32 value -1 to the Int64 value -1.
      //    Converted the Int32 value 0 to the Int64 value 0.
      //    Converted the Int32 value 121 to the Int64 value 121.
      //    Converted the Int32 value 340 to the Int64 value 340.
      //    Converted the Int32 value 2147483647 to the Int64 value 2147483647.
      // </Snippet7>
   }

   private static void ConvertObject()
   {
      // <Snippet8>
      object[] values = { true, -12, 163, 935, 'x', new DateTime(2009, 5, 12),
                          "104", "103.0", "-1",
                          "1.00e2", "One", 1.00e2, 16.3e42};
      long result;

      foreach (object value in values)
      {
         try {
            result = Convert.ToInt64(value);
            Console.WriteLine("Converted the {0} value {1} to the {2} value {3}.",
                              value.GetType().Name, value,
                              result.GetType().Name, result);
         }
         catch (OverflowException) {
            Console.WriteLine("The {0} value {1} is outside the range of the Int64 type.",
                              value.GetType().Name, value);
         }
         catch (FormatException) {
            Console.WriteLine("The {0} value {1} is not in a recognizable format.",
                              value.GetType().Name, value);
         }
         catch (InvalidCastException) {
            Console.WriteLine("No conversion to an Int64 exists for the {0} value {1}.",
                              value.GetType().Name, value);
         }
      }
      // The example displays the following output:
      //    Converted the Boolean value True to the Int64 value 1.
      //    Converted the Int32 value -12 to the Int64 value -12.
      //    Converted the Int32 value 163 to the Int64 value 163.
      //    Converted the Int32 value 935 to the Int64 value 935.
      //    Converted the Char value x to the Int64 value 120.
      //    No conversion to an Int64 exists for the DateTime value 5/12/2009 12:00:00 AM.
      //    Converted the String value 104 to the Int64 value 104.
      //    The String value 103.0 is not in a recognizable format.
      //    Converted the String value -1 to the Int64 value -1.
      //    The String value 1.00e2 is not in a recognizable format.
      //    The String value One is not in a recognizable format.
      //    Converted the Double value 100 to the Int64 value 100.
      //    The Double value 1.63E+43 is outside the range of the Int64 type.
      // </Snippet8>
   }

   private static void ConvertSByte()
   {
      // <Snippet9>
      sbyte[] numbers = { SByte.MinValue, -1, 0, 10, SByte.MaxValue };
      long result;

      foreach (sbyte number in numbers)
      {
         result = Convert.ToInt64(number);
         Console.WriteLine("Converted the {0} value {1} to the {2} value {3}.",
                           number.GetType().Name, number,
                           result.GetType().Name, result);
      }
      // The example displays the following output:
      //       Converted the SByte value -128 to the Int64 value -128.
      //       Converted the SByte value -1 to the Int64 value -1.
      //       Converted the SByte value 0 to the Int64 value 0.
      //       Converted the SByte value 10 to the Int64 value 10.
      //       Converted the SByte value 127 to the Int64 value 127.
      // </Snippet9>
   }

   private static void ConvertSingle()
   {
      // <Snippet10>
      float[] values= { Single.MinValue, -1.38e10f, -1023.299f, -12.98f,
                        0f, 9.113e-16f, 103.919f, 17834.191f, Single.MaxValue };
      long result;

      foreach (float value in values)
      {
         try {
            result = Convert.ToInt64(value);
            Console.WriteLine("Converted the {0} value {1} to the {2} value {3}.",
                              value.GetType().Name, value, result.GetType().Name, result);
         }
         catch (OverflowException) {
            Console.WriteLine($"{value} is outside the range of the Int64 type.");
         }
      }
      // The example displays the following output:
      //    -3.4028235E+38 is outside the range of the Int64 type.
      //    Converted the Single value -1.38E+10 to the Int64 value -13799999488.
      //    Converted the Single value -1023.299 to the Int64 value -1023.
      //    Converted the Single value -12.98 to the Int64 value -13.
      //    Converted the Single value 0 to the Int64 value 0.
      //    Converted the Single value 9.113E-16 to the Int64 value 0.
      //    Converted the Single value 103.919 to the Int64 value 104.
      //    Converted the Single value 17834.191 to the Int64 value 17834.
      //    3.4028235E+38 is outside the range of the Int64 type.
      // </Snippet10>
   }

   private static void ConvertString()
   {
      // <Snippet11>
      string[] values = { "One", "1.34e28", "-26.87", "-18", "-6.00",
                          " 0", "137", "1601.9", Int32.MaxValue.ToString() };
      long result;

      foreach (string value in values)
      {
         try {
            result = Convert.ToInt64(value);
            Console.WriteLine("Converted the {0} value '{1}' to the {2} value {3}.",
                              value.GetType().Name, value, result.GetType().Name, result);
         }
         catch (OverflowException) {
            Console.WriteLine($"{value} is outside the range of the Int64 type.");
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
      //    Converted the String value '-18' to the Int64 value -18.
      //    The String value '-6.00' is not in a recognizable format.
      //    Converted the String value ' 0' to the Int64 value 0.
      //    Converted the String value '137' to the Int64 value 137.
      //    The String value '1601.9' is not in a recognizable format.
      //    Converted the String value '2147483647' to the Int64 value 2147483647.
      // </Snippet11>
   }

   private static void ConvertUInt16()
   {
      // <Snippet12>
      ushort[] numbers = { UInt16.MinValue, 121, 340, UInt16.MaxValue };
      long result;
      foreach (ushort number in numbers)
      {
         try {
            result = Convert.ToInt64(number);
            Console.WriteLine("Converted the {0} value {1} to the {2} value {3}.",
                              number.GetType().Name, number,
                              result.GetType().Name, result);
         }
         catch (OverflowException) {
            Console.WriteLine("The {0} value {1} is outside the range of the Int64 type.",
                              number.GetType().Name, number);
         }
      }
      // The example displays the following output:
      //    Converted the UInt16 value 0 to the Int64 value 0.
      //    Converted the UInt16 value 121 to the Int64 value 121.
      //    Converted the UInt16 value 340 to the Int64 value 340.
      //    Converted the UInt16 value 65535 to the Int64 value 65535.
      // </Snippet12>
   }

   private static void ConvertUInt32()
   {
      // <Snippet13>
      uint[] numbers = { UInt32.MinValue, 121, 340, UInt32.MaxValue };
      long result;
      foreach (uint number in numbers)
      {
         result = Convert.ToInt64(number);
         Console.WriteLine("Converted the {0} value {1:N0} to the {2} value {3:N0}.",
                           number.GetType().Name, number,
                           result.GetType().Name, result);
      }
      // The example displays the following output:
      //    Converted the UInt32 value 0 to the Int64 value 0.
      //    Converted the UInt32 value 121 to the Int64 value 121.
      //    Converted the UInt32 value 340 to the Int64 value 340.
      //    Converted the UInt32 value 4,294,967,295 to the Int64 value 4,294,967,295.
      // </Snippet13>
   }

   private static void ConvertUInt64()
   {
      // <Snippet14>
      ulong[] numbers = { UInt64.MinValue, 121, 340, UInt64.MaxValue };
      long result;
      foreach (ulong number in numbers)
      {
         try {
            result = Convert.ToInt64(number);
            Console.WriteLine("Converted the {0} value {1} to a {2} value {3}.",
                              number.GetType().Name, number,
                              result.GetType().Name, result);
         }
         catch (OverflowException) {
            Console.WriteLine("The {0} value {1} is outside the range of the Int64 type.",
                              number.GetType().Name, number);
         }
      }
      // The example displays the following output:
      //    Converted the UInt64 value 0 to a Int32 value 0.
      //    Converted the UInt64 value 121 to a Int32 value 121.
      //    Converted the UInt64 value 340 to a Int32 value 340.
      //    The UInt64 value 18446744073709551615 is outside the range of the Int64 type.
      // </Snippet14>
   }
}
