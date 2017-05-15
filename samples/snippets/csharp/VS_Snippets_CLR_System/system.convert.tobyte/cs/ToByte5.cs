// <Snippet15>
using System;

public class Example
{
   public static void Main()
   {
      String[] values = { null, "", "0xC9", "C9", "101", "16.3", 
                          "$12", "$12.01", "-4", "1,032", "255",
                          "   16  " };
      foreach (var value in values) {
         try {
            byte number = Convert.ToByte(value);
            Console.WriteLine("'{0}' --> {1}", 
                              value == null ? "<null>" : value, number);
         }
         catch (FormatException) {
            Console.WriteLine("Bad Format: '{0}'", 
                              value == null ? "<null>" : value);
         }
         catch (OverflowException) {
            Console.WriteLine("OverflowException: '{0}'", value);
         }
      }
   }
}
// The example displays the following output:
//     '<null>' --> 0
//     Bad Format: ''
//     Bad Format: '0xC9'
//     Bad Format: 'C9'
//     '101' --> 101
//     Bad Format: '16.3'
//     Bad Format: '$12'
//     Bad Format: '$12.01'
//     OverflowException: '-4'
//     Bad Format: '1,032'
//     '255' --> 255
//     '   16  ' --> 16
// </Snippet15>

