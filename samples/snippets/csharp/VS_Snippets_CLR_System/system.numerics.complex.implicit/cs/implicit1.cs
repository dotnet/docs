using System;
using System.Numerics;

public class Example
{
   public static void Main()
   {
      ComplexFromByte();
      Console.WriteLine("-----"); 
      ComplexFromDouble();
      Console.WriteLine("-----"); 
      ComplexFromInt16();
      Console.WriteLine("-----"); 
      ComplexFromInt32();     
      Console.WriteLine("-----"); 
      ComplexFromInt64();     
      Console.WriteLine("-----"); 
      ComplexFromSByte();     
      Console.WriteLine("-----"); 
      ComplexFromSingle();     
      Console.WriteLine("-----"); 
      ComplexFromUInt16();
      Console.WriteLine("-----"); 
      ComplexFromUInt32();     
      Console.WriteLine("-----"); 
      ComplexFromUInt64();     
   }

   private static void ComplexFromByte()
   {
      // <Snippet1>
      byte byteValue = 122;
      System.Numerics.Complex c1 = byteValue;
      Console.WriteLine(c1);
      // The example displays the following output:
      //       (122, 0) 
      // </Snippet1>
   }
   
   private static void ComplexFromDouble()
   {
      // <Snippet2>
      double doubleValue = 1.032e-16;
      System.Numerics.Complex c1 = doubleValue;
      Console.WriteLine(c1);
      // The example displays the following output:
      //       (1.032E-16, 0) 
      // </Snippet2>
   }
   
   private static void ComplexFromInt16()
   {
      // <Snippet3>
      short shortValue = 16024;
      System.Numerics.Complex c1 = shortValue;
      Console.WriteLine(c1);
      // The example displays the following output:
      //       (16024, 0)
      // </Snippet3>
   }
   
   private static void ComplexFromInt32()
   {
      // <Snippet4>
      int intValue = 1034217;
      System.Numerics.Complex c1 = intValue;
      Console.WriteLine(c1);
      // The example displays the following output:
      //       (1034217, 0)
      // </Snippet4>
   }
   
   private static void ComplexFromInt64()
   {
      // <Snippet5>
      long longValue = 951034217;
      System.Numerics.Complex c1 = longValue;
      Console.WriteLine(c1);
      // The example displays the following output:
      //       (951034217, 0)
      // </Snippet5>
   }

   private static void ComplexFromSByte()
   {
      // <Snippet6>
      sbyte sbyteValue = -12;
      System.Numerics.Complex c1 = sbyteValue;
      Console.WriteLine(c1);
      // The example displays the following output:
      //       (-12, 0)
      // </Snippet6>
   }
   
   private static void ComplexFromSingle()
   {
      // <Snippet7>
      float singleValue = 1.032e-08f;
      System.Numerics.Complex c1 = singleValue;
      Console.WriteLine(c1);
      // The example displays the following output:
      //       (1.03199999657022E-08, 0) 
      // </Snippet7>
   }

   private static void ComplexFromUInt16()
   {
      // <Snippet8>
      ushort shortValue = 421;
      System.Numerics.Complex c1 = shortValue;
      Console.WriteLine(c1);
      // The example displays the following output:
      //       (421, 0)
      // </Snippet8>
   }
   
   private static void ComplexFromUInt32()
   {
      // <Snippet9>
      int intValue = 197461;
      System.Numerics.Complex c1 = intValue;
      Console.WriteLine(c1);
      // The example displays the following output:
      //       (197461, 0)
      // </Snippet9>
   }
   
   private static void ComplexFromUInt64()
   {
      // <Snippet10>
      ulong longValue = 951034217;
      System.Numerics.Complex c1 = longValue;
      Console.WriteLine(c1);
      // The example displays the following output:
      //       (951034217, 0)
      // </Snippet10>
   }
}
