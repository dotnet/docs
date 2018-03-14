using System;
using System.Globalization;
using System.Threading;

public class ParseString
{
   // <Snippet1>
   public static void Main()
   {
      // Set current thread culture to en-US.
      Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
      
      string value;
      NumberStyles styles;
      
      // Parse a string in exponential notation with only the AllowExponent flag. 
      value = "-1.063E-02";
      styles = NumberStyles.AllowExponent;
      ShowNumericValue(value, styles);
      
      // Parse a string in exponential notation
      // with the AllowExponent and Number flags.
      styles = NumberStyles.AllowExponent | NumberStyles.Number;
      ShowNumericValue(value, styles);

      // Parse a currency value with leading and trailing white space, and
      // white space after the U.S. currency symbol.
      value = " $ 6,164.3299  ";
      styles = NumberStyles.Number | NumberStyles.AllowCurrencySymbol;
      ShowNumericValue(value, styles);
      
      // Parse negative value with thousands separator and decimal.
      value = "(4,320.64)";
      styles = NumberStyles.AllowParentheses | NumberStyles.AllowTrailingSign |
               NumberStyles.Float; 
      ShowNumericValue(value, styles);
      
      styles = NumberStyles.AllowParentheses | NumberStyles.AllowTrailingSign |
               NumberStyles.Float | NumberStyles.AllowThousands;
      ShowNumericValue(value, styles);
   }

   private static void ShowNumericValue(string value, NumberStyles styles)
   {
      double number;
      try
      {
         number = Double.Parse(value, styles);
         Console.WriteLine("Converted '{0}' using {1} to {2}.", 
                           value, styles.ToString(), number);
      }
      catch (FormatException)
      {
         Console.WriteLine("Unable to parse '{0}' with styles {1}.", 
                           value, styles.ToString());
      }
      Console.WriteLine();                           
   }   
   // The example displays the following output to the console:
   //    Unable to parse '-1.063E-02' with styles AllowExponent.
   //    
   //    Converted '-1.063E-02' using AllowTrailingSign, AllowThousands, Float to -0.01063.
   //    
   //    Converted ' $ 6,164.3299  ' using Number, AllowCurrencySymbol to 6164.3299.
   //    
   //    Unable to parse '(4,320.64)' with styles AllowTrailingSign, AllowParentheses, Float.
   //    
   //    Converted '(4,320.64)' using AllowTrailingSign, AllowParentheses, AllowThousands, Float to -4320.64.   
   // </Snippet1>
}
