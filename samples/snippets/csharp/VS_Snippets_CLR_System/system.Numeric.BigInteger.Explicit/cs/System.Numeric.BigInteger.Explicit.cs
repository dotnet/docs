
// Illustrates explicit BigInteger conversions defined
// using the op_Explicit method.

using System;
using System.Numerics;

public class ExplicitConversion
{
   public static void Main()
   {
      // <Snippet1>
      // BigInteger to Byte conversion.
      BigInteger goodByte = BigInteger.One;
      BigInteger badByte = 256;
      
      byte byteFromBigInteger;   
      
      // Successful conversion using cast operator.
      byteFromBigInteger = (byte) goodByte;
      Console.WriteLine(byteFromBigInteger);
      
      // Handle conversion that should result in overflow.
      try
      {
         byteFromBigInteger = (byte) badByte;
         Console.WriteLine(byteFromBigInteger);
      }
      catch (OverflowException e)
      {
         Console.WriteLine("Unable to convert {0}:\n   {1}", 
                           badByte, e.Message);
      }
      Console.WriteLine();
      // </Snippet1>
      
      // <Snippet2>
      // BigInteger to Decimal conversion.
      BigInteger goodDecimal = 761652543;
      BigInteger badDecimal = (BigInteger) Decimal.MaxValue; 
      badDecimal += BigInteger.One;
      
      Decimal decimalFromBigInteger;

      // Successful conversion using cast operator.
      decimalFromBigInteger = (decimal) goodDecimal;
      Console.WriteLine(decimalFromBigInteger);
      
      // Handle conversion that should result in overflow.
      try
      {
         decimalFromBigInteger = (decimal) badDecimal;
         Console.WriteLine(decimalFromBigInteger);
      }
      catch (OverflowException e)
      {
         Console.WriteLine("Unable to convert {0}:\n   {1}", 
                           badDecimal, e.Message);
      }
      Console.WriteLine();
      // </Snippet2>


      // <Snippet3>
      // BigInteger to Double conversion.
      BigInteger goodDouble = (BigInteger) 102.43e22;
      BigInteger badDouble = (BigInteger) Double.MaxValue;  
      badDouble = badDouble * 2;
      
      double doubleFromBigInteger;
      
      // successful conversion using cast operator.
      doubleFromBigInteger = (double) goodDouble;
      Console.WriteLine(doubleFromBigInteger);
      
      // Convert an out-of-bounds BigInteger value to a Double.
      doubleFromBigInteger = (double) badDouble;
      Console.WriteLine(doubleFromBigInteger);
      // </Snippet3>

      // <Snippet4>
      // BigInteger to Int16 conversion.
      BigInteger goodShort = 20000;
      BigInteger badShort = 33000;
      
      short shortFromBigInteger;
      
      // Successful conversion using cast operator. 
      shortFromBigInteger = (short) goodShort;
      Console.WriteLine(shortFromBigInteger);
      
      // Handle conversion that should result in overflow.
      try
      {
         shortFromBigInteger = (short) badShort;
         Console.WriteLine(shortFromBigInteger);
      }
      catch (OverflowException e)
      {
         Console.WriteLine("Unable to convert {0}:\n   {1}", 
                           badShort, e.Message);
      }
      Console.WriteLine();
      // </Snippet4>

      // <Snippet5>
      // BigInteger to Int32 conversion.
      BigInteger goodInteger = 200000;
      BigInteger badInteger = 65000000000;
      
      int integerFromBigInteger;

      // Successful conversion using cast operator. 
      integerFromBigInteger = (int) goodInteger;
      Console.WriteLine(integerFromBigInteger);
      
      // Handle conversion that should result in overflow.
      try
      {
         integerFromBigInteger = (int) badInteger;
         Console.WriteLine(integerFromBigInteger);
      }
      catch (OverflowException e)
      {
         Console.WriteLine("Unable to convert {0}:\n   {1}", 
                           badInteger, e.Message);
      }
      Console.WriteLine();
      // </Snippet5>


      // <Snippet6>
      // BigInteger to Int64 conversion.
      BigInteger goodLong = 2000000000;
      BigInteger badLong = BigInteger.Pow(goodLong, 3);
      
      long longFromBigInteger;
      
      // Successful conversion using cast operator. 
      longFromBigInteger = (long) goodLong;
      Console.WriteLine(longFromBigInteger);
      
      // Handle conversion that should result in overflow.
      try
      {
         longFromBigInteger = (long) badLong;
         Console.WriteLine(longFromBigInteger);
      }
      catch (OverflowException e)
      {
         Console.WriteLine("Unable to convert {0}:\n   {1}", 
                           badLong, e.Message);
      }
      Console.WriteLine();
      // </Snippet6>
      
      // <Snippet7>
      // BigInteger to SByte conversion.
      BigInteger goodSByte = BigInteger.MinusOne;
      BigInteger badSByte = -130;
      
      sbyte sByteFromBigInteger;

      // Successful conversion using cast operator. 
      sByteFromBigInteger = (sbyte) goodSByte;
      Console.WriteLine(sByteFromBigInteger);
      
      // Handle conversion that should result in overflow.
      try
      {
         sByteFromBigInteger = (sbyte) badSByte;
         Console.WriteLine(sByteFromBigInteger);
      }
      catch (OverflowException e)
      {
         Console.WriteLine("Unable to convert {0}:\n   {1}", 
                           badSByte, e.Message);
      }
      Console.WriteLine();
      // </Snippet7>

      // <Snippet8>
      // BigInteger to Single conversion.
      BigInteger goodSingle = (BigInteger) 102.43e22F;
      BigInteger badSingle = (BigInteger) float.MaxValue;  
      badSingle = badSingle * 2;
      
      float singleFromBigInteger;
      
      // Successful conversion using cast operator. 
      singleFromBigInteger = (float) goodSingle;
      Console.WriteLine(singleFromBigInteger);
      
      // Convert an out-of-bounds BigInteger value to a Single.
      singleFromBigInteger = (float) badSingle;
      Console.WriteLine(singleFromBigInteger);
     // </Snippet8>

     // <Snippet9>
      // BigInteger to UInt16 conversion.
      BigInteger goodUShort = 20000;
      BigInteger badUShort = 66000;
      
      ushort uShortFromBigInteger;
      
      // Successful conversion using cast operator. 
      uShortFromBigInteger = (ushort) goodUShort;
      Console.WriteLine(uShortFromBigInteger);

      // Handle conversion that should result in overflow.
      try
      {
         uShortFromBigInteger = (ushort) badUShort;
         Console.WriteLine(uShortFromBigInteger);
      }
      catch (OverflowException e)
      {
         Console.WriteLine("Unable to convert {0}:\n   {1}", 
                           badUShort, e.Message);
      }
      Console.WriteLine();
      // </Snippet9> 
      
      // <Snippet10>
      // BigInteger to UInt32 conversion.
      BigInteger goodUInteger = 200000;
      BigInteger badUInteger = 65000000000;
      
      uint uIntegerFromBigInteger;
      
      // Successful conversion using cast operator. 
      uIntegerFromBigInteger = (uint) goodInteger;
      Console.WriteLine(uIntegerFromBigInteger);
      
      // Handle conversion that should result in overflow.
      try
      {
         uIntegerFromBigInteger = (uint) badUInteger;
         Console.WriteLine(uIntegerFromBigInteger);
      }
      catch (OverflowException e)
      {
         Console.WriteLine("Unable to convert {0}:\n   {1}", 
                           badUInteger, e.Message);
      }
      Console.WriteLine();
      // </Snippet10>
      
      // <Snippet11>
      // BigInteger to UInt64 conversion.
      BigInteger goodULong = 2000000000;
      BigInteger badULong = BigInteger.Pow(goodULong, 3);
      
      ulong uLongFromBigInteger;
      
      // Successful conversion using cast operator. 
      uLongFromBigInteger = (ulong) goodULong;
      Console.WriteLine(uLongFromBigInteger);
      
      // Handle conversion that should result in overflow.
      try
      {
         uLongFromBigInteger = (ulong) badULong;
         Console.WriteLine(uLongFromBigInteger);
      }
      catch (OverflowException e)
      {
         Console.WriteLine("Unable to convert {0}:\n   {1}", 
                           badULong, e.Message);
      }
      Console.WriteLine();
      // </Snippet11>      
      
       // <Snippet12>
      // BigInteger to Decimal conversion.
      //
      // Assign a decimal to a BigInteger
      decimal decimalValue = 31043639504.621m;
      BigInteger hugeValueFromDecimal = (BigInteger) decimalValue;
      hugeValueFromDecimal = BigInteger.Pow(hugeValueFromDecimal, 2);
      // Convert the value back to a Decimal if it//s in range
      if (hugeValueFromDecimal <= (BigInteger) Decimal.MaxValue)
      {
         decimalValue = (decimal) hugeValueFromDecimal;
         Console.WriteLine("The decimal value is {0}", decimalValue);
      }   
      else
      {
         Console.WriteLine("Unable to convert {0} to a Decimal", hugeValueFromDecimal);            
      }
      // </Snippet12>

      // <Snippet13>
      // BigInteger to Double conversion.
      //
      // Assign a Double to a BigInteger
      double doubleValue = 3104363950465.621984;
      BigInteger hugeValueFromDouble = (BigInteger) doubleValue;
      hugeValueFromDouble = BigInteger.Pow(hugeValueFromDouble, 3);
      // Convert the value back to a Decimal if it's in range
      if (hugeValueFromDouble <= (BigInteger) Double.MaxValue)
      {
         doubleValue = (double) hugeValueFromDouble;
         Console.WriteLine("The value of the Double is {0}", doubleValue);
      }
      else
      {
         Console.WriteLine("Unable to convert {0} to a Double", hugeValueFromDouble);            
      }
      // </Snippet13>
     
      // <Snippet14>
      // BigInteger to float conversion.
      //
      // Assign a float to a BigInteger
      float singleValue = 3104363950465.621984F;
      BigInteger hugeValueFromSingle = (BigInteger) singleValue;
      hugeValueFromSingle = BigInteger.Pow(hugeValueFromSingle, 2);
      // Convert the value back to a Single if it//s in range
      if (hugeValueFromSingle <= (BigInteger) Single.MaxValue)
      {
         singleValue = (float) hugeValueFromSingle;
         Console.WriteLine("The value of the float is {0}", singleValue);
      }
      else
      {
         Console.WriteLine("Unable to convert {0} to a float", hugeValueFromSingle);
      }
      // </Snippet14>
    }
}
