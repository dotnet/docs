// <Snippet4>
using System;
using System.Globalization;

public class Example
{
   public static void Main()
   {
      string[] cultureNames= { "en-US", "fr-FR" };
      NumberStyles[] styles= { NumberStyles.Integer,
                               NumberStyles.Integer | NumberStyles.AllowDecimalPoint };
      string[] values = { "170209", "+170209.0", "+170209,0", "-103214.00",
                                 "-103214,00", "104561.1", "104561,1" };
      
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
                                    UInt64.Parse(value, style, ci));
               }
               catch (FormatException) {
                  Console.WriteLine("      Unable to parse '{0}'.", value);
               }      
               catch (OverflowException) {
                  Console.WriteLine("      '{0}' is out of range of the UInt64 type.",
                                    value);
               }
            }
         }
      }                                    
   }
}
// The example displays the following output:
//       Style: Integer
//          Converted '170209' to 170209.
//          Unable to parse '+170209.0'.
//          Unable to parse '+170209,0'.
//          Unable to parse '-103214.00'.
//          Unable to parse '-103214,00'.
//          Unable to parse '104561.1'.
//          Unable to parse '104561,1'.
//       Style: Integer, AllowDecimalPoint
//          Converted '170209' to 170209.
//          Converted '+170209.0' to 170209.
//          Unable to parse '+170209,0'.
//          '-103214.00' is out of range of the UInt64 type.
//          Unable to parse '-103214,00'.
//          '104561.1' is out of range of the UInt64 type.
//          Unable to parse '104561,1'.
//    Parsing strings using the French (France) culture
//       Style: Integer
//          Converted '170209' to 170209.
//          Unable to parse '+170209.0'.
//          Unable to parse '+170209,0'.
//          Unable to parse '-103214.00'.
//          Unable to parse '-103214,00'.
//          Unable to parse '104561.1'.
//          Unable to parse '104561,1'.
//       Style: Integer, AllowDecimalPoint
//          Converted '170209' to 170209.
//          Unable to parse '+170209.0'.
//          Converted '+170209,0' to 170209.
//          Unable to parse '-103214.00'.
//          '-103214,00' is out of range of the UInt64 type.
//          Unable to parse '104561.1'.
//          '104561,1' is out of range of the UInt64 type.
// </Snippet4>
