// <Snippet2>
using System;
using System.Globalization;

public class StringParsing
{
   public static void Main()
   {
      string numericString;
      NumberStyles styles;
      
      numericString = "10677";
      styles = NumberStyles.Integer;
      CallTryParse(numericString, styles);

      numericString = "-30677";
      styles = NumberStyles.None;
      CallTryParse(numericString, styles);
      
      numericString = "10345.00";
      styles = NumberStyles.Integer | NumberStyles.AllowDecimalPoint;
      CallTryParse(numericString, styles);
      
      numericString = "10345.72";
      styles = NumberStyles.Integer | NumberStyles.AllowDecimalPoint;
      CallTryParse(numericString, styles);

      numericString = "22,593"; 
      styles = NumberStyles.Integer | NumberStyles.AllowThousands;
      CallTryParse(numericString, styles);
      
      numericString = "12E-01";
      styles = NumberStyles.Integer | NumberStyles.AllowExponent;
      CallTryParse(numericString, styles); 
          
      numericString = "12E03";
      CallTryParse(numericString, styles); 
      
      numericString = "80c1";
      CallTryParse(numericString, NumberStyles.HexNumber);
      
      numericString = "0x80C1";
      CallTryParse(numericString, NumberStyles.HexNumber);      
   }

   private static void CallTryParse(string stringToConvert, NumberStyles styles)
   {
      short number;
      bool result = Int16.TryParse(stringToConvert, styles, 
                                   CultureInfo.InvariantCulture, out number);
      if (result)
         Console.WriteLine("Converted '{0}' to {1}.", stringToConvert, number);
      else
         Console.WriteLine("Attempted conversion of '{0}' failed.", 
                           Convert.ToString(stringToConvert));
   }
}
// The example displays the following output to the console:
//       Converted '10677' to 10677.
//       Attempted conversion of '-30677' failed.
//       Converted '10345.00' to 10345.
//       Attempted conversion of '10345.72' failed.
//       Converted '22,593' to 22593.
//       Attempted conversion of '12E-01' failed.
//       Converted '12E03' to 12000.
//       Converted '80c1' to -32575.
//       Attempted conversion of '0x80C1' failed.
// </Snippet2>
