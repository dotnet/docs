using System;

public class Example
{
   public static void Main()
   {
       Console.WriteLine("\nByte Assignments:");
       AssignByte();
       Console.WriteLine("\nByte Assignments with Separator:");
       AssignByteWithSeparator();

       Console.WriteLine("\nShort Assignments:");
       AssignShort();
       Console.WriteLine("\nShort Assignments with Separator:");
       AssignShortWithSeparator();

       Console.WriteLine("\nInteger Assignments:");
       AssignInteger();
       Console.WriteLine("\nInteger Assignments with Separator:");
       AssignIntegerWithSeparator();

       Console.WriteLine("\nLong Assignments:");
       AssignLong();
       Console.WriteLine("\nLong Assignments with Separator:");
       AssignLongWithSeparator();

       Console.WriteLine("\nSigned Byte Assignments:");
       AssignSByte();
       Console.WriteLine("\nSigned Byte Assignments with Separator:");
       AssignSByteWithSeparator();

       Console.WriteLine("\nUShort Assignments:");
       AssignUShort();
       Console.WriteLine("\nUShort Assignments with Separator:");
       AssignUShortWithSeparator();

       Console.WriteLine("\nUInteger Assignments:");
       AssignUInteger();
       Console.WriteLine("\nUInteger Assignments with Separator:");
       AssignUIntegerWithSeparator();

       Console.WriteLine("\nULong Assignments:");
       AssignULong();
       Console.WriteLine("\nULong Assignments with Separator:");
       AssignULongWithSeparator();
   }

   private static void AssignByte()
   {
      // <SnippetByte>
      byte byteValue1 = 201;
      Console.WriteLine(byteValue1);
      
      byte byteValue2 = 0x00C9;
      Console.WriteLine(byteValue2);
      
      byte byteValue3 = 0b1100_1001;
      Console.WriteLine(byteValue3);
      // The example displays the following output:
      //          201
      //          201
      //          201
      // </SnippetByte>
   }

   private static void AssignByteWithSeparator()
   {
      // <SnippetByteS>
      byte byteValue3 = 0b1100_1001;
      Console.WriteLine(byteValue3);
      // The example displays the following output:
      //          201
      // </SnippetByteS>
   }

   private static void AssignShort()
   {
      // <SnippetShort>
      short shortValue1 = 1034;
      Console.WriteLine(shortValue1);
      
      short shortValue2 = 0x040A;
      Console.WriteLine(shortValue2);
      
      short shortValue3 = 0b0100_00001010;
      Console.WriteLine(shortValue3);
      // The example displays the following output:
      //          1034
      //          1034
      //          1034
      // </SnippetShort>
   }

   private static void AssignShortWithSeparator()
   {
      // <SnippetShortS>
      short shortValue1 = 1_034;
      Console.WriteLine(shortValue1);
      
      short shortValue3 = 0b00000100_00001010;
      Console.WriteLine(shortValue3);
      // The example displays the following output:
      //          1034
      //          1034
      // </SnippetShortS>
   }

   private static void AssignInteger()
   {
      // <SnippetInt>
      int intValue1 = 90946;
      Console.WriteLine(intValue1);
      int intValue2 = 0x16342;
      Console.WriteLine(intValue2);
      
      int intValue3 = 0b0001_0110_0011_0100_0010;
      Console.WriteLine(intValue3);
      // The example displays the following output:
      //          90946
      //          90946
      //          90946
      // </SnippetInt>
   }

   private static void AssignIntegerWithSeparator()
   {
      // <SnippetIntS>
      int intValue1 = 90_946;
      Console.WriteLine(intValue1);
      
      int intValue2 = 0x0001_6342;
      Console.WriteLine(intValue2);
      
      int intValue3 = 0b0001_0110_0011_0100_0010;
      Console.WriteLine(intValue3);
      // The example displays the following output:
      //          90946
      //          90946
      //          90946
      // </SnippetIntS>
   }

   private static void AssignLong()
   {
      // <SnippetLong>
      long longValue1 = 4294967296;
      Console.WriteLine(longValue1);
      
      long longValue2 = 0x100000000;
      Console.WriteLine(longValue2);
      
      long longValue3 = 0b1_0000_0000_0000_0000_0000_0000_0000_0000;
      Console.WriteLine(longValue3);
      // The example displays the following output:
      //          4294967296
      //          4294967296
      //          4294967296
      // </SnippetLong>
   }

   private static void AssignLongWithSeparator()
   {
      // <SnippetLongS>
      long longValue1 = 4_294_967_296;
      Console.WriteLine(longValue1);
      
      long longValue2 = 0x1_0000_0000;
      Console.WriteLine(longValue2);
      
      long longValue3 = 0b1_0000_0000_0000_0000_0000_0000_0000_0000;
      Console.WriteLine(longValue3);
      // The example displays the following output:
      //          4294967296
      //          4294967296
      //          4294967296
      // </SnippetLongS>
   }

   private static void AssignSByte()
   {
      // <SnippetSByte>
      sbyte sbyteValue1 = -102;
      Console.WriteLine(sbyteValue1);
      
      unchecked {
         sbyte sbyteValue4 = (sbyte)0x9A;
         Console.WriteLine(sbyteValue4);
         
         sbyte sbyteValue5 = (sbyte)0b1001_1010;
         Console.WriteLine(sbyteValue5);
      }
      // The example displays the following output:
      //          -102
      //          -102
      //          -102
      // </SnippetSByte>
   }

   private static void AssignSByteWithSeparator()
   {
      // <SnippetSByteS>
      unchecked {
         sbyte sbyteValue3 = (sbyte)0b1001_1010;
         Console.WriteLine(sbyteValue3);
      }
      // The example displays the following output:
      //          -102
      // </SnippetSByteS>
   }

   private static void AssignUShort()
   {
      // <SnippetUShort>
      ushort ushortValue1 = 65034;
      Console.WriteLine(ushortValue1);
      
      ushort ushortValue2 = 0xFE0A;
      Console.WriteLine(ushortValue2);
      
      ushort ushortValue3 = 0b1111_1110_0000_1010;
      Console.WriteLine(ushortValue3);
      // The example displays the following output:
      //          65034
      //          65034
      //          65034
      // </SnippetUShort>
   }

   private static void AssignUShortWithSeparator()
   {
      // <SnippetUShortS>
      ushort ushortValue1 = 65_034;
      Console.WriteLine(ushortValue1);
      
      ushort ushortValue3 = 0b11111110_00001010;
      Console.WriteLine(ushortValue3);
      // The example displays the following output:
      //          65034
      //          65034
      // </SnippetUShortS>
   }

   private static void AssignUInteger()
   {
      // <SnippetUInt>
      uint uintValue1 = 3000000000;
      Console.WriteLine(uintValue1);
      
      uint uintValue2 = 0xB2D05E00;
      Console.WriteLine(uintValue2);
      
      uint uintValue3 = 0b1011_0010_1101_0000_0101_1110_0000_0000;
      Console.WriteLine(uintValue3);
      // The example displays the following output:
      //          3000000000
      //          3000000000
      //          3000000000
      // </SnippetUInt>
   }

   private static void AssignUIntegerWithSeparator()
   {
      // <SnippetUIntS>
      uint uintValue1 = 3_000_000_000;
      Console.WriteLine(uintValue1);
      
      uint uintValue2 = 0xB2D0_5E00;
      Console.WriteLine(uintValue2);
      
      uint uintValue3 = 0b1011_0010_1101_0000_0101_1110_0000_0000;
      Console.WriteLine(uintValue3);
      // The example displays the following output:
      //          3000000000
      //          3000000000
      //          3000000000
      // </SnippetUIntS>
   }

   private static void AssignULong()
   {
      // <SnippetULong>
      ulong ulongValue1 = 7934076125;
      Console.WriteLine(ulongValue1);
      
      ulong ulongValue2 = 0x0001D8e864DD;
      Console.WriteLine(ulongValue2);
      
      ulong ulongValue3 = 0b0001_1101_1000_1110_1000_0110_0100_1101_1101;
      Console.WriteLine(ulongValue3);
      // The example displays the following output:
      //          7934076125
      //          7934076125
      //          7934076125
      // </SnippetULong>
   }

   private static void AssignULongWithSeparator()
   {
      // <SnippetIntULong>
      ulong ulongValue1 = 7_934_076_125;
      Console.WriteLine(ulongValue1);
      
      ulong ulongValue2 = 0x0001_D8e8_64DD;
      Console.WriteLine(ulongValue2);
      
      ulong ulongValue3 = 0b0000_0001_1101_1000_1110_1000_0110_0100_1101_1101;
      Console.WriteLine(ulongValue3);
      // The example displays the following output:
      //          7934076125
      //          7934076125
      //          7934076125
      // </SnippetULongS>
   }
}
