// <Snippet2>
using System;
using System.Globalization;

public class Temperature
{
   // Parses the temperature from a string. Temperature scale is 
   // indicated by 'F (for Fahrenheit) or 'C (for Celcius) at the end
   // of the string.
   public static Temperature Parse(string s, NumberStyles styles, 
                                   IFormatProvider provider)
   {                                    
      Temperature temp = new Temperature();

      if (s.TrimEnd(null).EndsWith("'F"))
      {
         temp.Value = Double.Parse(s.Remove(s.LastIndexOf((char)39), 2), 
                                   styles, provider);
      }
      else
      {
         if (s.TrimEnd(null).EndsWith("'C"))
            temp.Celsius = Double.Parse(s.Remove(s.LastIndexOf((char)39), 2), 
                                        styles, provider);
         else
            temp.Value = Double.Parse(s, styles, provider);         
      }
      return temp;      
   } 
   
   // Declare private constructor so Temperature so only Parse method can
   // create a new instance
   private Temperature()   {}

   protected double m_value;
   
   public double Value 
   {
      get { return m_value; }
      private set { m_value = value; }
   }
   
   public double Celsius
   {
      get { return (m_value - 32) / 1.8; }
      private set { m_value = value * 1.8 + 32; }
   }
   
   public double Fahrenheit
   {
      get {return m_value; }
   }      
}

public class TestTemperature
{
   public static void Main()
   {
      string value;
      NumberStyles styles;
      IFormatProvider provider;
      Temperature temp;
      
      value = "25,3'C";
      styles = NumberStyles.Float;
      provider = CultureInfo.CreateSpecificCulture("fr-FR");
      temp = Temperature.Parse(value, styles, provider);
      Console.WriteLine("{0} degrees Fahrenheit equals {1} degrees Celsius.", 
                        temp.Fahrenheit, temp.Celsius);
      
      value = " (40) 'C";
      styles = NumberStyles.AllowLeadingWhite | NumberStyles.AllowTrailingWhite 
               | NumberStyles.AllowParentheses;
      provider = NumberFormatInfo.InvariantInfo;
      temp = Temperature.Parse(value, styles, provider);
      Console.WriteLine("{0} degrees Fahrenheit equals {1} degrees Celsius.", 
                        temp.Fahrenheit, temp.Celsius);
      
      value = "5,778E03'C";      // Approximate surface temperature of the Sun
      styles = NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands |
               NumberStyles.AllowExponent;
      provider = CultureInfo.CreateSpecificCulture("en-GB"); 
      temp = Temperature.Parse(value, styles, provider);
      Console.WriteLine("{0} degrees Fahrenheit equals {1} degrees Celsius.", 
                        temp.Fahrenheit.ToString("N"), temp.Celsius.ToString("N"));
   }
}
// </Snippet2>
