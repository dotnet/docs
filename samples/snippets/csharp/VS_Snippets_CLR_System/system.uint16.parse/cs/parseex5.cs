// <Snippet5>
using System;

public class Example
{
   public static void Main()
   {
      string[] values = { "-0", "17", "-12", "185", "66012", "+0", 
                          "", null, "16.1", "28.0", "1,034" };
      foreach (string value in values)
      {
         try {
            ushort number = UInt16.Parse(value);
            Console.WriteLine("'{0}' --> {1}", value, number);
         }
         catch (FormatException) {
            Console.WriteLine("'{0}' --> Bad Format", value);
         }
         catch (OverflowException) {   
            Console.WriteLine("'{0}' --> OverflowException", value);
         }
         catch (ArgumentNullException) {
            Console.WriteLine("'{0}' --> Null", value);
         }
      }                                 
   }
}
// The example displays the following output:
//       '-0' --> 0
//       '17' --> 17
//       '-12' --> OverflowException
//       '185' --> 185
//       '66012' --> OverflowException
//       '+0' --> 0
//       '' --> Bad Format
//       '' --> Null
//       '16.1' --> Bad Format
//       '28.0' --> Bad Format
//       '1,034' --> Bad Format
// </Snippet5>
