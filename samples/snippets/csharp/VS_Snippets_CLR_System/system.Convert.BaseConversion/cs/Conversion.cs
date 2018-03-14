using System;

public class Class1
{
   public static void Main()
   {
      ConvertHexToNegativeInteger();
      Console.WriteLine();
      ConvertHexToInteger();
      Console.WriteLine();
      ConvertNegativeHexToByte();
      Console.WriteLine();
      ConvertHexToByte();
      Console.WriteLine();
      ConvertHexToNegativeShort();
      Console.WriteLine();
      ConvertHexToShort();
      Console.WriteLine();
      ConvertHexToNegativeLong();
      Console.WriteLine();
      ConvertHexToLong();
      Console.WriteLine();
      ConvertHexToNegativeSByte();
      Console.WriteLine();
      ConvertHexToSByte();
      Console.WriteLine();
      ConvertNegativeHexToUInt16();
      Console.WriteLine();
      ConvertHexToUInt16();
      Console.WriteLine();
      ConvertNegativeHexToUInt32();
      Console.WriteLine();
      ConvertHexToUInt32();
      Console.WriteLine();
      ConvertNegativeHexToUInt64();
      Console.WriteLine();
      ConvertHexToUInt64();
   }

   private static void ConvertHexToNegativeInteger()
   {
     // <Snippet1>
     // Create a hexadecimal value out of range of the Integer type.
     string value = Convert.ToString((long) int.MaxValue + 1, 16);
     // Convert it back to a number.
     try
     {
        int number = Convert.ToInt32(value, 16);
        Console.WriteLine("0x{0} converts to {1}.", value, number.ToString());
     }
     catch (OverflowException)
     {
        Console.WriteLine("Unable to convert '0x{0}' to an integer.", value);
     }   
     // </Snippet1>
   }

   private static void ConvertHexToInteger()
   {
      // <Snippet2>
      // Create a hexadecimal value out of range of the Integer type.
      long sourceNumber = (long) int.MaxValue + 1;
      bool isNegative = Math.Sign(sourceNumber) == -1;
      string value = Convert.ToString(sourceNumber, 16);
      int targetNumber;
      try
      {
         targetNumber = Convert.ToInt32(value, 16);
         if (!(isNegative) & (targetNumber & 0x80000000) != 0) 
            throw new OverflowException();
         else 
            Console.WriteLine("0x{0} converts to {1}.", value, targetNumber);
      }
      catch (OverflowException)
      {
         Console.WriteLine("Unable to convert '0x{0}' to an integer.", value);
      } 
      // Displays the following to the console:
      //    Unable to convert '0x80000000' to an integer.    
      // </Snippet2>
   }

   private static void ConvertNegativeHexToByte()
   {
      // <Snippet3>
      // Create a hexadecimal value out of range of the Byte type.
      string value = SByte.MinValue.ToString("X");
      // Convert it back to a number.
      try
      {
         byte number = Convert.ToByte(value, 16);
         Console.WriteLine("0x{0} converts to {1}.", value, number);
      }   
      catch (OverflowException)
      {
         Console.WriteLine("Unable to convert '0x{0}' to a byte.", value);
      }   
      // </Snippet3>
   }

   private static void ConvertHexToByte()
   {
      // <Snippet4>
      // Create a negative hexadecimal value out of range of the Byte type.
      sbyte sourceNumber = SByte.MinValue;
      bool isSigned = Math.Sign((sbyte)sourceNumber.GetType().GetField("MinValue").GetValue(null)) == -1;
      string value = sourceNumber.ToString("X");
      byte targetNumber;
      try
      {
         targetNumber = Convert.ToByte(value, 16);
         if (isSigned && ((targetNumber & 0x80) != 0))
            throw new OverflowException();
         else 
            Console.WriteLine("0x{0} converts to {1}.", value, targetNumber);
      }
      catch (OverflowException)
      {
         Console.WriteLine("Unable to convert '0x{0}' to an unsigned byte.", value);
      } 
      // Displays the following to the console:
      //    Unable to convert '0x80' to an unsigned byte.     
      // </Snippet4>
   }

   private static void ConvertHexToNegativeShort()
   {
     // <Snippet5>
     // Create a hexadecimal value out of range of the Int16 type.
     string value = Convert.ToString((int) short.MaxValue + 1, 16);
     // Convert it back to a number.
     try
     {
        short number = Convert.ToInt16(value, 16);
        Console.WriteLine("0x{0} converts to {1}.", value, number);
     }
     catch (OverflowException)
     {
        Console.WriteLine("Unable to convert '0x{0}' to a 16-bit integer.", value);
     }   
     // </Snippet5>
   }
   
   private static void ConvertHexToShort()
   {
      // <Snippet6>
      // Create a hexadecimal value out of range of the Short type.
      int sourceNumber = (int) short.MaxValue + 1;
      bool isNegative = (Math.Sign(sourceNumber) == -1);
      string value = Convert.ToString(sourceNumber, 16);
      short targetNumber;
      try
      {
         targetNumber = Convert.ToInt16(value, 16);
         if (! isNegative && ((targetNumber & 0x8000) != 0))
            throw new OverflowException();
         else 
            Console.WriteLine("0x{0} converts to {1}.", value, targetNumber);
      }
      catch (OverflowException)
      {
         Console.WriteLine("Unable to convert '0x{0}' to a 16-bit integer.", value);
      } 
      // Displays the following to the console:
      //    Unable to convert '0x8000' to a 16-bit integer.     
      // </Snippet6>
   }

   private static void ConvertHexToNegativeLong()
   {
      // <Snippet7>
      // Create a hexadecimal value out of range of the long type.
      string value = ulong.MaxValue.ToString("X");
      // Use Convert.ToInt64 to convert it back to a number.
      try
      {
         long number = Convert.ToInt64(value, 16);
         Console.WriteLine("0x{0} converts to {1}.", value, number);
      }   
      catch (OverflowException)
      {
         Console.WriteLine("Unable to convert '0x{0}' to a long integer.", value);
      }   
      // </Snippet7>
   }

   private static void ConvertHexToLong()
   {
      // <Snippet8>
      // Create a negative hexadecimal value out of range of the Byte type.
      ulong sourceNumber = ulong.MaxValue;
      bool isSigned = Math.Sign(Convert.ToDouble(sourceNumber.GetType().GetField("MinValue").GetValue(null))) == -1;
      string value = sourceNumber.ToString("X");
      long targetNumber;
      try
      {
         targetNumber = Convert.ToInt64(value, 16);
         if (! isSigned && ((targetNumber & 0x80000000) != 0))
            throw new OverflowException();
         else 
            Console.WriteLine("0x{0} converts to {1}.", value, targetNumber);
      }
      catch (OverflowException)
      {
         Console.WriteLine("Unable to convert '0x{0}' to a long integer.", value);
      } 
      // Displays the following to the console:
      //    Unable to convert '0xFFFFFFFFFFFFFFFF' to a long integer.     
      // </Snippet8>
   }

   private static void ConvertHexToNegativeSByte()
   {
      // <Snippet9>
      // Create a hexadecimal value out of range of the SByte type.
      string value = Convert.ToString(byte.MaxValue, 16);
      // Convert it back to a number.
      try
      {
         sbyte number = Convert.ToSByte(value, 16);
         Console.WriteLine("0x{0} converts to {1}.", value, number);
      }   
      catch (OverflowException)
      {
         Console.WriteLine("Unable to convert '0x{0}' to a signed byte.", value);
      }   
      // </Snippet9>
   }

   private static void ConvertHexToSByte()
   {
      // <Snippet10>
      // Create a hexadecimal value out of range of the SByte type.
      byte sourceNumber = byte.MaxValue;
      bool isSigned = Math.Sign(Convert.ToDouble(sourceNumber.GetType().GetField("MinValue").GetValue(null))) == -1;
      string value = Convert.ToString(sourceNumber, 16);
      sbyte targetNumber;
      try
      {
         targetNumber = Convert.ToSByte(value, 16);
         if (! isSigned && ((targetNumber & 0x80) != 0))
            throw new OverflowException();
         else 
            Console.WriteLine("0x{0} converts to {1}.", value, targetNumber);
      }
      catch (OverflowException)
      {
         Console.WriteLine("Unable to convert '0x{0}' to a signed byte.", value);
      } 
      // Displays the following to the console:
      //    Unable to convert '0xff' to a signed byte.     
      // </Snippet10>
   }

   private static void ConvertNegativeHexToUInt16()
   {
      // <Snippet11>
      // Create a hexadecimal value out of range of the UInt16 type.
      string value = Convert.ToString(Int16.MinValue, 16);
      // Convert it back to a number.
      try
      {
         UInt16 number = Convert.ToUInt16(value, 16);
         Console.WriteLine("0x{0} converts to {1}.", value, number);
      }   
      catch (OverflowException)
      {
         Console.WriteLine("Unable to convert '0x{0}' to an unsigned short integer.", 
                           value);
      }   
      // </Snippet11>
   }

   private static void ConvertHexToUInt16()
   {
      // <Snippet12>
      // Create a negative hexadecimal value out of range of the UInt16 type.
      short sourceNumber = Int16.MinValue;
      bool isSigned = Math.Sign((short)sourceNumber.GetType().GetField("MinValue").GetValue(null)) == -1;
      string value = Convert.ToString(sourceNumber, 16);
      UInt16 targetNumber;
      try
      {
         targetNumber = Convert.ToUInt16(value, 16);
         if (isSigned && ((targetNumber & 0x8000) != 0))
            throw new OverflowException();
         else 
            Console.WriteLine("0x{0} converts to {1}.", value, targetNumber);
      }
      catch (OverflowException)
      {
         Console.WriteLine("Unable to convert '0x{0}' to an unsigned short integer.", value);
      } 
      // Displays the following to the console:
      //    Unable to convert '0x8000' to an unsigned short integer.     
      // </Snippet12>
   }

   private static void ConvertNegativeHexToUInt32()
   {
      // <Snippet13>
      // Create a hexadecimal value out of range of the UInt32 type.
      string value = Convert.ToString(Int32.MinValue, 16);
      // Convert it back to a number.
      try
      {
         UInt32 number = Convert.ToUInt32(value, 16);
         Console.WriteLine("0x{0} converts to {1}.", value, number);
      }   
      catch (OverflowException)
      {
         Console.WriteLine("Unable to convert '0x{0}' to an unsigned integer.", 
                           value);
      }   
      // </Snippet13>
   }

   private static void ConvertHexToUInt32()
   {
      // <Snippet14>
      // Create a negative hexadecimal value out of range of the UInt32 type.
      int sourceNumber = Int32.MinValue;
      bool isSigned = Math.Sign((int)sourceNumber.GetType().GetField("MinValue").GetValue(null)) == -1;
      string value = Convert.ToString(sourceNumber, 16);
      UInt32 targetNumber;
      try
      {
         targetNumber = Convert.ToUInt32(value, 16);
         if (isSigned && ((targetNumber & 0x80000000) != 0))
            throw new OverflowException();
         else 
            Console.WriteLine("0x{0} converts to {1}.", value, targetNumber);
      }
      catch (OverflowException)
      {
         Console.WriteLine("Unable to convert '0x{0}' to an unsigned integer.", 
                           value);
      } 
      // Displays the following to the console:
      //    Unable to convert '0x80000000' to an unsigned integer.     
      // </Snippet14>
   }

   private static void ConvertNegativeHexToUInt64()
   {
      // <Snippet15>
      // Create a hexadecimal value out of range of the UInt64 type.
      string value = Convert.ToString(Int64.MinValue, 16);
      // Convert it back to a number.
      try
      {
         UInt64 number = Convert.ToUInt64(value, 16);
         Console.WriteLine("0x{0} converts to {1}.", value, number);
      }   
      catch (OverflowException)
      {
         Console.WriteLine("Unable to convert '0x{0}' to an unsigned long integer.", 
                           value);
      }   
      // </Snippet15>
   }

   private static void ConvertHexToUInt64()
   {
      // <Snippet16>
      // Create a negative hexadecimal value out of range of the UInt64 type.
      long sourceNumber = Int64.MinValue;
      bool isSigned = Math.Sign((long)sourceNumber.GetType().GetField("MinValue").GetValue(null)) == -1;
      string value = Convert.ToString(sourceNumber, 16);
      UInt64 targetNumber;
      try
      {
         targetNumber = Convert.ToUInt64(value, 16);
         if (isSigned && ((targetNumber & 0x8000000000000000) != 0))
            throw new OverflowException();
         else 
            Console.WriteLine("0x{0} converts to {1}.", value, targetNumber);
      }
      catch (OverflowException)
      {
         Console.WriteLine("Unable to convert '0x{0}' to an unsigned long integer.", 
                           value);
      } 
      // Displays the following to the console:
      //    Unable to convert '0x8000000000000000' to an unsigned long integer.     
      // </Snippet16>
   }
}
