using System;
using System.Numerics;

public class ImplicitConversions
{
   public static void Main()
   {
      ImplicitConversions conv = new ImplicitConversions();
      conv.ShowByteConversion();
      conv.ShowShortConversion();
      conv.ShowIntConversion();
      conv.ShowLongConversion();
      conv.ShowSByteConversion();
      conv.ShowUShortConversion();
      conv.ShowUIntConversion();
      conv.ShowULongConversion();
   }

   private void ShowByteConversion()
   {
      Console.WriteLine("Implicit Byte Conversion:");
      // <Snippet1>
      byte byteValue = 254;
      BigInteger number = byteValue;
      number = BigInteger.Add(number, byteValue);
      Console.WriteLine(number > byteValue);            // Displays True     
      // </Snippet1>
      Console.WriteLine();
   }

   private void ShowShortConversion()
   {
      Console.WriteLine("Implicit Short Conversion:");
      // <Snippet2>
      short shortValue = 25064;
      BigInteger number = shortValue;
      number += shortValue;
      Console.WriteLine(number < shortValue);           // Displays False     
      // </Snippet2>
      Console.WriteLine();
   }

   private void ShowIntConversion()
   {
      Console.WriteLine("Implicit Int Conversion:");
      // <Snippet3>
      int intValue = 65000;
      BigInteger number = intValue;
      number = BigInteger.Multiply(number, intValue);
      Console.WriteLine(number == intValue);            // Displays False     
      // </Snippet3>
      Console.WriteLine();
   }

   private void ShowLongConversion()
   {
      Console.WriteLine("Implicit Long Conversion:");
      // <Snippet4>
      long longValue = 1358754982;
      BigInteger number = longValue;
      number = number + (longValue / 2);
      Console.WriteLine(number * longValue / longValue); // Displays 2038132473     
      // </Snippet4>
      Console.WriteLine();
   }

   private void ShowSByteConversion()
   {
      Console.WriteLine("Implicit SByte Conversion:");
      // <Snippet5>
      sbyte sByteValue = -12;
      BigInteger number = BigInteger.Pow(sByteValue, 3);
      Console.WriteLine(number < sByteValue);            // Displays True     
      // </Snippet5>
      Console.WriteLine();
   }
  
   private void ShowUShortConversion()
   {
      Console.WriteLine("Implicit UShort Conversion:");
      // <Snippet6>
      ushort uShortValue = 25064;
      BigInteger number = uShortValue;
      number += uShortValue;
      Console.WriteLine(number < uShortValue);           // Displays False     
      // </Snippet6>
      Console.WriteLine();
   }

   private void ShowUIntConversion()
   {
      Console.WriteLine("Implicit UInt Conversion:");
      // <Snippet7>
      uint uIntValue = 65000;
      BigInteger number = uIntValue;
      number = BigInteger.Multiply(number, uIntValue);
      Console.WriteLine(number == uIntValue);           // Displays False     
      // </Snippet7>
      Console.WriteLine();
   }

   private void ShowULongConversion()
   {
      Console.WriteLine("Implicit ULong Conversion:");
      // <Snippet8>
      ulong uLongValue = 1358754982;
      BigInteger number = uLongValue;
      number = number * 2 - uLongValue;
      Console.WriteLine(number * uLongValue / uLongValue); // Displays 1358754982     
      // </Snippet8>
      Console.WriteLine();
   }
}
