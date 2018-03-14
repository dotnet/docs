using System;
using System.Globalization;

public class Class1
{
   public static void Main()
   {
      CallParse1();
      Console.WriteLine("-----");
      CallParse3();
      Console.WriteLine("-----");
      CallParse4();
   }

   private static void CallParse1()
   {
      // <Snippet1>
      string value;
      short number;
      
      value = " 12603 ";
      try
      {
         number = Int16.Parse(value);
         Console.WriteLine("Converted '{0}' to {1}.", value, number);
      }
      catch (FormatException)
      {
         Console.WriteLine("Unable to convert '{0}' to a 16-bit signed integer.", 
                           value);
      }
      
      value = " 16,054";
      try
      {
         number = Int16.Parse(value);
         Console.WriteLine("Converted '{0}' to {1}.", value, number);
      }
      catch (FormatException)
      {
         Console.WriteLine("Unable to convert '{0}' to a 16-bit signed integer.", 
                           value);
      }
                              
      value = " -17264";
      try
      {
         number = Int16.Parse(value);
         Console.WriteLine("Converted '{0}' to {1}.", value, number);
      }
      catch (FormatException)
      {
         Console.WriteLine("Unable to convert '{0}' to a 16-bit signed integer.", 
                           value);
      }
      // The example displays the following output to the console:
      //       Converted ' 12603 ' to 12603.
      //       Unable to convert ' 16,054' to a 16-bit signed integer.
      //       Converted ' -17264' to -17264.      
      // </Snippet1>
   }

   private static void CallParse3()
   {
      // <Snippet3>
      string value;
      short number;
      NumberStyles style;
      CultureInfo provider;
      
      // Parse string using "." as the thousands separator 
      // and " " as the decimal separator.
      value = "19 694,00";
      style = NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands;
      provider = new CultureInfo("fr-FR");
      
      number = Int16.Parse(value, style, provider);
      Console.WriteLine("'{0}' converted to {1}.", value, number);
      // Displays:
      //    '19 694,00' converted to 19694.

      try
      {
         number = Int16.Parse(value, style, CultureInfo.InvariantCulture);
         Console.WriteLine("'{0}' converted to {1}.", value, number);
      }
      catch (FormatException)
      {
         Console.WriteLine("Unable to parse '{0}'.", value);
      }
      // Displays:
      //    Unable to parse '19 694,00'.
      
      // Parse string using "$" as the currency symbol for en_GB and
      // en-US cultures.
      value = "$6,032.00";
      style = NumberStyles.Number | NumberStyles.AllowCurrencySymbol;
      provider = new CultureInfo("en-GB");
      
      try
      {
         number = Int16.Parse(value, style, CultureInfo.InvariantCulture);
         Console.WriteLine("'{0}' converted to {1}.", value, number);
      }
      catch (FormatException)
      {
         Console.WriteLine("Unable to parse '{0}'.", value);
      }
      // Displays:
      //    Unable to parse '$6,032.00'.
                              
      provider = new CultureInfo("en-US");
      number = Int16.Parse(value, style, provider);
      Console.WriteLine("'{0}' converted to {1}.", value, number);
      // Displays:
      //    '$6,032.00' converted to 6032.      
      // </Snippet3>
   }

   private static void CallParse4()
   {
      // <Snippet4>      
      string stringToConvert;
      short number;
      
      stringToConvert = " 214 ";
      try
      {
         number = Int16.Parse(stringToConvert, CultureInfo.InvariantCulture);
         Console.WriteLine("Converted '{0}' to {1}.", stringToConvert, number);
      }
      catch (FormatException)
      {
         Console.WriteLine("Unable to parse '{0}'.", stringToConvert);
      }
      catch (OverflowException)
      {
         Console.WriteLine("'{0'} is out of range of the Int16 data type.", 
                           stringToConvert);
      }
      
      stringToConvert = " + 214";                     
      try
      {
         number = Int16.Parse(stringToConvert, CultureInfo.InvariantCulture);
         Console.WriteLine("Converted '{0}' to {1}.", stringToConvert, number);
      }
      catch (FormatException)
      {
         Console.WriteLine("Unable to parse '{0}'.", stringToConvert);
      }
      catch (OverflowException)
      {
         Console.WriteLine("'{0'} is out of range of the Int16 data type.", 
                           stringToConvert);
      }
      
      stringToConvert = " +214 "; 
      try
      {
         number = Int16.Parse(stringToConvert, CultureInfo.InvariantCulture);
         Console.WriteLine("Converted '{0}' to {1}.", stringToConvert, number);
      }
      catch (FormatException)
      {
         Console.WriteLine("Unable to parse '{0}'.", stringToConvert);
      }
      catch (OverflowException)
      {
         Console.WriteLine("'{0'} is out of range of the Int16 data type.", 
                           stringToConvert);
      }
      // The example displays the following output to the console:
      //       Converted ' 214 ' to 214.
      //       Unable to parse ' + 214'.
      //       Converted ' +214 ' to 214.
      // </Snippet4>      
   }
}
