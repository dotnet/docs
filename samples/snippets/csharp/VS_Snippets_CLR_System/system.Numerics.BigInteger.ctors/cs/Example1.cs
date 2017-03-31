using System;
using System.Numerics;

public class Example
{
   public static void Main()
   {
      Console.WindowWidth = 90;
      CreateSimpleArray();
      Console.WriteLine();
      RoundtripValue();
      Console.WriteLine();
      EnsureSign();
   }

   private static void CreateSimpleArray()
   {
      // <Snippet1>
      byte[] bytes = { 5, 4, 3, 2, 1 };
      BigInteger number = new BigInteger(bytes);
      Console.WriteLine("The value of number is {0} (or 0x{0:x}).", number); 
      // The example displays the following output:
      //    The value of number is 4328719365 (or 0x102030405).   
      // </Snippet1>
   }
   
   private static void RoundtripValue()
   {
      // <Snippet2>
      // Instantiate BigInteger values.
      BigInteger positiveValue = BigInteger.Parse("4713143110832790377889");
      BigInteger negativeValue = BigInteger.Add(-Int64.MaxValue, -60000); 
      BigInteger positiveValue2, negativeValue2;
      
      // Create two byte arrays.
      byte[] positiveBytes = positiveValue.ToByteArray();
      byte[] negativeBytes = negativeValue.ToByteArray();
      
      // Instantiate new BigInteger from negativeBytes array.
      Console.Write("Converted {0:N0} to the byte array ", negativeValue);
      foreach (byte byteValue in negativeBytes)
         Console.Write("{0:X2} ", byteValue);
      Console.WriteLine();
      negativeValue2 = new BigInteger(negativeBytes);
      Console.WriteLine("Converted the byte array to {0:N0}", negativeValue2);
      Console.WriteLine();
      
      // Instantiate new BigInteger from positiveBytes array.
      Console.Write("Converted {0:N0} to the byte array ", positiveValue);
      foreach (byte byteValue in positiveBytes)
         Console.Write("{0:X2} ", byteValue);
      Console.WriteLine();
      positiveValue2 = new BigInteger(positiveBytes);
      Console.WriteLine("Converted the byte array to {0:N0}", positiveValue2);
      Console.WriteLine();
      // The example displays the following output:
      //    Converted -9,223,372,036,854,835,807 to the byte array A1 15 FF FF FF FF FF 7F FF
      //    Converted the byte array to -9,223,372,036,854,835,807
      //    
      //    Converted 4,713,143,110,832,790,377,889 to the byte array A1 15 FF FF FF FF FF 7F FF 00
      //    Converted the byte array to 4,713,143,110,832,790,377,889
      // </Snippet2>
   }
   
   private static void EnsureSign()
   {
      // <Snippet3>
      ulong originalNumber = UInt64.MaxValue;
      byte[] bytes = BitConverter.GetBytes(originalNumber);
      if (originalNumber > 0 && (bytes[bytes.Length - 1] & 0x80) > 0) 
      {
         byte[] temp = new byte[bytes.Length];
         Array.Copy(bytes, temp, bytes.Length);
         bytes = new byte[temp.Length + 1];
         Array.Copy(temp, bytes, temp.Length);
      }
      
      BigInteger newNumber = new BigInteger(bytes);
      Console.WriteLine("Converted the UInt64 value {0:N0} to {1:N0}.", 
                        originalNumber, newNumber); 
      // The example displays the following output:
      //    Converted the UInt64 value 18,446,744,073,709,551,615 to 18,446,744,073,709,551,615.
      // </Snippet3>
   }
}
