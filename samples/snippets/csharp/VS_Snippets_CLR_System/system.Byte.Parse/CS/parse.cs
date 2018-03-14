using System;
using System.Globalization;

public class Class1
{
   public static void Main()
   {
      CallParse1();
      Console.WriteLine();
      CallParse2();
      Console.WriteLine();
      CallParse3();
      Console.WriteLine();
      CallParse4();
   }

   private static void CallParse1()
   {
      // <Snippet1>
      string stringToConvert = " 162";
      byte byteValue;
      try
      {
         byteValue = Byte.Parse(stringToConvert);
         Console.WriteLine("Converted '{0}' to {1}.", stringToConvert, byteValue);
      }   
      catch (FormatException)
      {
         Console.WriteLine("Unable to parse '{0}'.", stringToConvert);
      }
      catch (OverflowException)
      {
         Console.WriteLine("'{0}' is greater than {1} or less than {2}.", 
                           stringToConvert, Byte.MaxValue, Byte.MinValue);
      }  
      // The example displays the following output to the console:
      //       Converted ' 162' to 162.         
      // </Snippet1>
   }

   private static void CallParse2()
   {
      // <Snippet2>
      string stringToConvert; 
      byte byteValue;
      
      stringToConvert = " 214 ";
      try {
         byteValue = Byte.Parse(stringToConvert, CultureInfo.InvariantCulture);
         Console.WriteLine("Converted '{0}' to {1}.", stringToConvert, byteValue);
      }
      catch (FormatException) {
         Console.WriteLine("Unable to parse '{0}'.", stringToConvert); }
      catch (OverflowException) {
         Console.WriteLine("'{0}' is greater than {1} or less than {2}.", 
                           stringToConvert, Byte.MaxValue, Byte.MinValue); }
      
      stringToConvert = " + 214 ";
      try {
         byteValue = Byte.Parse(stringToConvert, CultureInfo.InvariantCulture);
         Console.WriteLine("Converted '{0}' to {1}.", stringToConvert, byteValue);
      }
      catch (FormatException) {
         Console.WriteLine("Unable to parse '{0}'.", stringToConvert); }
      catch (OverflowException) {
         Console.WriteLine("'{0}' is greater than {1} or less than {2}.", 
                           stringToConvert, Byte.MaxValue, Byte.MinValue); }
      
      stringToConvert = " +214 ";
      try {
         byteValue = Byte.Parse(stringToConvert, CultureInfo.InvariantCulture);
         Console.WriteLine("Converted '{0}' to {1}.", stringToConvert, byteValue);
      }
      catch (FormatException) {
         Console.WriteLine("Unable to parse '{0}'.", stringToConvert); }
      catch (OverflowException) {
         Console.WriteLine("'{0}' is greater than {1} or less than {2}.", 
                           stringToConvert, Byte.MaxValue, Byte.MinValue); }
      // The example displays the following output to the console:
      //       Converted ' 214 ' to 214.
      //       Unable to parse ' + 214 '.
      //       Converted ' +214 ' to 214.
      // </Snippet2>
   }
   private static void CallParse3()
   {
      // <Snippet3>
      string value;
      NumberStyles style;
      byte number;
      
      // Parse value with no styles allowed.
      style = NumberStyles.None;
      value = " 241 ";
      try
      {
         number = Byte.Parse(value, style);
         Console.WriteLine("Converted '{0}' to {1}.", value, number);
      }
      catch (FormatException) {
         Console.WriteLine("Unable to parse '{0}'.", value); }   
        
      // Parse value with trailing sign.
      style = NumberStyles.Integer | NumberStyles.AllowTrailingSign;
      value = " 163+";
      number = Byte.Parse(value, style);
      Console.WriteLine("Converted '{0}' to {1}.", value, number);
      
      // Parse value with leading sign.
      value = "   +253  ";
      number = Byte.Parse(value, style);
      Console.WriteLine("Converted '{0}' to {1}.", value, number);
      // This example displays the following output to the console:
      //       Unable to parse ' 241 '.
      //       Converted ' 163+' to 163.
      //       Converted '   +253  ' to 253.            
      // </Snippet3>      
   }

   private static void CallParse4()
   {
      // <Snippet4>
      NumberStyles style;
      CultureInfo culture;
      string value;
      byte number;
      
      // Parse number with decimals.
      // NumberStyles.Float includes NumberStyles.AllowDecimalPoint.
      style = NumberStyles.Float;     
      culture = CultureInfo.CreateSpecificCulture("fr-FR");
      value = "12,000";

      number = Byte.Parse(value, style, culture);
      Console.WriteLine("Converted '{0}' to {1}.", value, number);

      culture = CultureInfo.CreateSpecificCulture("en-GB");
      try
      {
         number = Byte.Parse(value, style, culture);
         Console.WriteLine("Converted '{0}' to {1}.", value, number);
      }
      catch (FormatException) {
         Console.WriteLine("Unable to parse '{0}'.", value); }   

      value = "12.000";
      number = Byte.Parse(value, style, culture);
      Console.WriteLine("Converted '{0}' to {1}.", value, number);
      // The example displays the following output to the console:
      //       Converted '12,000' to 12.
      //       Unable to parse '12,000'.
      //       Converted '12.000' to 12.
      // </Snippet4>
   }
}
