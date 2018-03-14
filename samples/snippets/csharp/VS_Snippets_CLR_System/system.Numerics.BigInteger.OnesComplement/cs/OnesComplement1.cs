// <Snippet1>
using System;
using System.Numerics;

public class Example
{
   public static void Main()
   {
      BigInteger value, complement;
      
      value = BigInteger.Multiply(BigInteger.One, 9);
      complement = ~value;
      
      Console.WriteLine("{0,5} -- {1,-32}", value, DisplayInBinary(value));
      Console.WriteLine("{0,5} -- {1,-32}\n", complement, DisplayInBinary(complement));
   
      value = BigInteger.MinusOne * SByte.MaxValue;
      complement = ~value;
      
      Console.WriteLine("{0,5} -- {1,-32}", value, DisplayInBinary(value));
      Console.WriteLine("{0,5} -- {1,-32}\n", complement, DisplayInBinary(complement));
   } 

   private static string DisplayInBinary(BigInteger number)
   {
      byte[] bytes = number.ToByteArray();  
      string binaryString = string.Empty;
      foreach (byte byteValue in bytes)
      {
         string byteString = Convert.ToString(byteValue, 2).Trim();
         binaryString += byteString.Insert(0, new string('0', 8 - byteString.Length));
      }
      return binaryString;    
   }
}
// The example displays the following output:
//           9 -- 00001001
//         -10 -- 11110110
//       
//        -127 -- 10000001
//         126 -- 01111110
// </Snippet1>