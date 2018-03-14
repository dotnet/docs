// <Snippet16>
using System;
using System.Globalization;

public class Example
{
   public static void Main()
   {
      // Create a NumberFormatInfo object and set the properties that
      // affect conversions using Convert.ToInt64(String, IFormatProvider).
      NumberFormatInfo customProvider = new NumberFormatInfo();
      customProvider.NegativeSign = "neg ";
      customProvider.PositiveSign = "pos ";

      // Create an array of providers with the custom provider and the
      // NumberFormatInfo object for the invariant culture.
      NumberFormatInfo[] providers = { customProvider,
                                       NumberFormatInfo.InvariantInfo };
      
      // Define an array of strings to parse.
      string[] numericStrings = { "123456789", "+123456789", "pos 123456789", 
                                  "-123456789", "neg 123456789", "123456789.",
                                  "123,456,789", "(123456789)",
                                  "9223372036854775808", "-9223372036854775809" };

      for (int ctr = 0; ctr < 2; ctr++)
      {
         IFormatProvider provider = providers[ctr];
         Console.WriteLine(ctr == 0 ? "Custom Provider:" : "Invariant Culture:");
         foreach (string numericString in numericStrings)
         {
            Console.Write("   {0,-22} -->  ", numericString);
            try {
               Console.WriteLine("{0,22}", Convert.ToInt32(numericString, provider));
            }
            catch (FormatException) {
               Console.WriteLine("{0,22}", "Unrecognized Format");
            }   
            catch (OverflowException) {
               Console.WriteLine("{0,22}", "Overflow");
            }
         }
         Console.WriteLine();
      }
   }
}
// The example displays the following output:
//       Custom Provider:
//          123456789              -->               123456789
//          +123456789             -->     Unrecognized Format
//          pos 123456789          -->               123456789
//          -123456789             -->     Unrecognized Format
//          neg 123456789          -->              -123456789
//          123456789.             -->     Unrecognized Format
//          123,456,789            -->     Unrecognized Format
//          (123456789)            -->     Unrecognized Format
//          9223372036854775808    -->                Overflow
//          -9223372036854775809   -->     Unrecognized Format
//       
//       Invariant Culture:
//          123456789              -->               123456789
//          +123456789             -->               123456789
//          pos 123456789          -->     Unrecognized Format
//          -123456789             -->              -123456789
//          neg 123456789          -->     Unrecognized Format
//          123456789.             -->     Unrecognized Format
//          123,456,789            -->     Unrecognized Format
//          (123456789)            -->     Unrecognized Format
//          9223372036854775808    -->                Overflow
//          -9223372036854775809   -->                Overflow
// </Snippet16>
