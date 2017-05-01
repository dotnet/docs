// <Snippet2>
using System;
using System.Globalization;

public class SByteConversion
{
   NumberFormatInfo provider = NumberFormatInfo.CurrentInfo;

   public static void Main()
   {
      string stringValue;
      NumberStyles style;

      stringValue = "   123   ";
      style = NumberStyles.None;     
      CallParseOperation(stringValue, style);
      
      stringValue = "000,000,123";
      style = NumberStyles.Integer | NumberStyles.AllowThousands;
      CallParseOperation(stringValue, style);
      
      stringValue = "-100";
      style = NumberStyles.AllowLeadingSign;
      CallParseOperation(stringValue, style);
      
      stringValue = "100-";
      style = NumberStyles.AllowLeadingSign;
      CallParseOperation(stringValue, style);
      
      stringValue = "100-";
      style = NumberStyles.AllowTrailingSign;
      CallParseOperation(stringValue, style);
      
      stringValue = "$100";
      style = NumberStyles.AllowCurrencySymbol;
      CallParseOperation(stringValue, style);
      
      style = NumberStyles.Integer;
      CallParseOperation(stringValue, style);
      
      style = NumberStyles.AllowDecimalPoint;
      CallParseOperation("100.0", style);
      
      stringValue = "1e02";
      style = NumberStyles.AllowExponent;
      CallParseOperation(stringValue, style);
      
      stringValue = "(100)";
      style = NumberStyles.AllowParentheses;
      CallParseOperation(stringValue, style);
   }
   
   private static void CallParseOperation(string stringValue, 
                                          NumberStyles style)
   {                                          
      sbyte number;
      
      if (stringValue == null)
         Console.WriteLine("Cannot parse a null string...");
         
      try
      {
         number = sbyte.Parse(stringValue, style);
         Console.WriteLine("SByte.Parse('{0}', {1})) = {2}", 
                           stringValue, style, number);   
      }
      catch (FormatException)
      {
         Console.WriteLine("'{0}' and {1} throw a FormatException", 
                           stringValue, style);   
      }      
      catch (OverflowException)
      {
         Console.WriteLine("'{0}' is outside the range of a signed byte",
                           stringValue);
      }
   }
}
// The example displays the following information to the console:
//       '   123   ' and None throw a FormatException
//       SByte.Parse('000,000,123', Integer, AllowThousands)) = 123
//       SByte.Parse('-100', AllowLeadingSign)) = -100
//       '100-' and AllowLeadingSign throw a FormatException
//       SByte.Parse('100-', AllowTrailingSign)) = -100
//       SByte.Parse('$100', AllowCurrencySymbol)) = 100
//       '$100' and Integer throw a FormatException
//       SByte.Parse('100.0', AllowDecimalPoint)) = 100
//       SByte.Parse('1e02', AllowExponent)) = 100
//       SByte.Parse('(100)', AllowParentheses)) = -100
// </Snippet2>
