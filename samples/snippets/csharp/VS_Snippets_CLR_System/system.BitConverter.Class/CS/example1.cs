// <Snippet3>
using System;

public class Example
{
   public static void Main()
   {
      int value = -16;
      Byte[] bytes = BitConverter.GetBytes(value); 
      
      // Convert bytes back to Int32.
      int intValue = BitConverter.ToInt32(bytes, 0);
      Console.WriteLine("{0} = {1}: {2}", 
                        value, intValue, 
                        value.Equals(intValue) ? "Round-trips" : "Does not round-trip");
      // Convert bytes to UInt32.
      uint uintValue = BitConverter.ToUInt32(bytes, 0);
      Console.WriteLine("{0} = {1}: {2}", value, uintValue, 
                        value.Equals(uintValue) ? "Round-trips" : "Does not round-trip");
   }
}
// The example displays the following output:
//       -16 = -16: Round-trips
//       -16 = 4294967280: Does not round-trip
// </Snippet3>
