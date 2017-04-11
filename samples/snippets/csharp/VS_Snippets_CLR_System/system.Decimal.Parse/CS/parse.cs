using System;
using System.Globalization;

public class Class1
{
   public static void Main()
   {
      CallParse();
      Console.WriteLine("-----");
      CallParseWithStyles();
      Console.WriteLine("-----");
      CallParseWithStylesAndProvider();
   }

   private static void CallParse()
   {
      // <Snippet1>
      string value;
      decimal number;
      // Parse an integer with thousands separators. 
      value = "16,523,421";
      number = Decimal.Parse(value);
      Console.WriteLine("'{0}' converted to {1}.", value, number);
      // Displays: 
      //    16,523,421' converted to 16523421.
      
      // Parse a floating point value with thousands separators
      value = "25,162.1378";
      number = Decimal.Parse(value);
      Console.WriteLine("'{0}' converted to {1}.", value, number);
      // Displays: 
      //    25,162.1378' converted to 25162.1378.
      
      // Parse a floating point number with US currency symbol.
      value = "$16,321,421.75";
      try
      {
         number = Decimal.Parse(value);
         Console.WriteLine("'{0}' converted to {1}.", value, number);
      }   
      catch (FormatException)
      {
         Console.WriteLine("Unable to parse '{0}'.", value);
      }
      // Displays:
      //    Unable to parse '$16,321,421.75'.   

      // Parse a number in exponential notation
      value = "1.62345e-02";
      try
      {
         number = Decimal.Parse(value);
         Console.WriteLine("'{0}' converted to {1}.", value, number);
      }   
      catch (FormatException)
      {
         Console.WriteLine("Unable to parse '{0}'.", value);
      }
      // Displays: 
      //    Unable to parse '1.62345e-02'. 
      // </Snippet1>
   }

   private static void CallParseWithStyles()
   {
      // <Snippet2>
      string value;
      decimal number;
      NumberStyles style;
      
      // Parse string with a floating point value using NumberStyles.None. 
      value = "8694.12";
      style = NumberStyles.None;
      try
      {
         number = Decimal.Parse(value, style);  
         Console.WriteLine("'{0}' converted to {1}.", value, number);
      }
      catch (FormatException)
      {
         Console.WriteLine("Unable to parse '{0}'.", value);
      }
      // Displays:
      //    Unable to parse '8694.12'.
      
      // Parse string with a floating point value and allow decimal point. 
      style = NumberStyles.AllowDecimalPoint;
      number = Decimal.Parse(value, style);  
      Console.WriteLine("'{0}' converted to {1}.", value, number);
      // Displays:
      //    '8694.12' converted to 8694.12.
      
      // Parse string with negative value in parentheses
      value = "(1,789.34)";
      style = NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands | 
              NumberStyles.AllowParentheses; 
      number = Decimal.Parse(value, style);  
      Console.WriteLine("'{0}' converted to {1}.", value, number);
      // Displays:
      //    '(1,789.34)' converted to -1789.34.
      
      // Parse string using Number style
      value = " -17,623.49 ";
      style = NumberStyles.Number;
      number = Decimal.Parse(value, style);  
      Console.WriteLine("'{0}' converted to {1}.", value, number);
      // Displays:
      //    ' -17,623.49 ' converted to -17623.49.
      // </Snippet2>   
   }

   private static void CallParseWithStylesAndProvider()
   {
      // <Snippet3> 
      string value;
      decimal number;
      NumberStyles style;
      CultureInfo provider;
      
      // Parse string using "." as the thousands separator 
      // and " " as the decimal separator. 
      value = "892 694,12";
      style = NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands;
      provider = new CultureInfo("fr-FR");

      number = Decimal.Parse(value, style, provider);  
      Console.WriteLine("'{0}' converted to {1}.", value, number);
      // Displays: 
      //    892 694,12' converted to 892694.12.

      try
      {
         number = Decimal.Parse(value, style, CultureInfo.InvariantCulture);  
         Console.WriteLine("'{0}' converted to {1}.", value, number);
      }   
      catch (FormatException)
      {
         Console.WriteLine("Unable to parse '{0}'.", value);
      }
      // Displays: 
      //    Unable to parse '892 694,12'.  
      
      // Parse string using "$" as the currency symbol for en-GB and  
      // en-us cultures.
      value = "$6,032.51";
      style = NumberStyles.Number | NumberStyles.AllowCurrencySymbol;
      provider = new CultureInfo("en-GB");

      try
      {
         number = Decimal.Parse(value, style, provider);  
         Console.WriteLine("'{0}' converted to {1}.", value, number);
      }   
      catch (FormatException)
      {
         Console.WriteLine("Unable to parse '{0}'.", value);
      }
      // Displays: 
      //    Unable to parse '$6,032.51'.

      provider = new CultureInfo("en-US");
      number = Decimal.Parse(value, style, provider);  
      Console.WriteLine("'{0}' converted to {1}.", value, number);
      // Displays: 
      //    '$6,032.51' converted to 6032.51.
      // </Snippet3>
   }
}
