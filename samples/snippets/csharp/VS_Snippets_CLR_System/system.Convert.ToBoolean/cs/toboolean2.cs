using System;

public class Example
{
   public static void Main()
   {
      ConvertByte();
      Console.WriteLine("-----");
      ConvertDecimal();
      Console.WriteLine("-----");
      ConvertInt16();
      Console.WriteLine("-----");
      ConvertInt32();
      Console.WriteLine("-----");
      ConvertInt64();
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
      Console.WriteLine("-----");
      ConvertObject();
   }

   private static void ConvertByte()
   {
      // <Snippet12>
      byte[] bytes = { Byte.MinValue, 100, 200, Byte.MaxValue };
      bool result;
      
      foreach (byte byteValue in bytes)
      {
         result = Convert.ToBoolean(byteValue); 
         Console.WriteLine("{0,-5}  -->  {1}", byteValue, result);
      }           
      // The example displays the following output:
      //       0      -->  False
      //       100    -->  True
      //       200    -->  True
      //       255    -->  True
      // </Snippet12>
   }
   
   private static void ConvertDecimal()
   {
      // <Snippet2>
      decimal[] numbers = { Decimal.MinValue, -12034.87m, -100m, 0m, 
                                   300m, 6790823.45m, Decimal.MaxValue };
      bool result;
      
      foreach (decimal number in numbers)
      {
         result = Convert.ToBoolean(number); 
         Console.WriteLine("{0,-30}  -->  {1}", number, result);
      }
      // The example displays the following output:
      //       -79228162514264337593543950335  -->  True
      //       -12034.87                       -->  True
      //       -100                            -->  True
      //       0                               -->  False
      //       300                             -->  True
      //       6790823.45                      -->  True
      //       79228162514264337593543950335   -->  True
      // </Snippet2>
   }
   
   private static void ConvertInt16()
   {
      // <Snippet3>
      short[] numbers = { Int16.MinValue, -10000, -154, 0, 216, 21453, 
                          Int16.MaxValue };
      bool result;
      
      foreach (short number in numbers)
      {
         result = Convert.ToBoolean(number);                                 
         Console.WriteLine("{0,-7:N0}  -->  {1}", number, result);
      }
      // The example displays the following output:
      //       -32,768  -->  True
      //       -10,000  -->  True
      //       -154     -->  True
      //       0        -->  False
      //       216      -->  True
      //       21,453   -->  True
      //       32,767   -->  True
      // </Snippet3>
   }
   
   private static void ConvertInt32()
   {
      // <Snippet4>
      int[] numbers = { Int32.MinValue, -201649, -68, 0, 612, 4038907, 
                        Int32.MaxValue };
      bool result;
      
      foreach (int number in numbers)
      {
         result = Convert.ToBoolean(number);                                 
         Console.WriteLine("{0,-15:N0}  -->  {1}", number, result);
      }
      // The example displays the following output:
      //       -2,147,483,648   -->  True
      //       -201,649         -->  True
      //       -68              -->  True
      //       0                -->  False
      //       612              -->  True
      //       4,038,907        -->  True
      //       2,147,483,647    -->  True
      // </Snippet4>
   }
   
   private static void ConvertInt64()
   {
      // <Snippet5>
      long[] numbers = { Int64.MinValue, -2016493, -689, 0, 6121, 
                         403890774, Int64.MaxValue };
      bool result;
      
      foreach (long number in numbers)
      {
         result = Convert.ToBoolean(number);                                 
         Console.WriteLine("{0,-26:N0}  -->  {1}", number, result);
      }
      // The example displays the following output:
      //       -9,223,372,036,854,775,808  -->  True
      //       -2,016,493                  -->  True
      //       -689                        -->  True
      //       0                           -->  False
      //       6,121                       -->  True
      //       403,890,774                 -->  True
      //       9,223,372,036,854,775,807   -->  True
      // </Snippet5>
   }

   private static void ConvertSByte()
   {
      // <Snippet6>
      sbyte[] numbers = { SByte.MinValue, -1, 0, 10, 100, SByte.MaxValue };
      bool result;
      
      foreach (sbyte number in numbers)
      {
         result = Convert.ToBoolean(number);                                 
         Console.WriteLine("{0,-5}  -->  {1}", number, result);
      }
      // The example displays the following output:
      //       -128   -->  True
      //       -1     -->  True
      //       0      -->  False
      //       10     -->  True
      //       100    -->  True
      //       127    -->  True
      // </Snippet6>
   }
   
   private static void ConvertSingle()
   {
      // <Snippet7>
      float[] numbers = { Single.MinValue, -193.0012f, 20e-15f, 0f, 
                          10551e-10f, 100.3398f, Single.MaxValue };
      bool result;
      
      foreach (float number in numbers)
      {
         result = Convert.ToBoolean(number);                                 
         Console.WriteLine("{0,-15}  -->  {1}", number, result);
      }
      // The example displays the following output:
      //       -3.402823E+38    -->  True
      //       -193.0012        -->  True
      //       2E-14            -->  True
      //       0                -->  False
      //       1.0551E-06       -->  True
      //       100.3398         -->  True
      //       3.402823E+38     -->  True
      // </Snippet7>
   }
   
   private static void ConvertUInt16()
   {
      // <Snippet8>
      ushort[] numbers = { UInt16.MinValue, 216, 21453, UInt16.MaxValue };
      bool result;
      
      foreach (ushort number in numbers)
      {
         result = Convert.ToBoolean(number);                                 
         Console.WriteLine("{0,-7:N0}  -->  {1}", number, result);
      }
      // The example displays the following output:
      //       0        -->  False
      //       216      -->  True
      //       21,453   -->  True
      //       65,535   -->  True
      // </Snippet8>
   }
   
   private static void ConvertUInt32()
   {
      // <Snippet9>
      uint[] numbers = { UInt32.MinValue, 612, 4038907, Int32.MaxValue };
      bool result;
      
      foreach (uint number in numbers)
      {
         result = Convert.ToBoolean(number);                                 
         Console.WriteLine("{0,-15:N0}  -->  {1}", number, result);
      }
      // The example displays the following output:
      //       0                -->  False
      //       612              -->  True
      //       4,038,907        -->  True
      //       2,147,483,647    -->  True
      // </Snippet9>
   }
   
   private static void ConvertUInt64()
   {
      // <Snippet10>
      ulong[] numbers = { UInt64.MinValue, 6121, 403890774, UInt64.MaxValue };
      bool result;
      
      foreach (ulong number in numbers)
      {
         result = Convert.ToBoolean(number);                                 
         Console.WriteLine("{0,-26:N0}  -->  {1}", number, result);
      }
      // The example displays the following output:
      //       0                           -->  False
      //       6,121                       -->  True
      //       403,890,774                 -->  True
      //       18,446,744,073,709,551,615  -->  True
      // </Snippet10>
   }
   
   private static void ConvertObject()
   {
      // <Snippet11>
      object[] objects = { 16.33, -24, 0, "12", "12.7", String.Empty, 
                           "1String", "True", "false", null, 
                           new System.Collections.ArrayList() };
      
      foreach (object obj in objects)
      {
         Console.Write("{0,-40}  -->  ", 
                       obj != null ? 
                       String.Format("{0} ({1})", obj, obj.GetType().Name) : 
                       "null");
         try {
            Console.WriteLine("{0}", Convert.ToBoolean(obj));
         }   
         catch (FormatException) {
            Console.WriteLine("Bad Format");
         }   
         catch (InvalidCastException) {
            Console.WriteLine("No Conversion");
         }   
      }     
      // The example displays the following output:
      //       16.33 (Double)                            -->  True
      //       -24 (Int32)                               -->  True
      //       0 (Int32)                                 -->  False
      //       12 (String)                               -->  Bad Format
      //       12.7 (String)                             -->  Bad Format
      //        (String)                                 -->  Bad Format
      //       1String (String)                          -->  Bad Format
      //       True (String)                             -->  True
      //       false (String)                            -->  False
      //       null                                      -->  False
      //       System.Collections.ArrayList (ArrayList)  -->  No Conversion
      // </Snippet11>
   }
}
