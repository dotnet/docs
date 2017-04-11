using System;

public class Example
{
   public static void Main()
   {
      ConvertDateTime();
      Console.WriteLine("-----");
      ConvertInt16();
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

   private static void ConvertDateTime()
   {
      // <Snippet1>
      DateTime[] dates = { new DateTime(2009, 7, 14), 
                           new DateTime(1, 1, 1, 18, 32, 0), 
                           new DateTime(2009, 2, 12, 7, 16, 0) };
      string result;
      
      foreach (DateTime dateValue in dates)
      {
         result = Convert.ToString(dateValue);
         Console.WriteLine("Converted the {0} value {1} to the {2} value {3}.",
                              dateValue.GetType().Name, dateValue,
                              result.GetType().Name, result);
      }
      // The example displays the following output:
      //    Converted the DateTime value 7/14/2009 12:00:00 AM to a String value 7/14/2009 12:00:00 AM.
      //    Converted the DateTime value 1/1/0001 06:32:00 PM to a String value 1/1/0001 06:32:00 PM.
      //    Converted the DateTime value 2/12/2009 07:16:00 AM to a String value 2/12/2009 07:16:00 AM.
      // </Snippet1>
   }
   
   private static void ConvertInt16()
   {
      // <Snippet2>
      short[] numbers = { Int16.MinValue, -138, 0, 19, Int16.MaxValue };
      string result;
      
      foreach (short number in numbers)
      {
         result = Convert.ToString(number);
         Console.WriteLine("Converted the {0} value {1} to the {2} value {3}.",
                              number.GetType().Name, number,
                              result.GetType().Name, result);
      }     
      // The example displays the following output:
      //    Converted the Int16 value -32768 to the String value -32768.
      //    Converted the Int16 value -138 to the String value -138.
      //    Converted the Int16 value 0 to the String value 0.
      //    Converted the Int16 value 19 to the String value 19.
      //    Converted the Int16 value 32767 to the String value 32767.
      // </Snippet2>
   }

   private static void ConvertObject()
   {
      // <Snippet3>
      object[] values = { false, 12.63m, new DateTime(2009, 6, 1, 6, 32, 15), 16.09e-12,
                          'Z', 15.15322, SByte.MinValue, Int32.MaxValue };
      string result;
      
      foreach (object value in values)
      {
         result = Convert.ToString(value);
         Console.WriteLine("Converted the {0} value {1} to the {2} value {3}.",
                              value.GetType().Name, value,
                              result.GetType().Name, result);
      }
      // The example displays the following output:
      //    Converted the Boolean value False to the String value False.
      //    Converted the Decimal value 12.63 to the String value 12.63.
      //    Converted the DateTime value 6/1/2009 06:32:15 AM to the String value 6/1/2009 06:32:15 AM.
      //    Converted the Double value 1.609E-11 to the String value 1.609E-11.
      //    Converted the Char value Z to the String value Z.
      //    Converted the Double value 15.15322 to the String value 15.15322.
      //    Converted the SByte value -128 to the String value -128.
      //    Converted the Int32 value 2147483647 to the String value 2147483647.      
      // </Snippet3>
   }   

   private static void ConvertSByte()
   {
      // <Snippet4>
      sbyte[] numbers = { SByte.MinValue, -12, 0, 16, SByte.MaxValue };
      string result;
      
      foreach (sbyte number in numbers)
      {
         result = Convert.ToString(number);
         Console.WriteLine("Converted the {0} value {1} to the {2} value {3}.",
                              number.GetType().Name, number,
                              result.GetType().Name, result);
      }
      // The example displays the following output:
      //    Converted the SByte value -128 to the String value -128.
      //    Converted the SByte value -12 to the String value -12.
      //    Converted the SByte value 0 to the String value 0.
      //    Converted the SByte value 16 to the String value 16.
      //    Converted the SByte value 127 to the String value 127.
      // </Snippet4>
   }
   
   private static void ConvertSingle()
   {
      // <Snippet5>
      float[] numbers = { Single.MinValue, -1011.351f, -17.45f, -3e-16f,
                          0f, 4.56e-12f, 16.0001f, 10345.1221f, Single.MaxValue };
      string result;
      
      foreach (float number in numbers)
      {
         result = Convert.ToString(number);
         Console.WriteLine("Converted the {0} value {1} to the {2} value {3}.",
                              number.GetType().Name, number,
                              result.GetType().Name, result);
      }                            
      // The example displays the following output:
      //    Converted the Single value -3.402823E+38 to the String value -3.402823E+38.
      //    Converted the Single value -1011.351 to the String value -1011.351.
      //    Converted the Single value -17.45 to the String value -17.45.
      //    Converted the Single value -3E-16 to the String value -3E-16.
      //    Converted the Single value 0 to the String value 0.
      //    Converted the Single value 4.56E-12 to the String value 4.56E-12.
      //    Converted the Single value 16.0001 to the String value 16.0001.
      //    Converted the Single value 10345.12 to the String value 10345.12.
      //    Converted the Single value 3.402823E+38 to the String value 3.402823E+38.
      // </Snippet5>
   }
   
   private static void ConvertUInt16()
   {
      // <Snippet6>
      ushort[] numbers = { UInt16.MinValue, 103, 1045, UInt16.MaxValue };
      string result;
      
      foreach (ushort number in numbers)
      {
         result = Convert.ToString(number);
         Console.WriteLine("Converted the {0} value {1} to the {2} value {3}.",
                              number.GetType().Name, number,
                              result.GetType().Name, result);
      }
      // The example displays the following output:
      //    Converted the UInt16 value 0 to the String value 0.
      //    Converted the UInt16 value 103 to the String value 103.
      //    Converted the UInt16 value 1045 to the String value 1045.
      //    Converted the UInt16 value 65535 to the String value 65535.
      // </Snippet6>
   }
   
   private static void ConvertUInt32()
   {
      // <Snippet7>
      uint[] numbers = { UInt32.MinValue, 103, 1045, 119543, UInt32.MaxValue };
      string result;
      
      foreach (uint number in numbers)
      {
         result = Convert.ToString(number);
         Console.WriteLine("Converted the {0} value {1} to the {2} value {3}.",
                              number.GetType().Name, number,
                              result.GetType().Name, result);
      }
      // The example displays the following output:
      //    Converted the UInt32 value 0 to the String value 0.
      //    Converted the UInt32 value 103 to the String value 103.
      //    Converted the UInt32 value 1045 to the String value 1045.
      //    Converted the UInt32 value 119543 to the String value 119543.
      //    Converted the UInt32 value 4294967295 to the String value 4294967295.
      // </Snippet7>
   }
   
   private static void ConvertUInt64()
   {
      // <Snippet8>
      ulong[] numbers = { UInt64.MinValue, 1031, 189045, UInt64.MaxValue };
      string result;
      
      foreach (ulong number in numbers)
      {
         result = Convert.ToString(number);
         Console.WriteLine("Converted the {0} value {1} to the {2} value {3}.",
                              number.GetType().Name, number,
                              result.GetType().Name, result);
      }
      // The example displays the following output:
      //    Converted the UInt64 value 0 to the String value 0.
      //    Converted the UInt64 value 1031 to the String value 1031.
      //    Converted the UInt64 value 189045 to the String value 189045.
      //    Converted the UInt64 value 18446744073709551615 to the String value 18446744073709551615.
      // </Snippet8>
   }
}
