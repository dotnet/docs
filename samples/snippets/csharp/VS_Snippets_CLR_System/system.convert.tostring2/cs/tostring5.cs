// <Snippet26>
using System;

public class Temperature
{
   private decimal m_Temp;

   public Temperature(decimal temperature)
   {
      this.m_Temp = temperature;
   }
   
   public decimal Celsius
   {
      get { return this.m_Temp; }   
   }
   
   public decimal Kelvin
   {
      get { return this.m_Temp + 273.15m; }    
   }
   
   public decimal Fahrenheit
   {
      get { return Math.Round((decimal) (this.m_Temp * 9 / 5 + 32), 2); }
   }
   
   public override string ToString()
   {
      return m_Temp.ToString("N2") + " °C";
   }
}

public class Example
{
   public static void Main()
   {
      Temperature cold = new Temperature(-40);
      Temperature freezing = new Temperature(0);
      Temperature boiling = new Temperature(100);
      
      Console.WriteLine(Convert.ToString(cold, null));
      Console.WriteLine(Convert.ToString(freezing, null));
      Console.WriteLine(Convert.ToString(boiling, null));
   }
}
// The example dosplays the following output:
//       -40.00 °C
//       0.00 °C
//       100.00 °C
// </Snippet26>
