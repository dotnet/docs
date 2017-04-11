// <Snippet3>
using System;

public class Example
{
   public static void Main()
   {
       // Define a byte array.
       Byte[] bytes = new Byte[100];
       int originalTotal = 0;
       for (int ctr = 0; ctr <= bytes.GetUpperBound(0); ctr++) {
          bytes[ctr] = (byte)(ctr + 1);
          originalTotal += bytes[ctr];
       }
       // Display summary information about the array.
       Console.WriteLine("The original byte array:");
       Console.WriteLine("   Total elements: {0}", bytes.Length);
       Console.WriteLine("   Length of String Representation: {0}",
                         BitConverter.ToString(bytes).Length);
       Console.WriteLine("   Sum of elements: {0:N0}", originalTotal);                  
       Console.WriteLine();
       
       // Convert the array to a base 64 sring.
       String s = Convert.ToBase64String(bytes, 
                                         Base64FormattingOptions.InsertLineBreaks);
       Console.WriteLine("The base 64 string:\n   {0}\n", s);
       
       // Restore the byte array.
       Byte[] newBytes = Convert.FromBase64String(s);
       int newTotal = 0;
       foreach (var newByte in newBytes)
          newTotal += newByte;

       // Display summary information about the restored array.
       Console.WriteLine("   Total elements: {0}", newBytes.Length);
       Console.WriteLine("   Length of String Representation: {0}",
                         BitConverter.ToString(newBytes).Length);
       Console.WriteLine("   Sum of elements: {0:N0}", newTotal);                  
   }
}
// The example displays the following output:
//   The original byte array:
//      Total elements: 100
//      Length of String Representation: 299
//      Sum of elements: 5,050
//   
//   The base 64 string:
//      AQIDBAUGBwgJCgsMDQ4PEBESExQVFhcYGRobHB0eHyAhIiMkJSYnKCkqKywtLi8wMTIzNDU2Nzg5
//   Ojs8PT4/QEFCQ0RFRkdISUpLTE1OT1BRUlNUVVZXWFlaW1xdXl9gYWJjZA==
//   
//      Total elements: 100
//      Length of String Representation: 299
//      Sum of elements: 5,050
// </Snippet3>

