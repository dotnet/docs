// <Snippet2>
using System;
using System.Globalization;

public class Example
{
   public static void Main()
   {
      string numericString;
      NumberStyles styles;
      
      numericString = "2106034";
      styles = NumberStyles.Integer;
      CallTryParse(numericString, styles);
      
      numericString = "-10603";
      styles = NumberStyles.None;
      CallTryParse(numericString, styles);
      
      numericString = "29103674.00";
      styles = NumberStyles.Integer | NumberStyles.AllowDecimalPoint;
      CallTryParse(numericString, styles);
      
      numericString = "10345.72";
      styles = NumberStyles.Integer | NumberStyles.AllowDecimalPoint;
      CallTryParse(numericString, styles);

      numericString = "41792210E-01";
      styles = NumberStyles.Integer | NumberStyles.AllowExponent;
      CallTryParse(numericString, styles); 
      
      numericString = "9112E-01";
      CallTryParse(numericString, styles);
          
      numericString = "312E01";
      CallTryParse(numericString, styles); 
      
      numericString = "FFC86DA1";
      CallTryParse(numericString, NumberStyles.HexNumber);
      
      numericString = "0x8F8C";
      CallTryParse(numericString, NumberStyles.HexNumber);
   }
   
   private static void CallTryParse(string stringToConvert, NumberStyles styles)
   {
      uint number;
      bool result = UInt32.TryParse(stringToConvert, styles, 
                                   CultureInfo.InvariantCulture, out number);
      if (result)
         Console.WriteLine("Converted '{0}' to {1}.", stringToConvert, number);
      else
         Console.WriteLine("Attempted conversion of '{0}' failed.", 
                           Convert.ToString(stringToConvert));
   }
}
// The example displays the following output:
//       Converted '2106034' to 2106034.
//       Attempted conversion of '-10603' failed.
//       Converted '29103674.00' to 29103674.
//       Attempted conversion of '10345.72' failed.
//       Converted '41792210E-01' to 4179221.
//       Attempted conversion of '9112E-01' failed.
//       Converted '312E01' to 3120.
//       Converted 'FFC86DA1' to 4291325345.
//       Attempted conversion of '0x8F8C' failed.
// </Snippet2>
