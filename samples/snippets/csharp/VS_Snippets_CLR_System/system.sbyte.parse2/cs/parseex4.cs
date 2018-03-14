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
      string[] values = { "-17", "-17.0", "-17,0", "+103.00", "+103,00" };
      
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
                                    SByte.Parse(value, style, ci));
               }                                    
               catch (FormatException) {
                  Console.WriteLine("      Unable to parse '{0}'.", value);   
               }
               catch (OverflowException) {
                  Console.WriteLine("      '{0}' is out of range of the SByte type.", 
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
//             Converted '-17' to -17.
//             Unable to parse '-17.0'.
//             Unable to parse '-17,0'.
//             Unable to parse '+103.00'.
//             Unable to parse '+103,00'.
//          Style: Integer, AllowDecimalPoint
//             Converted '-17' to -17.
//             Converted '-17.0' to -17.
//             Unable to parse '-17,0'.
//             Converted '+103.00' to 103.
//             Unable to parse '+103,00'.
//       Parsing strings using the French (France) culture
//          Style: Integer
//             Converted '-17' to -17.
//             Unable to parse '-17.0'.
//             Unable to parse '-17,0'.
//             Unable to parse '+103.00'.
//             Unable to parse '+103,00'.
//          Style: Integer, AllowDecimalPoint
//             Converted '-17' to -17.
//             Unable to parse '-17.0'.
//             Converted '-17,0' to -17.
//             Unable to parse '+103.00'.
//             Converted '+103,00' to 103.
// </Snippet4>
