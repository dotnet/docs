// <Snippet1>
using System;
using System.Globalization;

public class Temperature : IFormattable
{
   private decimal temp;
   
   public Temperature(decimal temperature)
   {
      if (temperature < -273.15m) 
        throw new ArgumentOutOfRangeException(String.Format("{0} is less than absolute zero.", 
                                              temperature));
      this.temp = temperature;
   }
   
   public decimal Celsius
   {
      get { return temp; }
   }
   
   public decimal Fahrenheit
   {
      get { return temp * 9 / 5 + 32; }
   }
   
   public decimal Kelvin
   {
      get { return temp + 273.15m; }
   }

   public override string ToString()
   {
      return this.ToString("G", CultureInfo.CurrentCulture);
   }
      
   public string ToString(string format)
   {
      return this.ToString(format, CultureInfo.CurrentCulture);
   }
   
   public string ToString(string format, IFormatProvider provider) 
   {
      if (String.IsNullOrEmpty(format)) format = "G";
      if (provider == null) provider = CultureInfo.CurrentCulture;
      
      switch (format.ToUpperInvariant())
      {
         case "G":
         case "C":
            return temp.ToString("F2", provider) + " °C"; 
         case "F":
            return Fahrenheit.ToString("F2", provider) + " °F";
         case "K":
            return Kelvin.ToString("F2", provider) + " K";
         default:
            throw new FormatException(String.Format("The {0} format string is not supported.", format));
      }
   }
}
// </Snippet1>

// <Snippet2>
public class Example
{
   public static void Main()
   {
      // Use composite formatting with format string in the format item.
      Temperature temp1 = new Temperature(0);
      Console.WriteLine("{0:C} (Celsius) = {0:K} (Kelvin) = {0:F} (Fahrenheit)\n", temp1);
      
      // Use composite formatting with a format provider.
      temp1 = new Temperature(-40);
      Console.WriteLine(String.Format(CultureInfo.CurrentCulture, "{0:C} (Celsius) = {0:K} (Kelvin) = {0:F} (Fahrenheit)", temp1));
      Console.WriteLine(String.Format(new CultureInfo("fr-FR"), "{0:C} (Celsius) = {0:K} (Kelvin) = {0:F} (Fahrenheit)\n", temp1));
      
      // Call ToString method with format string.
      temp1 = new Temperature(32);
      Console.WriteLine("{0} (Celsius) = {1} (Kelvin) = {2} (Fahrenheit)\n", 
                        temp1.ToString("C"), temp1.ToString("K"), temp1.ToString("F"));

      // Call ToString with format string and format provider
      temp1 = new Temperature(100)      ;
      NumberFormatInfo current = NumberFormatInfo.CurrentInfo;
      CultureInfo nl = new CultureInfo("nl-NL"); 
      Console.WriteLine("{0} (Celsius) = {1} (Kelvin) = {2} (Fahrenheit)", 
                        temp1.ToString("C", current), temp1.ToString("K", current), temp1.ToString("F", current));
      Console.WriteLine("{0} (Celsius) = {1} (Kelvin) = {2} (Fahrenheit)", 
                        temp1.ToString("C", nl), temp1.ToString("K", nl), temp1.ToString("F", nl));
   }
}
// The example displays the following output:
//    0.00 °C (Celsius) = 273.15 K (Kelvin) = 32.00 °F (Fahrenheit)
//    
//    -40.00 °C (Celsius) = 233.15 K (Kelvin) = -40.00 °F (Fahrenheit)
//    -40,00 °C (Celsius) = 233,15 K (Kelvin) = -40,00 °F (Fahrenheit)
//    
//    32.00 °C (Celsius) = 305.15 K (Kelvin) = 89.60 °F (Fahrenheit)
//    
//    100.00 °C (Celsius) = 373.15 K (Kelvin) = 212.00 °F (Fahrenheit)
//    100,00 °C (Celsius) = 373,15 K (Kelvin) = 212,00 °F (Fahrenheit)
// </Snippet2>
