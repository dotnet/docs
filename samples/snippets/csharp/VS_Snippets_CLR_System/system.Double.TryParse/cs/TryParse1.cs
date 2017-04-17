using System;
using System.Globalization;

public class Class1
{
   public static void Main()
   {
      DefaultTryParse();
      Console.WriteLine("----------");
      TryParseWithConstraints();
   }

   private static void DefaultTryParse()
   {
      string value;
      double number;
      
      // Parse a floating-point value with a thousands separator.
      value = "1,643.57";
      if (Double.TryParse(value, out number))
         Console.WriteLine(number);
      else
         Console.WriteLine("Unable to parse '{0}'.", value);      
      
      // Parse a floating-point value with a currency symbol and a 
      // thousands separator.
      value = "$1,643.57";
      if (Double.TryParse(value, out number))
         Console.WriteLine(number);
      else
         Console.WriteLine("Unable to parse '{0}'.", value);   
      
      // Parse value in exponential notation.
      value = "-1.643e6";
      if (Double.TryParse(value, out number))
         Console.WriteLine(number);
      else
         Console.WriteLine("Unable to parse '{0}'.", value);   
      
      // Parse a negative integer value.
      value = "-168934617882109132";
      if (Double.TryParse(value, out number))
         Console.WriteLine(number);
      else
         Console.WriteLine("Unable to parse '{0}'.", value);   
      // The example displays the following output to the console:
      //       1643.57
      //       Unable to parse '$1,643.57'.
      //       -1643000
      //       -1.68934617882109E+17
   }

   private static void TryParseWithConstraints()
   {
      // <Snippet2>
      string value;
      NumberStyles style;
      CultureInfo culture;
      double number;
      
      // Parse currency value using en-GB culture.
      value = "£1,097.63";
      style = NumberStyles.Number | NumberStyles.AllowCurrencySymbol;
      culture = CultureInfo.CreateSpecificCulture("en-GB");
      if (Double.TryParse(value, style, culture, out number))
         Console.WriteLine("Converted '{0}' to {1}.", value, number);
      else
         Console.WriteLine("Unable to convert '{0}'.", value);
      // Displays: 
      //       Converted '£1,097.63' to 1097.63.
      
      value = "1345,978";
      style = NumberStyles.AllowDecimalPoint;
      culture = CultureInfo.CreateSpecificCulture("fr-FR");
      if (Double.TryParse(value, style, culture, out number))
         Console.WriteLine("Converted '{0}' to {1}.", value, number);
      else
         Console.WriteLine("Unable to convert '{0}'.", value);
      // Displays:
      //       Converted '1345,978' to 1345.978.
      
      value = "1.345,978";
      style = NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands;
      culture = CultureInfo.CreateSpecificCulture("es-ES");
      if (Double.TryParse(value, style, culture, out number))
         Console.WriteLine("Converted '{0}' to {1}.", value, number);
      else
         Console.WriteLine("Unable to convert '{0}'.", value);
      // Displays: 
      //       Converted '1.345,978' to 1345.978.
      
      value = "1 345,978";
      if (Double.TryParse(value, style, culture, out number))
         Console.WriteLine("Converted '{0}' to {1}.", value, number);
      else
         Console.WriteLine("Unable to convert '{0}'.", value);
      // Displays:
      //       Unable to convert '1 345,978'.
      // </Snippet2>   
   }
}
