// <Snippet11>
using System;

public class Example
{
   public static void Main()
   {
      int[] bases = { 2, 8, 10, 16 };
      string[] values = { "-1", "1", "08", "0F", "11" , "12", "30",                
                          "101", "255", "FF", "10000000", "80" };
      byte number;
      foreach (int numBase in bases)
      {
         Console.WriteLine("Base {0}:", numBase);
         foreach (string value in values)
         {
            try {
               number = Convert.ToByte(value, numBase);
               Console.WriteLine("   Converted '{0}' to {1}.", value, number);
            }   
            catch (FormatException) {
               Console.WriteLine("   '{0}' is not in the correct format for a base {1} byte value.", 
                                 value, numBase);
            }                     
            catch (OverflowException) {
               Console.WriteLine("   '{0}' is outside the range of the Byte type.", value);
            }   
            catch (ArgumentException) {
               Console.WriteLine("   '{0}' is invalid in base {1}.", value, numBase);
            }
         }                                 
      } 
   }
}
// The example displays the following output:
//    Base 2:
//       '-1' is invalid in base 2.
//       Converted '1' to 1.
//       '08' is not in the correct format for a base 2 conversion.
//       '0F' is not in the correct format for a base 2 conversion.
//       Converted '11' to 3.
//       '12' is not in the correct format for a base 2 conversion.
//       '30' is not in the correct format for a base 2 conversion.
//       Converted '101' to 5.
//       '255' is not in the correct format for a base 2 conversion.
//       'FF' is not in the correct format for a base 2 conversion.
//       Converted '10000000' to 128.
//       '80' is not in the correct format for a base 2 conversion.
//    Base 8:
//       '-1' is invalid in base 8.
//       Converted '1' to 1.
//       '08' is not in the correct format for a base 8 conversion.
//       '0F' is not in the correct format for a base 8 conversion.
//       Converted '11' to 9.
//       Converted '12' to 10.
//       Converted '30' to 24.
//       Converted '101' to 65.
//       Converted '255' to 173.
//       'FF' is not in the correct format for a base 8 conversion.
//       '10000000' is outside the range of the Byte type.
//       '80' is not in the correct format for a base 8 conversion.
//    Base 10:
//       '-1' is outside the range of the Byte type.
//       Converted '1' to 1.
//       Converted '08' to 8.
//       '0F' is not in the correct format for a base 10 conversion.
//       Converted '11' to 11.
//       Converted '12' to 12.
//       Converted '30' to 30.
//       Converted '101' to 101.
//       Converted '255' to 255.
//       'FF' is not in the correct format for a base 10 conversion.
//       '10000000' is outside the range of the Byte type.
//       Converted '80' to 80.
//    Base 16:
//       '-1' is invalid in base 16.
//       Converted '1' to 1.
//       Converted '08' to 8.
//       Converted '0F' to 15.
//       Converted '11' to 17.
//       Converted '12' to 18.
//       Converted '30' to 48.
//       '101' is outside the range of the Byte type.
//       '255' is outside the range of the Byte type.
//       Converted 'FF' to 255.
//       '10000000' is outside the range of the Byte type.
//       Converted '80' to 128.
// </Snippet11>
