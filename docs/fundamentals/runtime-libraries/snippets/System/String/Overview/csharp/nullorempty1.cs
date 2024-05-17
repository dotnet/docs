using System;
using System.Globalization;

public class Example14
{
   public static void Main()
   {
      TestForIsNullOrEmpty();
      Console.WriteLine("-----");       
      TestForIsNullOrEmptyOrWhitespaceOnly();
   }

   private static void TestForIsNullOrEmpty()
   {
      string str = "";
      // <Snippet1>
      if (str == null || str.Equals(String.Empty))
      // </Snippet1>   
         Console.WriteLine("Bad string!");      
      else
         Console.WriteLine("Good string!");      
   }

   private static void TestForIsNullOrEmptyOrWhitespaceOnly()
   {
      string str = null;
      // <Snippet2>
      if (str == null || str.Equals(String.Empty) || str.Trim().Equals(String.Empty))
      // </Snippet2>   
         Console.WriteLine("Bad string!");      
      else
         Console.WriteLine("Good string!");      
   }
}

public class Temperature  : IFormattable
{
   double temp;
   
   public Temperature(double temp)
   {
      this.temp = temp;
   }
   
   public override string ToString()
   {
      return this.ToString("G", CultureInfo.CurrentCulture);
   }
   
   public string ToString(string format)
   {
      return this.ToString(format, CultureInfo.CurrentCulture);
   }
       
   // <Snippet3>
   public string ToString(string format, IFormatProvider provider) 
   {
      if (String.IsNullOrEmpty(format)) format = "G";  
      if (provider == null) provider = CultureInfo.CurrentCulture;
      
      switch (format.ToUpperInvariant())
      {
         // Return degrees in Celsius.    
         case "G":
         case "C":
            return temp.ToString("F2", provider) + "°C";
         // Return degrees in Fahrenheit.
         case "F": 
            return (temp * 9 / 5 + 32).ToString("F2", provider) + "°F";
         // Return degrees in Kelvin.
         case "K":   
            return (temp + 273.15).ToString();
         default:
            throw new FormatException(
                  String.Format("The {0} format string is not supported.", 
                                format));
      }                                   
   }
   // </Snippet3>
}
