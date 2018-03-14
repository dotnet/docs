// <Snippet1>
using System;

public class Example
{
   public enum TemperatureScale 
   { Celsius, Fahrenheit, Kelvin }

   public static void Main()
   {
      String info = GetCurrentTemperature();
      Console.WriteLine(info);
   }

   private static String GetCurrentTemperature()
   {
      DateTime dat = DateTime.Now;
      Decimal temp = 20.6m;
      TemperatureScale scale = TemperatureScale.Celsius;
      String result;
      
      result = String.Format("At {0:t} on {1:D}, the temperature is {2:F1} {3:G}",
                             dat, temp, scale);    
      return result;
   }
}
// The example displays output like the following:
//    Unhandled Exception: System.FormatException: Format specifier was invalid.
//       at System.Number.FormatDecimal(Decimal value, String format, NumberFormatInfo info)
//       at System.Decimal.ToString(String format, IFormatProvider provider)
//       at System.Text.StringBuilder.AppendFormat(IFormatProvider provider, String format, Object[] args)
//       at System.String.Format(IFormatProvider provider, String format, Object[] args)
//       at Example.Main()
// </Snippet1>
