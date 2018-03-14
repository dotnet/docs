// <Snippet30>
using System;

public class Temperature : IFormattable 
{
   private decimal m_Temp; 

   public Temperature(decimal temperature)
   {
      this.m_Temp = temperature;
   } 

   public decimal Celsius 
   { get { return this.m_Temp; } } 

   public decimal Kelvin 
   { get { return this.m_Temp + 273.15m; } }   

   public decimal Fahrenheit
   {  get { return Math.Round(this.m_Temp * 9m / 5m + 32m, 2); } }

   public override String ToString() 
   { 
      return ToString("G", null); 
   } 
   
   public String ToString(String fmt, IFormatProvider provider) 
   {
      TemperatureProvider formatter = null;
      if (provider != null) 
         formatter = provider.GetFormat(typeof(TemperatureProvider)) 
                                       as TemperatureProvider;

      if (String.IsNullOrWhiteSpace(fmt)) {
         if (formatter != null) 
            fmt = formatter.Format;
         else
            fmt = "G";
      }

      switch (fmt.ToUpper()) {
         case "G":
         case "C":
            return m_Temp.ToString("N2") + " °C"; 
         case "F":
            return Fahrenheit.ToString("N2") + " °F";
         case "K":
            return Kelvin.ToString("N2") + " K";
         default:
            throw new FormatException(String.Format("'{0}' is not a valid format specifier.", fmt));
      }
   }                             
} 

public class TemperatureProvider : IFormatProvider
{
   private String[] fmtStrings = { "C", "G", "F", "K" };
   private Random rnd = new Random();
   
   public Object GetFormat(Type formatType) 
   { 
      return this; 
   }
   
   public String Format
   { get { return fmtStrings[rnd.Next(0, fmtStrings.Length)]; } }
}

public class Example
{
   public static void Main()
   {
      Temperature cold = new Temperature (-40);
      Temperature freezing = new Temperature (0);
      Temperature boiling = new Temperature (100);

      TemperatureProvider tp = new TemperatureProvider();
      
      Console.WriteLine(Convert.ToString(cold, tp));
      Console.WriteLine(Convert.ToString(freezing, tp));
      Console.WriteLine(Convert.ToString(boiling, tp));
   }
}
// The example displays output like the following:
//       -40.00 °C
//       273.15 K
//       100.00 °C
// </Snippet30>
