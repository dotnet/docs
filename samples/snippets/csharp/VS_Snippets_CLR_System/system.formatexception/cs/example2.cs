// <Snippet2>
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
      
      result = String.Format("At {0:t} on {0:D}, the temperature is {1:F1} {2:G}",
                             dat, temp, scale);    
      return result;
   }
}
// The example displays output like the following:
//    At 10:40 AM on Wednesday, June 04, 2014, the temperature is 20.6 Celsius
// </Snippet2>
