// <Snippet2>
using System;

public class Example
{
   static ulong value = 112;
   
   public static void Main()
   {
      byte byte1= 112;
      Console.WriteLine("value = byte1: {0,16}", value.Equals(byte1));
      TestObjectForEquality(byte1);

      short short1 = 112;
      Console.WriteLine("value = short1: {0,17}", value.Equals(short1));
      TestObjectForEquality(short1);

      int int1 = 112;
      Console.WriteLine("value = int1: {0,19}", value.Equals(int1));
      TestObjectForEquality(int1);

      sbyte sbyte1 = 112;
      Console.WriteLine("value = sbyte1: {0,17}", value.Equals(sbyte1));
      TestObjectForEquality(sbyte1);

      ushort ushort1 = 112;
      Console.WriteLine("value = ushort1: {0,16}", value.Equals(ushort1));
      TestObjectForEquality(ushort1);

      uint uint1 = 112;
      Console.WriteLine("value = uint1: {0,18}", value.Equals(uint1));
      TestObjectForEquality(uint1);

      decimal dec1 = 112m;
      Console.WriteLine("value = dec1: {0,21}", value.Equals(dec1));
      TestObjectForEquality(dec1);

      double dbl1 = 112;
      Console.WriteLine("value = dbl1: {0,20}", value.Equals(dbl1));
      TestObjectForEquality(dbl1);
   }

   private static void TestObjectForEquality(Object obj)
   {
      Console.WriteLine("{0} ({1}) = {2} ({3}): {4}\n",
                        value, value.GetType().Name,
                        obj, obj.GetType().Name,
                        value.Equals(obj));
   }
}
// The example displays the following output:
//       value = byte1:             True
//       112 (UInt64) = 112 (Byte): False
//
//       value = short1:             False
//       112 (UInt64) = 112 (Int16): False
//
//       value = int1:               False
//       112 (UInt64) = 112 (Int32): False
//
//       value = sbyte1:             False
//       112 (UInt64) = 112 (SByte): False
//
//       value = ushort1:             True
//       112 (UInt64) = 112 (UInt16): False
//
//       value = uint1:               True
//       112 (UInt64) = 112 (UInt32): False
//
//       value = dec1:                 False
//       112 (UInt64) = 112 (Decimal): False
//
//       value = dbl1:                False
//       112 (UInt64) = 112 (Double): False
// </Snippet2>
