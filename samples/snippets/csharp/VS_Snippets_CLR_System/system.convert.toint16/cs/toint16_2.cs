// <Snippet14>
using System;

public class Example
{
   public static void Main()
   {
      string[] hexStrings = { "8000", "0FFF", "f000", "00A30", "D", "-13", 
                              "9AC61", "GAD" };
      foreach (string hexString in hexStrings)
      {
         try {
            short number = Convert.ToInt16(hexString, 16);
            Console.WriteLine("Converted '{0}' to {1:N0}.", hexString, number);
         }
         catch (FormatException) {
            Console.WriteLine("'{0}' is not in the correct format for a hexadecimal number.", 
                              hexString);
         }
         catch (OverflowException) {
            Console.WriteLine("'{0}' is outside the range of an Int16.", hexString);
         }
         catch (ArgumentException) {
            Console.WriteLine("'{0}' is invalid in base 16.", hexString);
         }
      }                                            
   }
}
// The example displays the following output:
//       Converted '8000' to -32,768.
//       Converted '0FFF' to 4,095.
//       Converted 'f000' to -4,096.
//       Converted '00A30' to 2,608.
//       Converted 'D' to 13.
//       '-13' is invalid in base 16.
//       '9AC61' is outside the range of an Int16.
//       'GAD' is not in the correct format for a hexadecimal number.
// </Snippet14>
