// <Snippet3>
using System;
using System.Globalization;

public class Example
{
   public static void Main()
   {
      // Define a custom culture that uses "++" as a positive sign. 
      CultureInfo ci = new CultureInfo("");
      ci.NumberFormat.PositiveSign = "++";
      // Create an array of cultures.
      CultureInfo[] cultures = { ci, CultureInfo.InvariantCulture };
      // Create an array of strings to parse.
      string[] values = { "++1403", "-0", "+0", "+16034", 
                          Int16.MinValue.ToString(), "14.0", "18012" };
      // Parse the strings using each culture.
      foreach (CultureInfo culture in cultures)
      {
         Console.WriteLine("Parsing with the '{0}' culture.", culture.Name);
         foreach (string value in values)
         {
            try {
               ushort number = UInt16.Parse(value, culture);
               Console.WriteLine("   Converted '{0}' to {1}.", value, number);
            }
            catch (FormatException) {
               Console.WriteLine("   The format of '{0}' is invalid.", value);
            }
            catch (OverflowException) {
               Console.WriteLine("   '{0}' is outside the range of a UInt16 value.", value);
            }               
         }
      }
   }
}
// The example displays the following output:
//       Parsing with the  culture.
//          Converted '++1403' to 1403.
//          Converted '-0' to 0.
//          The format of '+0' is invalid.
//          The format of '+16034' is invalid.
//          '-32768' is outside the range of a UInt16 value.
//          The format of '14.0' is invalid.
//          Converted '18012' to 18012.
//       Parsing with the '' culture.
//          The format of '++1403' is invalid.
//          Converted '-0' to 0.
//          Converted '+0' to 0.
//          Converted '+16034' to 16034.
//          '-32768' is outside the range of a UInt16 value.
//          The format of '14.0' is invalid.
//          Converted '18012' to 18012.
// </Snippet3>
