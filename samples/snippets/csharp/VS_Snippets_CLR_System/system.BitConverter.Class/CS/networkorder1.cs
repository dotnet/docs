// <Snippet4>
using System;

public class Example
{
   public static void Main()
   {
      int value = 12345678;
      byte[] bytes = BitConverter.GetBytes(value);
      Console.WriteLine(BitConverter.ToString(bytes));
      
      if (BitConverter.IsLittleEndian)
         Array.Reverse(bytes); 

      Console.WriteLine(BitConverter.ToString(bytes));
      // Call method to send byte stream across machine boundaries.
      
      // Receive byte stream from beyond machine boundaries.
      Console.WriteLine(BitConverter.ToString(bytes));
      if (BitConverter.IsLittleEndian)
         Array.Reverse(bytes);

      Console.WriteLine(BitConverter.ToString(bytes));
      int result = BitConverter.ToInt32(bytes, 0);
      Console.WriteLine("Original value: {0}", value);
      Console.WriteLine("Returned value: {0}", result);
   }
}
// The example displays the following output on a little-endian system:
//       4E-61-BC-00
//       00-BC-61-4E
//       00-BC-61-4E
//       4E-61-BC-00
//       Original value: 12345678
//       Returned value: 12345678
// </Snippet4>
