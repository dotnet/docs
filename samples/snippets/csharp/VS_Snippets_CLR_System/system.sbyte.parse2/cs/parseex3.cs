// <Snippet3>
using System;
using System.Globalization;

public class Example
{
   public static void Main()
   {
      NumberFormatInfo nf = new NumberFormatInfo();
      nf.NegativeSign = "~"; 
      
      string[] values = { "-103", "+12", "~16", "  1", "~255" };
      IFormatProvider[] providers = { nf, CultureInfo.InvariantCulture };
      
      foreach (IFormatProvider provider in providers)
      {
         Console.WriteLine("Conversions using {0}:", ((object) provider).GetType().Name);
         foreach (string value in values)
         {
            try {
               Console.WriteLine("   Converted '{0}' to {1}.", 
                                 value, SByte.Parse(value, provider));
            }                     
            catch (FormatException) {
               Console.WriteLine("   Unable to parse '{0}'.", value);   
            }
            catch (OverflowException) {
               Console.WriteLine("   '{0}' is out of range of the SByte type.", value);         
            }
         }
      }      
   }
}
// The example displays the following output:
//       Conversions using NumberFormatInfo:
//          Unable to parse '-103'.
//          Converted '+12' to 12.
//          Converted '~16' to -16.
//          Converted '  1' to 1.
//          '~255' is out of range of the SByte type.
//       Conversions using CultureInfo:
//          Converted '-103' to -103.
//          Converted '+12' to 12.
//          Unable to parse '~16'.
//          Converted '  1' to 1.
//          Unable to parse '~255'.
// </Snippet3>
