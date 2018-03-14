// <Snippet2>
using System;
using System.Globalization;

public class Example
{
   public static void Main()
   {
      string numericString;
      NumberStyles styles;
      
      numericString = "106";
      styles = NumberStyles.Integer;
      CallTryParse(numericString, styles);
      
      numericString = "-106";
      styles = NumberStyles.None;
      CallTryParse(numericString, styles);
      
      numericString = "103.00";
      styles = NumberStyles.Integer | NumberStyles.AllowDecimalPoint;
      CallTryParse(numericString, styles);
      
      numericString = "103.72";
      styles = NumberStyles.Integer | NumberStyles.AllowDecimalPoint;
      CallTryParse(numericString, styles);

      numericString = "10E-01";
      styles = NumberStyles.Integer | NumberStyles.AllowExponent;
      CallTryParse(numericString, styles); 
      
      numericString = "12E-01";
      CallTryParse(numericString, styles);
          
      numericString = "12E01";
      CallTryParse(numericString, styles); 
      
      numericString = "C8";
      CallTryParse(numericString, NumberStyles.HexNumber);
      
      numericString = "0x8C";
      CallTryParse(numericString, NumberStyles.HexNumber);
   }
   
   private static void CallTryParse(string stringToConvert, NumberStyles styles)
   {
      sbyte number;
      bool result = SByte.TryParse(stringToConvert, styles, 
                                   CultureInfo.InvariantCulture, out number);
      if (result)
         Console.WriteLine("Converted '{0}' to {1}.", stringToConvert, number);
      else
         Console.WriteLine("Attempted conversion of '{0}' failed.", 
                           Convert.ToString(stringToConvert));
   }
}
// The example displays the following output:
//       Converted '106' to 106.
//       Attempted conversion of '-106' failed.
//       Converted '103.00' to 103.
//       Attempted conversion of '103.72' failed.
//       Converted '10E-01' to 1.
//       Attempted conversion of '12E-01' failed.
//       Converted '12E01' to 120.
//       Converted 'C8' to -56.
//       Attempted conversion of '0x8C' failed.
// </Snippet2>
