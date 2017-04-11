// <Snippet2>
using System;
using System.Globalization;

public class ParseSample
{
   public static void Main()
   {
      string value; 
      NumberStyles style;
      
      // Parse a number with a thousands separator (throws an exception).
      value = "14,644";
      style = NumberStyles.None;
      ParseToInt16(value, style);
      
      style = NumberStyles.AllowThousands;
      ParseToInt16(value, style);
      
      // Parse a number with a thousands separator and decimal point.
      value = "14,644.00";
      style = NumberStyles.AllowThousands | NumberStyles.Integer |
              NumberStyles.AllowDecimalPoint;
      ParseToInt16(value, style);
      
      // Parse a number with a fractional component (throws an exception).
      value = "14,644.001";
      ParseToInt16(value, style);
      
      // Parse a number in exponential notation.
      value = "145E02";
      style = style | NumberStyles.AllowExponent;
      ParseToInt16(value, style);
      
      // Parse a number in exponential notation with a positive sign.
      value = "145E+02";
      ParseToInt16(value, style);
      
      // Parse a number in exponential notation with a negative sign
      // (throws an exception).
      value = "145E-02";
      ParseToInt16(value, style);
   }

   private static void ParseToInt16(string value, NumberStyles style)
   {
      try
      {
         short number = Int16.Parse(value, style);
         Console.WriteLine("Converted '{0}' to {1}.", value, number);
      }
      catch (FormatException)
      {
         Console.WriteLine("Unable to parse '{0}' with style {1}.", value, 
                           style.ToString());
      }
      catch (OverflowException)
      {
         Console.WriteLine("'{0}' is out of range of the Int16 type.", value);
      }
   }   
}
// The example displays the following output to the console:
//       Unable to parse '14,644' with style None.
//       Converted '14,644' to 14644.
//       Converted '14,644.00' to 14644.
//       '14,644.001' is out of range of the Int16 type.
//       Converted '145E02' to 14500.
//       Converted '145E+02' to 14500.
//       '145E-02' is out of range of the Int16 type.
// </Snippet2>
