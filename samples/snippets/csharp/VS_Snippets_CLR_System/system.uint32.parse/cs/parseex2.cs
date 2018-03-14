// <Snippet2>
using System;
using System.Globalization;

public class Example
{
   public static void Main()
   {
      string[] values= { " 214309 ", "1,064,181", "(0)", "10241+", " + 21499 ", 
                         " +21499 ", "122153.00", "1e03ff", "91300.0e-2" };
      NumberStyles whitespace =  NumberStyles.AllowLeadingWhite | NumberStyles.AllowTrailingWhite;
      NumberStyles[] styles= { NumberStyles.None, whitespace, 
                               NumberStyles.AllowLeadingSign | NumberStyles.AllowTrailingSign | whitespace, 
                               NumberStyles.AllowThousands | NumberStyles.AllowCurrencySymbol, 
                               NumberStyles.AllowExponent | NumberStyles.AllowDecimalPoint };

      // Attempt to convert each number using each style combination.
      foreach (string value in values)
      {
         Console.WriteLine("Attempting to convert '{0}':", value);
         foreach (NumberStyles style in styles)
         {
            try {
               uint number = UInt32.Parse(value, style);
               Console.WriteLine("   {0}: {1}", style, number);
            }   
            catch (FormatException) {
               Console.WriteLine("   {0}: Bad Format", style);
            }   
            catch (OverflowException)
            {
               Console.WriteLine("   {0}: Overflow", value);         
            }         
         }
         Console.WriteLine();
      }
   }
}
// The example displays the following output:
//    Attempting to convert ' 214309 ':
//       None: Bad Format
//       AllowLeadingWhite, AllowTrailingWhite: 214309
//       Integer, AllowTrailingSign: 214309
//       AllowThousands, AllowCurrencySymbol: Bad Format
//       AllowDecimalPoint, AllowExponent: Bad Format
//    
//    Attempting to convert '1,064,181':
//       None: Bad Format
//       AllowLeadingWhite, AllowTrailingWhite: Bad Format
//       Integer, AllowTrailingSign: Bad Format
//       AllowThousands, AllowCurrencySymbol: 1064181
//       AllowDecimalPoint, AllowExponent: Bad Format
//    
//    Attempting to convert '(0)':
//       None: Bad Format
//       AllowLeadingWhite, AllowTrailingWhite: Bad Format
//       Integer, AllowTrailingSign: Bad Format
//       AllowThousands, AllowCurrencySymbol: Bad Format
//       AllowDecimalPoint, AllowExponent: Bad Format
//    
//    Attempting to convert '10241+':
//       None: Bad Format
//       AllowLeadingWhite, AllowTrailingWhite: Bad Format
//       Integer, AllowTrailingSign: 10241
//       AllowThousands, AllowCurrencySymbol: Bad Format
//       AllowDecimalPoint, AllowExponent: Bad Format
//    
//    Attempting to convert ' + 21499 ':
//       None: Bad Format
//       AllowLeadingWhite, AllowTrailingWhite: Bad Format
//       Integer, AllowTrailingSign: Bad Format
//       AllowThousands, AllowCurrencySymbol: Bad Format
//       AllowDecimalPoint, AllowExponent: Bad Format
//    
//    Attempting to convert ' +21499 ':
//       None: Bad Format
//       AllowLeadingWhite, AllowTrailingWhite: Bad Format
//       Integer, AllowTrailingSign: 21499
//       AllowThousands, AllowCurrencySymbol: Bad Format
//       AllowDecimalPoint, AllowExponent: Bad Format
//    
//    Attempting to convert '122153.00':
//       None: Bad Format
//       AllowLeadingWhite, AllowTrailingWhite: Bad Format
//       Integer, AllowTrailingSign: Bad Format
//       AllowThousands, AllowCurrencySymbol: Bad Format
//       AllowDecimalPoint, AllowExponent: 122153
//    
//    Attempting to convert '1e03ff':
//       None: Bad Format
//       AllowLeadingWhite, AllowTrailingWhite: Bad Format
//       Integer, AllowTrailingSign: Bad Format
//       AllowThousands, AllowCurrencySymbol: Bad Format
//       AllowDecimalPoint, AllowExponent: Bad Format
//    
//    Attempting to convert '91300.0e-2':
//       None: Bad Format
//       AllowLeadingWhite, AllowTrailingWhite: Bad Format
//       Integer, AllowTrailingSign: Bad Format
//       AllowThousands, AllowCurrencySymbol: Bad Format
//       AllowDecimalPoint, AllowExponent: 913
// </Snippet2>