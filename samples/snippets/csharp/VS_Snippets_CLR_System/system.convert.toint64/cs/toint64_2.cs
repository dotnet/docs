// <Snippet15>
using System;

public class Example
{
   public static void Main()
   {
      string[] hexStrings = { "8000000000000000", "0FFFFFFFFFFFFFFF", 
                              "f0000000000001000", "00A30", "D", "-13", "GAD" };
      foreach (string hexString in hexStrings)
      {
         try {
            long number = Convert.ToInt64(hexString, 16);
            Console.WriteLine("Converted '{0}' to {1:N0}.", hexString, number);
         }
         catch (FormatException) {
            Console.WriteLine("'{0}' is not in the correct format for a hexadecimal number.",
                              hexString);
         }
         catch (OverflowException) {
            Console.WriteLine("'{0}' is outside the range of an Int64.", hexString);
         }
         catch (ArgumentException) {
            Console.WriteLine("'{0}' is invalid in base 16.", hexString);
         }
      }                                            
   }
}
// The example displays the following output:
//       Converted '8000000000000000' to -9,223,372,036,854,775,808.
//       Converted '0FFFFFFFFFFFFFFF' to 1,152,921,504,606,846,975.
//       'f0000000000001000' is outside the range of an Int64.
//       Converted '00A30' to 2,608.
//       Converted 'D' to 13.
//       '-13' is invalid in base 16.
//       'GAD' is not in the correct format for a hexadecimal number.
// </Snippet15>
