// <Snippet2>
using System;
using System.Globalization;

public class Example
{
   public static void Main()
   {
      string numericString;
      NumberStyles styles;
      
      numericString = "10603";
      styles = NumberStyles.Integer;
      CallTryParse(numericString, styles);
      
      numericString = "-10603";
      styles = NumberStyles.None;
      CallTryParse(numericString, styles);
      
      numericString = "29103.00";
      styles = NumberStyles.Integer | NumberStyles.AllowDecimalPoint;
      CallTryParse(numericString, styles);
      
      numericString = "10345.72";
      styles = NumberStyles.Integer | NumberStyles.AllowDecimalPoint;
      CallTryParse(numericString, styles);

      numericString = "2210E-01";
      styles = NumberStyles.Integer | NumberStyles.AllowExponent;
      CallTryParse(numericString, styles); 
      
      numericString = "9112E-01";
      CallTryParse(numericString, styles);
          
      numericString = "312E01";
      CallTryParse(numericString, styles); 
      
      numericString = "FFC8";
      CallTryParse(numericString, NumberStyles.HexNumber);
      
      numericString = "0x8F8C";
      CallTryParse(numericString, NumberStyles.HexNumber);
   }
   
   private static void CallTryParse(string stringToConvert, NumberStyles styles)
   {
      ushort number;
      bool result = UInt16.TryParse(stringToConvert, styles, 
                                   CultureInfo.InvariantCulture, out number);
      if (result)
         Console.WriteLine("Converted '{0}' to {1}.", stringToConvert, number);
      else
         Console.WriteLine("Attempted conversion of '{0}' failed.", 
                           Convert.ToString(stringToConvert));
   }
}
// The example displays the following output:
//       Converted '10603' to 10603.
//       Attempted conversion of '-10603' failed.
//       Converted '29103.00' to 29103.
//       Attempted conversion of '10345.72' failed.
//       Converted '2210E-01' to 221.
//       Attempted conversion of '9112E-01' failed.
//       Converted '312E01' to 3120.
//       Converted 'FFC8' to 65480.
//       Attempted conversion of '0x8F8C' failed.
// </Snippet2>
