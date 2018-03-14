// <Snippet15>
using System;
using System.Globalization;

public class Example
{
   public static void Main()
   {
      // Create a custom NumberFormatInfo object and set its two properties
      // used by default in parsing numeric strings.
      NumberFormatInfo customProvider = new NumberFormatInfo();
      customProvider.NegativeSign = "neg ";
      customProvider.PositiveSign = "pos ";

      // Add custom and invariant provider to an array of providers.
      NumberFormatInfo[] providers = { customProvider, NumberFormatInfo.InvariantInfo };
      
      // Define an array of strings to convert.
      string[] numericStrings = { "123456789", "+123456789", "pos 123456789",
                                  "-123456789", "neg 123456789", "123456789.",
                                  "123,456,789", "(123456789)", "2147483648",
                                  "-2147483649" }; 
      
      // Use each provider to parse all the numeric strings.
      for (int ctr = 0; ctr <= 1; ctr++)
      {
         IFormatProvider provider = providers[ctr];
         Console.WriteLine(ctr == 0 ? "Custom Provider:" : "Invariant Provider:");
         foreach (string numericString in numericStrings)
         {
            Console.Write("{0,15}  --> ", numericString);
            try {
               Console.WriteLine("{0,20}", Convert.ToInt32(numericString, provider));
            }
            catch (FormatException) {
               Console.WriteLine("{0,20}", "FormatException");
            }    
            catch (OverflowException) {
               Console.WriteLine("{0,20}", "OverflowException");                 
            }
         }
         Console.WriteLine();
      }                  
   }
}
// The example displays the following output:
//       Custom Provider:
//             123456789  -->            123456789
//            +123456789  -->      FormatException
//         pos 123456789  -->            123456789
//            -123456789  -->      FormatException
//         neg 123456789  -->           -123456789
//            123456789.  -->      FormatException
//           123,456,789  -->      FormatException
//           (123456789)  -->      FormatException
//            2147483648  -->    OverflowException
//           -2147483649  -->      FormatException
//       
//       Invariant Provider:
//             123456789  -->            123456789
//            +123456789  -->            123456789
//         pos 123456789  -->      FormatException
//            -123456789  -->           -123456789
//         neg 123456789  -->      FormatException
//            123456789.  -->      FormatException
//           123,456,789  -->      FormatException
//           (123456789)  -->      FormatException
//            2147483648  -->    OverflowException
//           -2147483649  -->    OverflowException
// </Snippet15>
