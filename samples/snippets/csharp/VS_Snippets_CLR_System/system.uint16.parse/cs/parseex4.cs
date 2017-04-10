// <Snippet4>
using System;
using System.Globalization;

public class Example
{
   public static void Main()
   {
      string[] cultureNames = { "en-US", "fr-FR" };
      NumberStyles[] styles= { NumberStyles.Integer, 
                               NumberStyles.Integer | NumberStyles.AllowDecimalPoint };
      string[] values = { "1702", "+1702.0", "+1702,0", "-1032.00",
                          "-1032,00", "1045.1", "1045,1" };
      
      // Parse strings using each culture
      foreach (string cultureName in cultureNames)
      {
         CultureInfo ci = new CultureInfo(cultureName);
         Console.WriteLine("Parsing strings using the {0} culture", 
                           ci.DisplayName);
         // Use each style.
         foreach (NumberStyles style in styles)
         {
            Console.WriteLine("   Style: {0}", style.ToString());
            // Parse each numeric string.
            foreach (string value in values)
            {
               try {
                  Console.WriteLine("      Converted '{0}' to {1}.", value, 
                                    UInt16.Parse(value, style, ci));
               }                                    
               catch (FormatException) {
                  Console.WriteLine("      Unable to parse '{0}'.", value);   
               }
               catch (OverflowException) {
                  Console.WriteLine("      '{0}' is out of range of the UInt16 type.", 
                                    value);
               }
            }
         }
      }   
   }
}
// The example displays the following output:
//       Parsing strings using the English (United States) culture
//          Style: Integer
//             Converted '1702' to 1702.
//             Unable to parse '+1702.0'.
//             Unable to parse '+1702,0'.
//             Unable to parse '-1032.00'.
//             Unable to parse '-1032,00'.
//             Unable to parse '1045.1'.
//             Unable to parse '1045,1'.
//          Style: Integer, AllowDecimalPoint
//             Converted '1702' to 1702.
//             Converted '+1702.0' to 1702.
//             Unable to parse '+1702,0'.
//             '-1032.00' is out of range of the UInt16 type.
//             Unable to parse '-1032,00'.
//             '1045.1' is out of range of the UInt16 type.
//             Unable to parse '1045,1'.
//       Parsing strings using the French (France) culture
//          Style: Integer
//             Converted '1702' to 1702.
//             Unable to parse '+1702.0'.
//             Unable to parse '+1702,0'.
//             Unable to parse '-1032.00'.
//             Unable to parse '-1032,00'.
//             Unable to parse '1045.1'.
//             Unable to parse '1045,1'.
//          Style: Integer, AllowDecimalPoint
//             Converted '1702' to 1702.
//             Unable to parse '+1702.0'.
//             Converted '+1702,0' to 1702.
//             Unable to parse '-1032.00'.
//             '-1032,00' is out of range of the UInt16 type.
//             Unable to parse '1045.1'.
//             '1045,1' is out of range of the UInt16 type.
// </Snippet4>
